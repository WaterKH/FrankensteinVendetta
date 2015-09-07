using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSwalkerEnhanced: MonoBehaviour {

	public float walkSpeed = 6.0f;
	public float runSpeed = 12.0f;
	public float crouchSpeed = 6.5f;

	float initWalkSpeed = 10.0f;
	float initRunSpeed = 12.0f;
	float initialHeight = 0f;
	float elapsedTime = 0f;

	public bool running = false;
	public bool crouching = false;

	// If true, diagonal speed (when strafing + moving forward or back) can't exceed normal move speed; otherwise it's about 1.4 times faster
	public bool limitDiagonalSpeed = true;

	public float jumpSpeed = 4.0f;
	public float gravity = 10.0f;
	public float maxChangeVel = 10.0f;

	// Units that player can fall before a falling damage function is run. To disable, type "infinity" in the inspector
	public float fallingDamageThreshold = 10.0f;

	// If checked, then the player can change direction while in the air
	public bool airControl = true;

	// Small amounts of this results in bumping when walking down slopes, but large amounts results in falling too fast
	public float antiBumpFactor = .75f;

	// Player must be grounded for at least this many physics frames before being able to jump again; set to 0 to allow bunny hopping
	public int antiBunnyHopFactor = 1;
	public Rigidbody rigidBod;

	private Vector3 moveDirection = Vector3.zero;
	public bool grounded = true;
	private Transform myTransform;
	private float speed;
	private RaycastHit hit;
	private float fallStartLevel;
	private bool falling;
	private bool playerControl = true;
	public int jumpTimer;
	private float cameraYOffset;

	private bool crouchKeyWasDown;
	private float crouchHeight;
	private GameObject mainCamera;
	private float height;

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

		running = false;
		crouching = false;
	
	}


	void FixedUpdate() {

		float inputX = InputManager.GetAxis("moveLeft") + InputManager.GetAxis("moveRight");
		float inputY = InputManager.GetAxis("moveBackward") + InputManager.GetAxis("moveForward");

		// If both horizontal and vertical are used simultaneously, limit speed (if allowed), so the total doesn't exceed normal move speed
		float inputModifyFactor = (inputX != 0.0f && inputY != 0.0f && limitDiagonalSpeed)? .7071f : 1.0f;

		if (grounded) 
		{
						
			// If we were falling, and we fell a vertical distance greater than the threshold, run a falling damage routine
			if (falling)
				falling = false;

			speed = InputManager.GetKey ("run") ? runSpeed : walkSpeed;
						
			cameraYOffset = mainCamera.transform.localPosition.y;
			moveDirection = new Vector3 (inputX * inputModifyFactor, -antiBumpFactor, inputY * inputModifyFactor);
			moveDirection = myTransform.TransformDirection (moveDirection) * speed;
			
			Vector3 velocity = rigidBod.velocity;
			Vector3 velocityChange = moveDirection - velocity;
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxChangeVel, maxChangeVel);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -maxChangeVel, maxChangeVel);
			velocityChange.y = 0;

			rigidBod.AddForce(velocityChange, ForceMode.VelocityChange);

			// Jump! But only if the jump button has been released and player has been grounded for a given number of frames
			if(!InputManager.GetKey("jump"))
				jumpTimer++;
			else if (jumpTimer >= antiBunnyHopFactor && InputManager.GetKeyDown("jump")) 
			{
	
				moveDirection.y = jumpSpeed;
				rigidBod.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
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
		rigidBod.AddForce(new Vector3 (0, -gravity * rigidBod.mass, 0));
		grounded = isGrounded();
						
	}
	void Update () {

		// If the run button is set to toggle, then switch between walk/run speed. (We use Update for this...
		// FixedUpdate is a poor place to use GetButtonDown, since it doesn't necessarily run every frame and can miss the event)
		if (grounded && InputManager.GetKey("run") && !crouching)
			speed = (speed == walkSpeed? runSpeed : walkSpeed);

		if (InputManager.GetKey("run") && !crouching) {
			running = true;

			//Debug.Log ("Is running.");
		} else if (InputManager.GetKeyDown("crouch")) {

			crouching = !crouching;
			running = false;

		}
		else
		{

			running = false;

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
			
		}

		if(InputManager.GetKey("leanLeft"))
			LeanLeft();

	}

	float CalculateJumpVerticalSpeed () {
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpSpeed * gravity);
	}

	bool isGrounded()
	{

		return (Physics.Raycast(transform.position, new Vector3(0,-1.15f,0), out hit, 1.15f));

	}

	void LeanLeft()
	{
		Quaternion mainCamRot = mainCamera.transform.rotation;
		mainCamera.transform.rotation = Quaternion.Euler(new Vector3(30,0,0));

	}

}