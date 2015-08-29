using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour 
{
	public float walkSpeed = 7; // regular speed
	public float crchSpeed = 3; // crouching speed
	public float runSpeed = 20; // run speed


	private CharacterMotor chMotor;
	private Transform tr;
	private float dist; // distance to ground

	// Use this for initialization
	void Start () 
	{
		chMotor =  GetComponent<CharacterMotor>();
		tr = transform;
		CharacterController ch = GetComponent<CharacterController>();
		dist = ch.height/2; // calculate distance to ground

	}


	// Update is called once per frame
	void FixedUpdate ()
	{
		float vScale = 1.0f;
		float speed = walkSpeed;

		if ((Input.GetKey ("left shift") || Input.GetKey ("right shift")) && chMotor.grounded) {
						speed = runSpeed;

				}

		if (Input.GetKey("c"))
		{ // press C to crouch
			vScale = 0.5f;
			speed = crchSpeed; // slow down when crouching
		}

		chMotor.movement.maxForwardSpeed = speed; // set max speed
		float ultScale = tr.localScale.y; // crouch/stand up smoothly 

		Vector3 tmpScale = tr.localScale;
		Vector3 tmpPosition = tr.position;

		tmpScale.y = Mathf.Lerp(tr.localScale.y, vScale, 5 * Time.deltaTime);
		tr.localScale = tmpScale;

		tmpPosition.y += dist * (tr.localScale.y - ultScale); // fix vertical position       
		tr.position = tmpPosition;
	}

}