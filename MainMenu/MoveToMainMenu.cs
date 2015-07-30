//On ScriptHolder
using UnityEngine;
using System.Collections;

public class MoveToMainMenu : MonoBehaviour {

	//Transforms to be used
	public Transform camPos;
	public Transform camRot;
	public Transform transCamPos;
	public Transform transCamRot;
	public Transform finalCamPos;
	public Transform finalCamRot;
	public Transform initialCamPos;
	public Transform initialCamRot;
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
					camPos.position = Vector3.Lerp(camPos.position, finalCamPos.position, timeToMoveToMain/7);
					camRot.rotation = Quaternion.Lerp(camRot.rotation, finalCamRot.rotation, timeToMoveToMain/7);
					if(camPos.position == finalCamPos.position)
						doNotMove = false;
				}
				//runs if atMain is false
				else
				{

					elapsedTime += Time.deltaTime;
					//Lerps for position and rotation towards the transition point
					camPos.position = Vector3.Lerp(camPos.position, transCamPos.position, elapsedTime/7);
					camRot.rotation = Quaternion.Lerp(camRot.rotation, transCamRot.rotation, elapsedTime/7);
					//When the Camera position eqauls the transition point..
					if(camPos.position == transCamPos.position)
						//..atMain becomes true
						atMain = true;

				}
			}
			else
			{

				mainMenuText.alpha = Mathf.Lerp(mainMenuText.alpha, 1, Time.deltaTime*2);
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
				mainMenuText.alpha = Mathf.Lerp(mainMenuText.alpha, 0, Time.deltaTime*2);
				mainMenuText.blocksRaycasts = false;
				mainMenuText.interactable = false;

				camPos.position = Vector3.Lerp(camPos.position, transCamPos.position, timeToMoveToMain/10);
				camRot.rotation = Quaternion.Lerp(camRot.rotation, transCamRot.rotation, timeToMoveToMain/10);
				if(camPos.position == transCamPos.position)
					atMain = false;

			}
			else
			{

				elapsedTime += Time.deltaTime;
				camPos.position = Vector3.Lerp(transCamPos.position, initialCamPos.position, elapsedTime/3);
				camRot.rotation = Quaternion.Lerp(transCamRot.rotation, initialCamRot.rotation, elapsedTime/3);

			}


		}

	}

}
