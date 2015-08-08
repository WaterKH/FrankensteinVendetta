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

	public Button getButtonSer(string aText, string buttonTag)
	{
	
		for(int i = 0; i < AllKeys.allKeys.Count; i++)
		{

			if(AllKeys.allKeys[i].GetComponentInChildren<Text>().text.Equals(aText))
			{
				Debug.Log(buttonTag);
				AllKeys.allKeys[i].tag = buttonTag;
				return AllKeys.allKeys[i];

			}

		}

		return null;

	}

}
