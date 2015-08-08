using UnityEngine;
using System.Collections;

public class ChangeUI : MonoBehaviour {

	public CanvasGroup UIGroup;
	public CanvasGroup NonUIGroup;

	public void changeToUI()
	{

		UIGroup.alpha = 1;
		UIGroup.interactable = true;
		UIGroup.blocksRaycasts = true;

		NonUIGroup.alpha = 0;
		NonUIGroup.interactable = false;
		NonUIGroup.blocksRaycasts = false;
		
	}

	public void changeToNonUI()
	{
		
		UIGroup.alpha = 0;
		UIGroup.interactable = false;
		UIGroup.blocksRaycasts = false;
		
		NonUIGroup.alpha = 1;
		NonUIGroup.interactable = true;
		NonUIGroup.blocksRaycasts = true;
		
	}

}
