//On ScriptHolder
using UnityEngine;
using System.Collections;

public class moveToOptions : MonoBehaviour {

	//Transforms to be used by Cameras
	public Transform camPos;
	public Transform camRot;
	public Transform finalCamPos;
	public Transform finalCamRot;
	public Transform initCamPos;
	public Transform initCamRot;

	public bool moveTo;
	public bool moveBackToMenu;
	float elapsedTime;
	float canvasTime;

	//Canvas Groups
	public CanvasGroup optionsMenu;
	public CanvasGroup backOption;
	public CanvasGroup scrollOver;
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
			camPos.position = Vector3.Lerp (camPos.position, finalCamPos.position, elapsedTime/2);
			camPos.rotation = Quaternion.Slerp (camRot.rotation, finalCamRot.rotation, elapsedTime/2);

			//If current Camera position is equal to the target..
			if (camPos.position == finalCamPos.position) 
			{

				//.. Options menu's alpha becomes visible and interactable
				canvasTime += Time.deltaTime;
				optionsMenu.interactable = true;
				backOption.interactable = true;
				scrollOver.interactable = true;
				optionsMenu.alpha = Mathf.Lerp (optionsMenu.alpha, 1, canvasTime);
				backOption.alpha = Mathf.Lerp (backOption.alpha, 1, canvasTime);
				scrollOver.alpha = Mathf.Lerp (scrollOver.alpha, 1, canvasTime);
				
			}
		} 
		//else if current Camera position is equal to inital position
		else if (moveBackToMenu)
		{

			elapsedTime += Time.deltaTime;
			//Lerps the position and rotation to inital position
			camPos.position = Vector3.Lerp (camPos.position, initCamPos.position, elapsedTime/2);
			camRot.rotation = Quaternion.Slerp (camRot.rotation, initCamRot.rotation, elapsedTime/2);
			//Alpha invisible and interactable
			optionsMenu.alpha = Mathf.Lerp (optionsMenu.alpha, 0, elapsedTime*2);
			backOption.alpha = Mathf.Lerp (backOption.alpha, 0, elapsedTime*2);
			scrollOver.alpha = Mathf.Lerp (scrollOver.alpha, 0, elapsedTime*2);
			graphics.alpha = Mathf.Lerp(graphics.alpha, 0, Time.deltaTime);
			sound.alpha = Mathf.Lerp(sound.alpha, 0, Time.deltaTime);
			controls.alpha = Mathf.Lerp(controls.alpha, 0, Time.deltaTime);
			optionsMenu.interactable = false;
			backOption.interactable = false;
			scrollOver.interactable = false;
			
		} 

	}

}
