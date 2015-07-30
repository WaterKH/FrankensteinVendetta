using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class KeyLevels : MonoBehaviour {

	public Color disabledColor;
	public Color enabledColor;

	public Button movement;
	public Button modification;
	public Button action;

	bool movementBool;
	bool modificationBool;
	bool actionBool;

	public CanvasGroup movementGroup;
	public CanvasGroup modificationGroup;
	public CanvasGroup actionGroup;

	public static List<Button> legendList;

	public static void setLegendKey(string buttonTag, string keyCode)
	{

		foreach(Button aLegendButton in legendList)
		{
			
			if(aLegendButton.tag.Equals(buttonTag))
				aLegendButton.GetComponentInChildren<Text>().text = keyCode;
			
		}

	}

	public void changeToLevel(Button aButton)
	{

		if(aButton.name.Equals(movement.name))
		{
			movement.GetComponentInChildren<Text>().color = enabledColor;
			modification.GetComponentInChildren<Text>().color = disabledColor;
			action.GetComponentInChildren<Text>().color = disabledColor;
			movementBool = true;
			modificationBool = false;
			actionBool = false;

		}
		else if(aButton.name.Equals(modification.name))
		{
			movement.GetComponentInChildren<Text>().color = disabledColor;
			modification.GetComponentInChildren<Text>().color = enabledColor;
			action.GetComponentInChildren<Text>().color = disabledColor;
			movementBool = false;
			modificationBool = true;
			actionBool = false;

		}
		else if(aButton.name.Equals(action.name))
		{
			movement.GetComponentInChildren<Text>().color = disabledColor;
			modification.GetComponentInChildren<Text>().color = disabledColor;
			action.GetComponentInChildren<Text>().color = enabledColor;
			movementBool = false;
			modificationBool = false;
			actionBool = true;

		}

	}

	void Update()
	{

		if(movementBool)
		{

			movementGroup.interactable = true;
			movementGroup.blocksRaycasts = true;
			movementGroup.alpha = 1;

			modificationGroup.interactable = false;
			modificationGroup.blocksRaycasts = false;
			modificationGroup.alpha = 0;
			
			actionGroup.interactable = false;
			actionGroup.blocksRaycasts = false;
			actionGroup.alpha = 0;

		}
		else if(modificationBool)
		{

			movementGroup.interactable = false;
			movementGroup.blocksRaycasts = false;
			movementGroup.alpha = 0;

			modificationGroup.interactable = true;
			modificationGroup.blocksRaycasts = true;
			modificationGroup.alpha = 1;

			actionGroup.interactable = false;
			actionGroup.blocksRaycasts = false;
			actionGroup.alpha = 0;

		}
		else if(actionBool)
		{

			movementGroup.interactable = false;
			movementGroup.blocksRaycasts = false;
			movementGroup.alpha = 0;

			modificationGroup.interactable = false;
			modificationGroup.blocksRaycasts = false;
			modificationGroup.alpha = 0;
			
			actionGroup.interactable = true;
			actionGroup.blocksRaycasts = true;
			actionGroup.alpha = 1;

		}

	}

}
