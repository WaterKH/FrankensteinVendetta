//On FPC in FrankensteinChapter1
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Creates the pause menu using the "Esc" key
public class PauseMenu : MonoBehaviour {

	//Script instance
	public JournalAppear journalAppear;
	public InventoryScript inventory;
	public InventorySlots invenSlots;
	public Inputs inputs;

	//CanvasGroup instances
	public CanvasGroup backgroundPauseGroup;
	public CanvasGroup buttonGroup;
	public CanvasGroup sidePanelGroup;
	public CanvasGroup pageGroup;

	public bool escKey;
	public bool journalKey;
	float elapsedTime;
	float canvasTime;

	void Update ()
	{
		//Just to keep the times in reasonable limits
		if(elapsedTime > 1)
			elapsedTime = 1;
		if(canvasTime > 1)
			canvasTime = 1;
		//TODO Still fix the "Hover over resume"

		//If the esc button is pressed..
		if (InputManager.GetKeyDown(KeyboardTags.pause) || InputManager.GetKeyDown(KeyboardTags.pauseSecondary)) 
		{

			//.. set to false if true, true if false
			if(!inventory.RPressed)
				escKey = !escKey;
			else
				inventory.RPressed = false;
			elapsedTime = 0;
			canvasTime = 0;

		}
		//If the notes button is pressed..
		if (InputManager.GetKeyDown(KeyboardTags.notes)) 
		{

			//.. Calls the method clickedJournal() which is below
			clickedJournal ();
			elapsedTime = 0;
			canvasTime = 0;
		}

		//if the escKey is true..
		if (escKey) {

			elapsedTime += .05f;
			//Allow the cursor to roam free and set it to be visible
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			//No raycasts can get through
			backgroundPauseGroup.blocksRaycasts = true;
			//Pauses the game
			Time.timeScale = 0;
			//if the alpha is below one
			if (backgroundPauseGroup.alpha < 1)
			{

				//Lerps the alpha to visible of the side bar and the background
				FVAPI.lerpAlphaChannel(sidePanelGroup, 1, elapsedTime);
				FVAPI.lerpAlphaChannel(backgroundPauseGroup, 1, elapsedTime);
				//sidePanelGroup.alpha = Mathf.Lerp(sidePanelGroup.alpha, 1, elapsedTime);
				//backgroundPauseGroup.alpha = Mathf.Lerp (backgroundPauseGroup.alpha, 1, elapsedTime);
				//Also set it so no raycasts can go through
				sidePanelGroup.blocksRaycasts = true;
				backgroundPauseGroup.blocksRaycasts = true;

			
			}
			//else if it is equal to or above 1
			else if (backgroundPauseGroup.alpha >= 1) {

				canvasTime += .05f;
				//Lerp the alpha to visible of the buttons
				FVAPI.lerpAlphaChannel(buttonGroup, 1, canvasTime);
				//buttonGroup.alpha = Mathf.Lerp(buttonGroup.alpha, 1, canvasTime);
				buttonGroup.interactable = true;
				
			}


		} 	
		//Else if the esc key is false
		else if(!escKey && !inventory.RPressed){

			if (buttonGroup.alpha > 0) {
				canvasTime += .05f;
				//Lerp alpha to invisible of the buttons
				FVAPI.lerpAlphaChannel(buttonGroup, 0, canvasTime);
				//buttonGroup.alpha = Mathf.Lerp(buttonGroup.alpha, 0, canvasTime);
				buttonGroup.interactable = false;
			}
			else if (backgroundPauseGroup.alpha >= 0)
			{

				elapsedTime += .05f;
				//Set journalKey to false since it will be fading out
				journalKey = false;
				//Lerp the alpha to invisible of the side panel and background
				FVAPI.lerpAlphaChannel(sidePanelGroup, 0, elapsedTime);
				FVAPI.lerpAlphaChannel(backgroundPauseGroup, 0, elapsedTime);
				//sidePanelGroup.alpha = Mathf.Lerp(sidePanelGroup.alpha, 0, elapsedTime);
				//backgroundPauseGroup.alpha = Mathf.Lerp (backgroundPauseGroup.alpha, 0, elapsedTime);
				//Does not block raycasts
				sidePanelGroup.blocksRaycasts = false;
				backgroundPauseGroup.blocksRaycasts = false;
				//Set cursor to locked and invisible
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				if(sidePanelGroup.alpha <= 0)
				{
					//Resume gameplay
					Time.timeScale = 1;
				
				}

			}
			
		}

	}

	//Called on ResumeGame under the onClick() event
	public void clickedResume()
	{

		elapsedTime = 0;
		canvasTime = 0;
		//Sets the game to continue
		escKey = false;
		journalKey = false;

	}

	//Called on JournalEntries under the onClick() event
	public void clickedJournal()
	{

		elapsedTime = 0;
		canvasTime = 0;
		//Sets the journalKey to be true, used in ResumeButton and JournalAppear class
		journalKey = true; 
		journalAppear.journalTime = 0;

	}

	//TODO Display Options
	public void clickedOptions()
	{

		

	}

	public void clickedMainMenu()
	{

		Time.timeScale = 1;
		Application.LoadLevelAsync(0);

	}

}
