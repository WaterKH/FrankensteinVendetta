using UnityEngine;
using System.Collections;

public class LeanLeftRight : MonoBehaviour {

	public Transform leanLeft;
	public Transform leanRight;
	public Transform cam;
	public Transform initCam;

	public MouseLook mouseLookX;
	public MouseLook mouseLookY;
	public MouseLook mouseLookInitCam;

	public bool allowedToLean;

	void LeanLeft()
	{
		//Debug.Log("LeanLeft");
		FVAPI.lerpVectorAndQuaternionTimeMultiplied(cam, leanLeft, 5);
		//mouseLookX.enabled = false;
		//mouseLookY.enabled = false;
//		mouseLookInitCam.enabled = false;
	}

	void LeanRight()
	{
		//Debug.Log("LeanRight");
		FVAPI.lerpVectorAndQuaternionTimeMultiplied(cam, leanRight, 5);
		//mouseLookX.enabled = false;
		//mouseLookY.enabled = false;
//		mouseLookInitCam.enabled = false;
	}

	void LeanBack()
	{
//		Debug.Log("LeanBack");
		FVAPI.lerpVectorAndQuaternionTimeMultiplied(cam, initCam, 4);
		if(cam.rotation.z <= 0.01f && cam.rotation.z >= -0.01f)
		{
			allowedToLean = true;
//			mouseLookX.enabled = true;
//			mouseLookY.enabled = true;
//			mouseLookInitCam.enabled = true;
		}
	}

	void Update()
	{

		if(InputManager.GetKey("leanLeft") && InputManager.GetKey("leanRight"))
			allowedToLean = false;

		if(InputManager.GetKeyUp("leanLeft") && allowedToLean)
			allowedToLean = false;
		else if(InputManager.GetKeyUp("leanRight") && allowedToLean)
			allowedToLean = false;

		if(InputManager.GetKey("leanLeft") && !InputManager.GetKey("leanRight") && allowedToLean)
			LeanLeft ();
		else if(InputManager.GetKey("leanRight") && !InputManager.GetKey("leanLeft") && allowedToLean)
			LeanRight ();
		else
			LeanBack ();

	}

}
