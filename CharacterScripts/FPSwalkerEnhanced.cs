using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSwalkerEnhanced: MonoBehaviour {

	public float walkSpeed = 4.0f;
	public float runSpeed = 6.0f;
	public float crouchSpeed = 1.5f;

	float initWalkSpeed = 4.0f;
	float initRunSpeed = 6.0f;
	float initialHeight = 0f;
	float elapsedTime = 0f;

	public bool walking = true;
	public bool running = false;
	public bool crouching = false;

	// If true, diagonal speed (when strafing + moving forward or back) can't exceed normal move speed; otherwise it's about 1.4 times faster
	public bool limitDiagonalSpeed = true;

	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;

	// Units that player can fall before a falling damage function is run. To disable, type "infinity" in the inspector
	public float fallingDamageThreshold = 10.0f;

	// If checked, then the player can change direction while in the air
	public bool airControl = false;

	// Small amounts of this results in bumping when walking down slopes, but large amounts results in falling too fast
	public float antiBumpFactor = .75f;

	// Player must be grounded for at least this many physics frames before being able to jump again; set to 0 to allow bunny hopping
	public int antiBunnyHopFactor = 1;

	private Vector3 moveDirection = Vector3.zero;
	private bool grounded = false;
	private Transform myTransform;
	private float speed;
	private RaycastHit hit;
	private float fallStartLevel;
	private bool falling;
	private string contactPoint;
	private bool playerControl = false;
	private int jumpTimer;
	private float cameraYOffset;

	private bool crouchKeyWasDown;
	private float crouchHeight;
	private float standardHeight;
	private GameObject mainCamera;
	private float height;

	public SaveLoad saveLoad;

	void Awake()
	{

		saveLoad.LoadKeyboard();

	}

	void Start() {

		myTransform = transform;
		speed = walkSpeed;
		jumpTimer = antiBunnyHopFactor;

		height = gameObject.transform.localScale.y;
		Debug.Log("Height: "+height);
		mainCamera = GameObject.FindWithTag("MainCamera");
		cameraYOffset = mainCamera.transform.localPosition.y;
		crouchHeight = height/2;
		initialHeight = height;

		walking = true;
		running = false;
		crouching = false;
		
	}


	void FixedUpdate() {

		//TODO Change this!
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		// If both horizontal and vertical are used simultaneously, limit speed (if allowed), so the total doesn't exceed normal move speed
		float inputModifyFactor = (inputX != 0.0f && inputY != 0.0f && limitDiagonalSpeed)? .7071f : 1.0f;

		if (grounded) 
		{
						
			// If we were falling, and we fell a vertical distance greater than the threshold, run a falling damage routine
			if (falling)
				falling = false;
						
			// Jump! But only if the jump button has been released and player has been grounded for a given number of frames
			if(!Input.inputString.Equals(InputManager.GetKey(KeyboardTags.jump)))
				jumpTimer++;
			else if (jumpTimer >= antiBunnyHopFactor) 
			{

				moveDirection.y = jumpSpeed;
				jumpTimer = 0;

			}

		}
		else 
		{

				// If we stepped over a cliff or something, set the height at which we started falling
				if (!falling) {

					falling = true;
					fallStartLevel = myTransform.position.y;
										
				}							
				// If air control is allowed, check movement but don't touch the y component
				if (airControl && playerControl) {

					moveDirection.x = inputX * speed * inputModifyFactor;
					moveDirection.z = inputY * speed * inputModifyFactor;
					moveDirection = myTransform.TransformDirection (moveDirection);
			
				}
			
		}

		// Apply gravity
		moveDirection.y -= gravity * Time.deltaTime;


		// Move the controller, and set grounded true or false depending on whether we're standing on something
		if(contactPoint != null)
			if(contactPoint.Equals("ground"))
				grounded = true;
						
	}
	void Update () {

		// If the run button is set to toggle, then switch between walk/run speed. (We use Update for this...
		// FixedUpdate is a poor place to use GetButtonDown, since it doesn't necessarily run every frame and can miss the event)
		if (grounded && Input.inputString.Equals(InputManager.GetKey(KeyboardTags.run)) && !crouching)
			speed = (speed == walkSpeed? runSpeed : walkSpeed);
		if(Input.anyKey)
		{
			
			if (Input.inputString.Equals(InputManager.GetKey(KeyboardTags.run)) && !crouching) {
				running = true;
				walking = false;

				//Debug.Log ("Is running.");
			} else if (Input.inputString.Equals(InputManager.GetKey(KeyboardTags.crouch))) {

				crouching = !crouching;
				running = false;
				walking = false;
				
			}
		}

		if(crouching)
		{
			elapsedTime = 0;
			height = Mathf.Lerp(height, crouchHeight, Time.deltaTime*10);
			walkSpeed = crouchSpeed*1.5f;
			runSpeed = crouchSpeed*2f;

		}
		else if(!crouching)
		{
			elapsedTime += Time.deltaTime;
			height = Mathf.Lerp(height, initialHeight, elapsedTime);
			if(height >= 1.9)
				height = initialHeight;
			walkSpeed = initWalkSpeed;
			runSpeed = initRunSpeed;
			walking = true;
			
			
		}

	}
	

	// Store point that we're in contact with for use in FixedUpdate if needed
	void OnCollisionEnter (Collision collision) {
		contactPoint = collision.gameObject.tag;
	}

}