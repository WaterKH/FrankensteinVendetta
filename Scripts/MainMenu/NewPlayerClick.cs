﻿//MainMenu Script
//On Pencil object under MainMenu Scene
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class NewPlayerClick : MonoBehaviour {

	//Transforms to be used by Cameras
	public Transform mainCam;
	public Transform finalCam;
	public Transform initCam;

	public bool pointerDown;
	public bool goingToMenu;
	bool readyToMove;
	float elapsedTime;

	//login = Users
	public CanvasGroup login;

	//Classes
	public MoveToMainMenu moveToMain;

	//Initial Call to make Camera move to towards the book 
	public void OnMouseDown()
	{

		pointerDown = true;
		elapsedTime = 0;

	}

	//Call to make Camera back towards the initial position
	public void returnCamera()
	{

		pointerDown = false;
		elapsedTime = 0;

	}

	//Call to make Camera move to the actual menu
	//Called in the CreateNewUser class
	public void moveToMainMenu()
	{

		goingToMenu = true;
		pointerDown = false;
		readyToMove = true;
		elapsedTime = 0;

	}

	void Update () {

		//This is made true in OnMouseDown()
		if(pointerDown)
		{

			elapsedTime += Time.deltaTime;
			//Lerps for position and rotation towards the book
			FVAPI.lerpVectorAndQuaternion(mainCam, finalCam, elapsedTime/10);
			//camPos.position = Vector3.Lerp(camPos.position, finalCamPos.position, elapsedTime/10);
			//camRot.rotation = Quaternion.Lerp(camRot.rotation, finalCamRot.rotation, elapsedTime/10);

			//if the Camera position equals the position to go to..
			if(mainCam.position.z >= finalCam.position.z -0.05f)
			{

				//..The alpha channels of the Users Canvas Group and Back button become visible and interactable
				FVAPI.lerpAlphaChannel(login, 1);
				//login.alpha = Mathf.Lerp(login, 1, Time.deltaTime);
				login.interactable = true;
	
			}
				
		}
		//else if the pointer is false, the initial Camera's position exists, and the moveTo boolean of the 
		//class MoveToMainMenu is false..
		//pointerDown made false in returnCamera()
		else if(!pointerDown && initCam != null && !moveToMain.moveTo)
		{

			elapsedTime += Time.deltaTime;
			//Lerps for position and rotation towards the inital Camera position
			if(goingToMenu)
			{
				//Lerps for position and rotation towards the inital Camera position
				FVAPI.lerpVectorAndQuaternion(mainCam, initCam, elapsedTime/10);
				//camPos.position = Vector3.Lerp(camPos.position, initCamPos.position, elapsedTime/10);
				//camRot.rotation = Quaternion.Lerp(camRot.rotation, initCamRot.rotation, elapsedTime/10);
				//The alpha channels of the Users Canvas Group and Back button become invisible and not interactable
				FVAPI.lerpAlphaChannelTimeMultiplied(login, 0, 2);
				//login.alpha = Mathf.Lerp(login.alpha, 0, Time.deltaTime*2);
				login.interactable = false;

			}
			//readToMove bool made true when called in moveToMainMenu()
			if(mainCam.position == initCam.position && readyToMove)
			{
				//moveTo bool becomes true in the MoveToMainMenu class
				if(goingToMenu)
				{
					moveToMain.moveTo = true;
					moveToMain.doNotMove = true;
				}
				else
				{
					moveToMain.elapsedTime = 0;
					moveToMain.timeToMoveToMain = 0;
					moveToMain.moveBack = false;
				}

			}

		}
	
	}
}
