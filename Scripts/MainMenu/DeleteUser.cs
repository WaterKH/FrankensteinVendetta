//On ScriptHolder
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DeleteUser : MonoBehaviour {

	public bool remove;

	//Script instances
	public CreateNewUser createUser;
	public SaveLoad saveLoad;
	public PageFlipping flipPage;
	public CancelDeletion cancelDeletion;

	public Button deleteButton;
	public CanvasGroup deleteCanvas;

	//Called by DeleteUser on MainMenu
	public void ClickedDelete()
	{

		remove = true;
		foreach(GameObject user in createUser.listOfUsers)
		{
			
			ColorBlock colorBlock = user.GetComponent<Button>().colors;
			colorBlock.normalColor = Color.black;
			user.GetComponent<Button>().colors = colorBlock;

		}

		deleteCanvas.alpha = 0;
		deleteCanvas.interactable = false;
		deleteCanvas.blocksRaycasts = false;

		cancelDeletion.cancelDeleteGroup.alpha = 1;
		cancelDeletion.cancelDeleteGroup.interactable = true;
		cancelDeletion.cancelDeleteGroup.blocksRaycasts = true;

	}
	//Called by CreateNewUser 
	public void ClickedUser(GameObject userObject)
	{

		//Changes userName in SaveLoad class to the text in the first Username slot
		saveLoad.userName = userObject.GetComponentInChildren<Text>().text;
		//Deletes and then saves the Users after deltetion
		saveLoad.Delete();
		foreach(User user in createUser.userNamesMenu)
		{

			if(userObject.GetComponentInChildren<Text>().text == user.getPlayerName())
			{

				Debug.Log("Deleting "+userObject.GetComponentInChildren<Text>().text);
				createUser.usernames.Remove(userObject.GetComponentInChildren<Text>().text);
				createUser.userNamesMenu.Remove(user);
				createUser.listOfUsers.Remove(userObject);
				Destroy (userObject);
				if(createUser.usernameNumb != 0)
					createUser.usernameNumb--;
				else
					createUser.usernameNumb = 4;
				createUser.userNumbTracker--;
				break;
			}

		}
		DeletionOver();

	}

	public void DeletionOver()
	{

		User tempUser = new User();
	
		foreach(User user in createUser.userNamesMenu)
		{
			Debug.Log(user.getPlayerName()+" "+user.getPlayerID()+" "+user.getPlayerLayer());
			if(user.getPlayerID() == 1 && user.getPlayerLayer() != 0)
			{

				//TODO This is broken..
				if(user.getPlayerID()+4 == tempUser.getPlayerID())
				{
					user.setLayer(user.getPlayerLayer()-1);
					user.setPlayerID(5);
				
				}

			}
			else if(user.getPlayerID() != 1 && user.getPlayerID() > tempUser.getPlayerID()+1)
				user.setPlayerID(user.getPlayerID()-1);
			else if(user.getPlayerID () != 1 && user.getPlayerID()+3 == tempUser.getPlayerID())
				user.setPlayerID(user.getPlayerID()-1);

			tempUser = user;

		}
		saveLoad.SaveUsers();
		createUser.userNamesMenu.Clear();
		foreach(GameObject user in createUser.listOfUsers)
			Destroy(user);
		createUser.listOfUsers.Clear();
		createUser.usernames.Clear();
		createUser.layer = 0;
		createUser.usernameNumb = 0;
		createUser.userNumbTracker = 0;
		saveLoad.LoadUsers();
		if(tempUser.getPlayerID() == 5 && createUser.layer > 0)
		{
			
			createUser.layer--;
			createUser.tempLayer = true;
			
		}
		saveLoad.SaveUsers();
		foreach(GameObject user in createUser.listOfUsers)
		{
			
			ColorBlock colorBlock = user.GetComponent<Button>().colors;
			colorBlock.normalColor = Color.black;
			user.GetComponent<Button>().colors = colorBlock;
			
		}
		Debug.Log("Deletion complete");

	}

}
