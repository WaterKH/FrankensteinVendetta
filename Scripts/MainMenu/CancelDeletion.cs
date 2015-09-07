using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CancelDeletion : MonoBehaviour {

	public GameObject deleteButton;
	public DeleteUser deleteUser;
	public CreateNewUser createUser;

	public CanvasGroup cancelDeleteGroup;
	public GameObject cancelDeleteButton;

	public void DeletionCancelation()
	{

		deleteUser.DeletionOver();
		deleteUser.remove = false;
		foreach(GameObject user in createUser.listOfUsers)
		{
			
			ColorBlock colorBlock = user.GetComponent<Button>().colors;
			colorBlock.normalColor = Color.white;
			user.GetComponent<Button>().colors = colorBlock;
			
		}
		
		deleteUser.deleteCanvas.alpha = 1;
		deleteUser.deleteCanvas.interactable = true;
		deleteUser.deleteCanvas.blocksRaycasts = true;
		
		cancelDeleteGroup.alpha = 0;
		cancelDeleteGroup.interactable = false;
		cancelDeleteGroup.blocksRaycasts = false;

	}

}
