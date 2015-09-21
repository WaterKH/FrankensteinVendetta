//On ScriptHolder
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using System;

public class CreateNewUser : MonoBehaviour {

	public InputField characterName;

	//Script Instances
	public List<User> listOfTypeUSERS;
	public SaveLoad saveLoadData;
	public NewPlayerClick playerClick;
	public DeleteUser delete;
	public PageFlipping flipPage;
	public CancelDeletion cancelDelete;

	public int usernameNumb;
	public int layer;
	public bool tempLayer;
	public int userNumbTracker;

	public GameObject currUser;
	
	bool showInput;
	bool showNewName;

	public Animation doorOpen;
	public CanvasGroup inputGroup;
	public CanvasGroup usernameGroup;
	public RectTransform parent;
	public RectTransform[] userPlacements = new RectTransform[5];
	public List<GameObject> listOfUsers;

	//Runs before anything else
	void Awake()
	{

		if(File.Exists(Application.persistentDataPath + "/UsernameMenuInfo.dat"))
			//Loads the Users for the mainmenu if the file exists
			saveLoadData.LoadUsers();

	} //void Awake()

	/******************************************************************************************************************
	 * 
	 * Function: CreateUser()
	 * 
	 * We create a new user and set the position.
	 * 
	**/ 
	private void CreateUser()
	{
		
		GameObject newUser = Instantiate(Resources.Load ("User")) as GameObject;
		Debug.Log("Creating User");
		listOfUsers.Add(newUser);
		currUser = newUser;
		newUser.GetComponent<RectTransform>().SetParent(parent, false);
		newUser.GetComponent<RectTransform>().anchoredPosition = userPlacements[usernameNumb].anchoredPosition;

	} //private void CreateUser()

	/******************************************************************************************************************
	 * 
	 * Function: CreateUser(int)
	 * 
	 * Called from SaveLoad.cs
	 * 
	 * We create a new user and set the position based on the integer value passed in.
	 * 
	**/ 
	public void CreateUser(int placement)
	{
		
		GameObject newUser = Instantiate(Resources.Load ("User")) as GameObject;
		listOfUsers.Add(newUser);
		currUser = newUser;
		newUser.GetComponent<RectTransform>().SetParent(parent, false);
		newUser.GetComponent<RectTransform>().anchoredPosition = userPlacements[placement].anchoredPosition;

	} //public void CreateUser(int)

	/******************************************************************************************************************
	 * 
	 * Function: NameUser()
	 * 
	 * Names the current user.
	 * 
	**/ 
	private void NameUser()
	{

		currUser.GetComponentInChildren<Text>().text = listOfTypeUSERS[listOfTypeUSERS.Count-1].getPlayerName();

	} //private void NameUser()

	/******************************************************************************************************************
	 * 
	 * Function: CreateUser()
	 * 
	 * Called from SaveLoad.cs
	 * 
	 * Names the current user based on the string value passed in.
	 * 
	**/ 
	public void NameUser(string user)
	{

		currUser.GetComponentInChildren<Text>().text = user;

	} //public void NameUser(string)


	/******************************************************************************************************************
	 * 
	 * Function: clickedCreateUser()
	 * 
	 * Called when the user clicks on the "Create User" button within game.
	 * 
	 * First, we check if we are removing, and if so we cancel the deletion and recall this method. Next, we 
	 * 	check if the limit has been reached (ie 5) and if has been, we flip the page (add to the layer)
	 * 	reset the username's counter. We then set our boolean that dictates whether or not the input is shown
	 * 	to true and call CreateUser() (Above).
	 * 
	**/ 
	public void clickedCreateUser()
	{

		if(delete.remove)
		{
			cancelDelete.DeletionCancelation();
			clickedCreateUser();
		}
	
		if(usernameNumb == 5)
		{

			flipPage.FlipPageForward();
			usernameNumb = 0;
			layer++;
			
		}
		else if(tempLayer && usernameNumb != 4)
		{

			flipPage.FlipPageForward();
			layer++;
			tempLayer = false;

		}

		showInput = true;
		CreateUser();

	} //public void clickedCreateUser()

	/******************************************************************************************************************
	 * 
	 * Function: clickedUsername()
	 * 
	 * Called when the user clicks on a user button within game.
	 * 
	 * First, we check if we are removing, and if so we delete the user clicked on. Else, we load the data.
	 * 	If we successfully loaded, we print out that we did and continue. Else, we set the global name of the
	 * 	user and save the data then load that data. We then move the player to the menu.
	 * 	
	 * 
	**/
	public void clickedUsername(GameObject buttonClicked)
	{

		if(delete.remove)
			delete.ClickedUser(buttonClicked);
		else
		{

			saveLoadData.userName = buttonClicked.GetComponentInChildren<Text>().text;
			saveLoadData.Load();
			if(saveLoadData.loaded)
				Debug.Log("Load successful");
			else
			{

				Debug.Log("No load data found - Creating save file");
				Player_MAIN.player.setName(saveLoadData.userName);
				Debug.Log(Player_MAIN.player.getName());
				saveLoadData.Save();
				Debug.Log("Save file created for "+Player_MAIN.player.getName());
				saveLoadData.Load ();

			}
			saveLoadData.loaded = false;
			//Then moves the player to the mainmenu
			playerClick.moveToMainMenu();
			doorOpen.Play("MainMenuDoorOpen");
		}

	} //public void clickedUsername(GameObject)

	/******************************************************************************************************************
	 * 
	 * Function: pressedEnterUsername()
	 * 
	 * Called when the user presses enter after entering in a new username.
	 * 
	 * We close our input and set our new username to be shown, as well as create a variable to show if the user
	 * 	is already in use or not. We then cycle through the entire listOfTypeUSERS and if the names equal each
	 * 	other we remove the user from the list and destroy it and cycle back through our users accordingly.
	 * 	
	 * We then add the user to the listOfTypeUSERS and set everything else incremented by one to account
	 * 	for the new user.
	 * 	
	 * 
	**/
	public void pressedEnterUsername()
	{

		//The inputfield is set to invisible
		showInput = false;
		showNewName = true;
		bool nameAvailable = true;
		foreach(User user in listOfTypeUSERS)
		{

			if(characterName.text != user.getPlayerName())
				nameAvailable = true;
			else if(characterName.text == user.getPlayerName())
			{

				Debug.Log("Input: "+characterName.text);
				nameAvailable = false;
				listOfUsers.Remove(currUser);
				Destroy(currUser);
				if(usernameNumb == 0 && layer > 0)
				{

					usernameNumb = 5;
					layer--;
					flipPage.FlipPageBack();
					
				}
				Debug.Log("Name unavailable; please choose another one");
				break;

			}

		}

		if(nameAvailable)
		{
			Debug.Log("Creating user: " + characterName.text);
			usernameNumb++;
			userNumbTracker++;
			listOfTypeUSERS.Add(new User(characterName.text, false, layer, usernameNumb));
			NameUser();
			currUser.name = characterName.text;
			flipPage.De_ActivateUsers();
			saveLoadData.SaveUsers();
			Debug.Log("Successfully created user: " + characterName.text);

		}
	
	} //public void pressedUserName()

	/******************************************************************************************************************
	 * 
	 * Function: Update()
	 * 
	 * Updates the alpha channels based on the booleans set above.
	 * 
	**/
	void Update()
	{
		//Calls first, shows input field
		if(showInput)
		{

			inputGroup.interactable = true;
			FVAPI.lerpAlphaChannelTimeMultiplied(inputGroup, 1, 2);
			inputGroup.blocksRaycasts = true;

		}
		//After Enter is hit while in input field, this will call next
		else if(showNewName)
		{

			//Input field invisible
			inputGroup.interactable = false;
			FVAPI.lerpAlphaChannel(inputGroup, 0);
			inputGroup.blocksRaycasts = false;

			usernameGroup.interactable = true;
			FVAPI.lerpAlphaChannel(usernameGroup, 1);
			usernameGroup.blocksRaycasts = true;

			if(inputGroup.alpha <= 0.5f)
			{

				showNewName = false;
				saveLoadData.SaveUsers();

			}
		

		}
		else
		{
			//Finishes making the inputGroup alpha invisible, not interactable and not able to block raycasts
			inputGroup.interactable = false;
			FVAPI.lerpAlphaChannelTimeMultiplied(inputGroup, 0, 2);
			inputGroup.blocksRaycasts = false;

			usernameGroup.interactable = true;
			FVAPI.lerpAlphaChannel(usernameGroup, 1);
			usernameGroup.blocksRaycasts = true;

		}

	}

}
