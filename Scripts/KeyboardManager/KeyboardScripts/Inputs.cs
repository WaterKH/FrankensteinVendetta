using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

[Serializable]
public class Inputs {

	private KeyCode inputKeycode;
	private string inputTag;
	private Button inputButton;
	private string inputType;
	private string inputName;
	ButtonSerializable buttonSer = new ButtonSerializable();

	//Dictionary 
	//Key: Tags on Button   
	//Value: Inputs which contains: KeyCode string, Tags on Button, Button
	public static Dictionary<string, Inputs> inputDict;

	//Default Constructor
	public Inputs()
	{

		inputKeycode = KeyCode.None;
		inputTag = "untagged";
		inputButton = null;
		inputType = "untyped";
		inputName = "unnamed";

	}

	//Paramaterized Constructor
	public Inputs(string aKeycode, string aTag, Button aButton, string aType, string aName)
	{

		setInputKeyCode(aKeycode);
		setInputTag(aTag);
		setInputButton (aButton);
		setInputButtonTag(aTag);
		setInputType(aType);

	}

	//Overloaded - string value for button
	public Inputs(string aKeycode, string aTag, string buttonText, string aType, string aName)
	{

		setInputKeyCode(aKeycode);
		setInputTag(aTag);
		setInputButton(buttonSer.getButtonSer(buttonText, aTag));
		setInputButtonTag(aTag);
		setInputType(aType);
		setInputName(aName);

	}

	//Mutators
	//Parses the string to a keycode to be used as an Input
	public void setInputKeyCode(string anInput)
	{

		inputKeycode = (KeyCode)Enum.Parse(typeof(KeyCode), anInput);

	}

	public void setInputTag(string aTag)
	{

		inputTag = aTag;

	}

	public void setInputButton(Button aButton)
	{

		inputButton = aButton;

	}

	public void setInputButtonTag(string aTag)
	{

		inputButton.tag = aTag;

	}

	public void setInputType(string aType)
	{

		inputType = aType;

	}

	public void setInputName(string aName)
	{

		inputName = aName;

	}

	//Accessors
	public KeyCode getInputKeyCode()
	{

		return inputKeycode;

	}
	
	public string getInputTag()
	{

		return inputTag;

	}

	public Button getInputButton()
	{

		return inputButton;

	}

	public string getInputButtonTag()
	{

		return inputButton.tag;

	}

	public string getInputType()
	{

		return inputType;

	}

	public string getInputName()
	{

		return inputName;

	}

}
