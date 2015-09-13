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
	public List<User> listOfTypeUSERS; //Was userNamesMenu
	public SaveLoad saveLoadData;
	public NewPlayerClick playerClick;
	public DeleteUser delete;
	public PageFlipping flipPage;
	public CancelDeletion cancelDelete;

	public int usernameNumb;
	//Used in PageFlipping
	public int layer;
	public bool tempLayer;
	public int userNumbTracker;

	public GameObject currUser;
	
	bool showInput;
	bool showNewName;

	public Animation doorOpen;
	//public List<string> usernames; //Grouped with listOfUsers
	public CanvasGroup inputGroup;
	public CanvasGroup usernameGroup;
	public RectTransform parent;
	public RectTransform[] userPlacements = new RectTransform[5];
	public List<GameObject> listOfUsers;

	//Runs before anything else
	void Awake()
	{

		if(File.Exists(Application.persistentDataPath + "/UsernameMenuInfo.dat"))
			//Loads the Users for the mainmenu
			saveLoadData.LoadUsers();

		//TODO Fix this if neccessary
		/*if(listOfUsers.Count != listOfTypeUSERS.Count)
		{
			
			usernames.Clear();
			foreach(User user in userNamesMenu)
				usernames.Add(user.getPlayerName());
			
		}
		
		//Runs a for loop for how many slots there are for users
		for(int i = 0; i < userNamesMenu.Count; i++)
		{
			//text equals the playerName saved with the SavedUsers() method
			if(usernames[i] != null)
				usernames[i] = userNamesMenu[i].getPlayerName();
			
		}*/

	}

	private void CreateUser()
	{
		
		GameObject newUser = Instantiate(Resources.Load ("User")) as GameObject;
		Debug.Log("Creating User");
		listOfUsers.Add(newUser);
		currUser = newUser;
		newUser.GetComponent<RectTransform>().SetParent(parent, false);
		newUser.GetComponent<RectTransform>().anchoredPosition = userPlacements[usernameNumb].anchoredPosition;

	}
	
	public void CreateUser(int placement)
	{
		
		GameObject newUser = Instantiate(Resources.Load ("User")) as GameObject;
		listOfUsers.Add(newUser);
		currUser = newUser;
		newUser.GetComponent<RectTransform>().SetParent(parent, false);
		newUser.GetComponent<RectTransform>().anchoredPosition = userPlacements[placement].anchoredPosition;

	}

	private void NameUser()
	{

		currUser.GetComponentInChildren<Text>().text = listOfTypeUSERS[listOfTypeUSERS.Count-1].getPlayerName();

	}

	public void NameUser(string user)
	{

		currUser.GetComponentInChildren<Text>().text = user;

	}

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

	}
	
	public void clickedUsername(GameObject buttonClicked)
	{

		if(delete.remove)
			delete.ClickedUser(buttonClicked);
		else
		{
			//.. The username in SaveLoad class is set to the playerName from User class, then calls the Load method
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

			}
			saveLoadData.loaded = false;
			//Then moves the player to the mainmenu
			playerClick.moveToMainMenu();
			doorOpen.Play("MainMenuDoorOpen");
		}

	}

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
			//usernames.Add(characterName.text);
			NameUser();
			currUser.name = characterName.text;
			flipPage.De_ActivateUsers();
			saveLoadData.SaveUsers();
			Debug.Log("Successfully created user: " + characterName.text);

		}
	
	}

	void Update()
	{
		//Calls first, shows input field
		if(showInput)
		{

			inputGroup.interactable = true;
			FVAPI.lerpAlphaChannelTimeMultiplied(inputGroup, 1, 2);
			//inputGroup.alpha = Mathf.Lerp(inputGroup.alpha, 1, Time.deltaTime*2);
			inputGroup.blocksRaycasts = true;

		}
		//After Enter is hit while in input field, this will call next
		else if(showNewName)
		{

			//Input field invisible
			inputGroup.interactable = false;
			FVAPI.lerpAlphaChannel(inputGroup, 0);
			//inputGroup.alpha = Mathf.Lerp(inputGroup.alpha, 0, Time.deltaTime);
			inputGroup.blocksRaycasts = false;

			usernameGroup.interactable = true;
			FVAPI.lerpAlphaChannel(usernameGroup, 1);
			//usernameGroup.alpha = Mathf.Lerp(usernameGroup.alpha, 1, Time.deltaTime);
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
			//inputGroup.alpha = Mathf.Lerp(inputGroup.alpha, 0, Time.deltaTime*2);
			inputGroup.blocksRaycasts = false;

			usernameGroup.interactable = true;
			FVAPI.lerpAlphaChannel(usernameGroup, 1);
			//usernameGroup.alpha = Mathf.Lerp(usernameGroup.alpha, 1, Time.deltaTime);
			usernameGroup.blocksRaycasts = true;

		}

	}

}
