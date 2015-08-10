using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

[Serializable]
public class ButtonSerializable {

	public string buttonText;

	public ButtonSerializable()
	{

		buttonText = "";

	}

	public ButtonSerializable(string aText)
	{

		setButtonSer(aText);

	}

	public void setButtonSer(string aText)
	{

		buttonText = aText;

	}

	public string returnButtonText(Button aButton)
	{

		return aButton.GetComponentInChildren<Text>().text;

	}

	public Button getButtonSer(string aName, string buttonTag)
	{
	
		for(int i = 0; i < AllKeys.allKeys.Count; i++)
		{

			if(AllKeys.allKeys[i].name.ToLower().Equals(aName.ToLower()))
			{
				Debug.Log(AllKeys.allKeys[i].GetComponentInChildren<Text>().text);
				AllKeys.allKeys[i].tag = buttonTag;
				return AllKeys.allKeys[i];

			}

		}
		Debug.Log(aName + " " + buttonTag);
		return null;

	}

}
