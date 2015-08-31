﻿//On ScriptHolder
using UnityEngine;
using System.Collections;

public class MoveToMainMenu : MonoBehaviour {

	//Transforms to be used
	public Transform mainCam;
	public Transform transCam;
	public Transform finalCam;
	public Transform initialCam;

	//Used in NewPlayerClick
	public bool moveTo;
	public bool atMain;
	public bool doNotMove;
	public float elapsedTime;
	public float timeToMoveToMain;

	public CanvasGroup mainMenuText;
	public bool moveBack;
	public Animation doorOpen;

	public moveToOptions moveOptions;

	void Update()
	{

		//moveTo is called in the Update of NewPlayerClick
		if(moveTo)
		{
			moveBack = false;
			if(doNotMove)
			{
				//runs if atMain is true
				if(atMain)
				{
					timeToMoveToMain += Time.deltaTime;
					//Lerps for position and rotation towards the actual Menu
					FVAPI.lerpVectorAndQuaternion(mainCam, finalCam, timeToMoveToMain/7);
					//camPos.position = Vector3.Lerp(camPos.position, finalCamPos.position, timeToMoveToMain/7);
					//camRot.rotation = Quaternion.Lerp(camRot.rotation, finalCamRot.rotation, timeToMoveToMain/7);
					if(mainCam.position == finalCam.position)
						doNotMove = false;
				}
				//runs if atMain is false
				else
				{

					elapsedTime += Time.deltaTime;
					//Lerps for position and rotation towards the transition point
					FVAPI.lerpVectorAndQuaternion(mainCam, transCam, elapsedTime/7);
					//camPos.position = Vector3.Lerp(camPos.position, transCamPos.position, elapsedTime/7);
					//camRot.rotation = Quaternion.Lerp(camRot.rotation, transCamRot.rotation, elapsedTime/7);
					//When the Camera position eqauls the transition point..
					if(mainCam.position == transCam.position)
						//..atMain becomes true
						atMain = true;

				}
			}
			else
			{

				FVAPI.lerpAlphaChannelTimeMultiplied(mainMenuText, 1, 2);
				//mainMenuText.alpha = Mathf.Lerp(mainMenuText.alpha, 1, Time.deltaTime*2);
				mainMenuText.blocksRaycasts = true;
				mainMenuText.interactable = true;

			}

		}
		//moveBack is called in mainMenu
		else if(moveBack)
		{

			if(atMain)
			{

				moveOptions.moveBackToMenu = false;
				moveOptions.moveTo = false;
				doorOpen.Play("MainMenuDoorOpen");
				timeToMoveToMain += Time.deltaTime;
				FVAPI.lerpAlphaChannelTimeMultiplied(mainMenuText, 0, 2);
				//mainMenuText.alpha = Mathf.Lerp(mainMenuText.alpha, 0, Time.deltaTime*2);
				mainMenuText.blocksRaycasts = false;
				mainMenuText.interactable = false;

				FVAPI.lerpVectorAndQuaternion(mainCam, transCam, timeToMoveToMain/10);
				//mainCam.position = Vector3.Lerp(camPos.position, transCamPos.position, timeToMoveToMain/10);
				//mainCam.rotation = Quaternion.Lerp(camRot.rotation, transCamRot.rotation, timeToMoveToMain/10);
				if(mainCam.position == transCam.position)
					atMain = false;

			}
			else
			{

				elapsedTime += Time.deltaTime;

				mainCam.position = Vector3.Lerp(transCam.position, initialCam.position, elapsedTime/3);
				mainCam.rotation = Quaternion.Lerp(transCam.rotation, initialCam.rotation, elapsedTime/3);

			}


		}

	}

}
