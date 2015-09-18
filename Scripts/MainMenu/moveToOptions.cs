//On ScriptHolder
using UnityEngine;
using System.Collections;

public class moveToOptions : MonoBehaviour {

	//Transforms to be used by Cameras
	public Transform mainCam;
	public Transform finalCam;
	public Transform initCam;

	public bool moveTo;
	public bool moveBackToMenu;
	float elapsedTime;
	float canvasTime;

	//Canvas Groups
	public CanvasGroup optionsMenu;
	public CanvasGroup graphics;
	public CanvasGroup sound;
	public CanvasGroup controls;

	//Used by Options button of Menu Canvas 
	public void moveOptions()
	{

		elapsedTime = 0;
		canvasTime = 0;
		moveTo = true;
		moveBackToMenu = false;

	}

	//Used by back button of Options Canvas
	public void moveBack()
	{

		elapsedTime = 0;
		canvasTime = 0;
		moveTo = false;
		moveBackToMenu = true;

	}
	
	void Update()
	{

		if (moveTo) {

			elapsedTime += Time.deltaTime;
			//Lerps the position and rotation to options menu
			FVAPI.lerpVectorAndQuaternion(mainCam, finalCam, elapsedTime/2);
			//camPos.position = Vector3.Lerp (camPos.position, finalCamPos.position, elapsedTime/2);
			//camPos.rotation = Quaternion.Slerp (camRot.rotation, finalCamRot.rotation, elapsedTime/2);

			//If current Camera position is equal to the target..
			if (mainCam.position == finalCam.position) 
			{

				//.. Options menu's alpha becomes visible and interactable
				canvasTime += Time.deltaTime;
				optionsMenu.interactable = true;
				FVAPI.lerpAlphaChannel(optionsMenu, 1, canvasTime);
				//optionsMenu.alpha = Mathf.Lerp (optionsMenu.alpha, 1, canvasTime);
				//backOption.alpha = Mathf.Lerp (backOption.alpha, 1, canvasTime);
				//scrollOver.alpha = Mathf.Lerp (scrollOver.alpha, 1, canvasTime);
				
			}
		} 
		//else if current Camera position is equal to inital position
		else if (moveBackToMenu)
		{

			elapsedTime += Time.deltaTime;
			//Lerps the position and rotation to inital position
			FVAPI.lerpVectorAndQuaternion(mainCam, initCam, elapsedTime/2);
			//mainCam.position = Vector3.Lerp (mainCam.position, initCam.position, elapsedTime/2);
			//mainCam.rotation = Quaternion.Slerp (mainCam.rotation, initCam.rotation, elapsedTime/2);
			//Alpha invisible and interactable
			FVAPI.lerpAlphaChannel(optionsMenu, 0, elapsedTime*2);
			FVAPI.lerpAlphaChannel(graphics, 0);
			FVAPI.lerpAlphaChannel(sound, 0);
			FVAPI.lerpAlphaChannel(controls, 0);
			//optionsMenu.alpha = Mathf.Lerp (optionsMenu.alpha, 0, elapsedTime*2);
			//backOption.alpha = Mathf.Lerp (backOption.alpha, 0, elapsedTime*2);
			//scrollOver.alpha = Mathf.Lerp (scrollOver.alpha, 0, elapsedTime*2);
			//graphics.alpha = Mathf.Lerp(graphics.alpha, 0, Time.deltaTime);
			//sound.alpha = Mathf.Lerp(sound.alpha, 0, Time.deltaTime);
			//controls.alpha = Mathf.Lerp(controls.alpha, 0, Time.deltaTime);
			optionsMenu.interactable = false;
			
		} 

	}

}
