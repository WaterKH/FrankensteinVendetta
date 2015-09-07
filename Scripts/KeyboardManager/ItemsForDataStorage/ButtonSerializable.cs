using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

[Serializable]
public class ButtonSerializable {
	
	public string buttonName;
	public string buttonTag;

	public ButtonSerializable()
	{

		buttonName = "noname";
		buttonTag = "notag";

	}

	public ButtonSerializable(string aName, string aTag)
	{

		setButtonSerName(aName);
		setButtonSerTag(aTag);

	}

	public void setButtonSerName(string aName)
	{

		buttonName = aName;

	}

	public void setButtonSerTag(string aTag)
	{

		buttonTag = aTag;

	}

	public ButtonSerializable returnButtonSer(Button aButton)
	{

		ButtonSerializable buttonSer = new ButtonSerializable(aButton.name, aButton.tag);
		return buttonSer;
	}

	public Button getButtonSer(string aName, string buttonTag)
	{

		for(int i = 0; i < AllKeys.allKeys.Count; i++)
		{

			if(AllKeys.allKeys[i].name.ToLower().Equals(aName.ToLower()))
			{

				AllKeys.allKeys[i].tag = buttonTag;
				return AllKeys.allKeys[i];

			}

		}

		Debug.Log("ERROR: " + aName + " " + buttonTag + " will return null value.");
		return null;

	}

}
