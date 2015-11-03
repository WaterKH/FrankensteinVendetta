//On ScriptHolder
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DeleteUser : MonoBehaviour {
	
	//Script instances
	public CreateNewUser createUser;
	public SaveLoad saveLoad;
	public PageFlipping flipPage;
	public CancelDeletion cancelDeletion;

	public Button deleteButton;
	public CanvasGroup deleteCanvas;
	public bool remove;
	int index = 0;

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
		foreach(User user in createUser.listOfTypeUSERS)
		{

			if(userObject.GetComponentInChildren<Text>().text == user.getPlayerName())
			{
				Debug.Log("Deleting "+userObject.GetComponentInChildren<Text>().text);
				index = createUser.listOfUsers.IndexOf(userObject);
				createUser.listOfUsers.Remove(userObject);
				createUser.listOfTypeUSERS.Remove(user);
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

		int tempPlacementIndex = index;
		Debug.Log(tempPlacementIndex);
		bool ableToRun = true;
		for(int i = index; i < createUser.listOfUsers.Count; i++)
		{
			ableToRun = true;
			if(tempPlacementIndex > 5)
			{
				Debug.Log(tempPlacementIndex);
				tempPlacementIndex -= 5;
				--i;
				ableToRun = false;
			}
			else if(tempPlacementIndex == 5)
				tempPlacementIndex = 0;

			if(ableToRun)
			{
				if(createUser.listOfTypeUSERS[i].getPlayerID() == 1)
				{
					createUser.listOfTypeUSERS[i].setLayer(createUser.listOfTypeUSERS[i].getPlayerLayer() - 1);
					createUser.listOfTypeUSERS[i].setPlayerID(5);
				}
				else
				{
					createUser.listOfTypeUSERS[i].setPlayerID(createUser.listOfTypeUSERS[i].getPlayerID() - 1);
				}

				createUser.listOfUsers[i].GetComponent<RectTransform>().anchoredPosition = 
					createUser.userPlacements[tempPlacementIndex].anchoredPosition;

				tempPlacementIndex++;
			}

		}

		createUser.layer = (createUser.listOfUsers.Count - 1) / 5;
		Debug.Log("Users: " + createUser.listOfUsers.Count);
		Debug.Log("Layer: " + createUser.layer);
		flipPage.De_ActivateUsers();
		saveLoad.SaveUsers();

		Debug.Log("Deletion complete");

	}

}
