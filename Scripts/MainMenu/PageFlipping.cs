using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PageFlipping : MonoBehaviour {

	public CreateNewUser createUser;
	public Button flipBack;
	public Button flipForward;

	public int currLayer = 0;

	public void FlipPageBack()
	{

		currLayer--;
		De_ActivateUsers();

	}

	public void FlipPageForward()
	{
		
		currLayer++;
		De_ActivateUsers();
		
	}

	public void De_ActivateUsers()
	{
		for(int i = 0; i < createUser.userNamesMenu.Count; i++)
		{

			if(createUser.userNamesMenu[i].getPlayerLayer() != currLayer)
			{

				createUser.listOfUsers[i].GetComponent<CanvasGroup>().alpha = 0;
				createUser.listOfUsers[i].GetComponent<CanvasGroup>().interactable = false;
				createUser.listOfUsers[i].GetComponent<CanvasGroup>().blocksRaycasts = false;


			}
			else
			{

				createUser.listOfUsers[i].GetComponent<CanvasGroup>().alpha = 1;
				createUser.listOfUsers[i].GetComponent<CanvasGroup>().interactable = true;
				createUser.listOfUsers[i].GetComponent<CanvasGroup>().blocksRaycasts = true;

			}
				
		}

	}

	// Update is called once per frame
	void Update () {

		if(currLayer <= 0)
			flipBack.interactable = false;
		else
			flipBack.interactable = true;
		if(currLayer == createUser.layer)
			flipForward.interactable = false;
		else
			flipForward.interactable = true;
		if(currLayer > createUser.layer)
			FlipPageBack();
		 

	}

}
