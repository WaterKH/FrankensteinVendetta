using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

[Serializable]
public class Inputs {

	
	//Mouse click1 will be to use what is set in inventory to your main click
	//Mouse click2 stifle breath
	private KeyCode inputName;
	private string inputTag;
	private Button inputButton;

	ButtonSerializable buttonSer = new ButtonSerializable();

	//Dictionary 
	//Key: Tags on Button   
	//Value: Inputs which contains: KeyCode string, Tags on Button, Button
	public static Dictionary<string, Inputs> inputDict;

	//Default Constructor
	public Inputs()
	{

		inputName = KeyCode.None;
		inputTag = "";
		inputButton = null;

	}

	//Paramaterized Constructor
	public Inputs(string anInput, string aTag, Button aButton)
	{

		setInputKeyCode(anInput);
		setInputTag(aTag);
		setInputButton (aButton);
		setInputButtonTag(aTag);

	}

	//Overloaded
	public Inputs(string anInput, string aTag, string buttonText)
	{

		setInputKeyCode(anInput);
		setInputTag(aTag);
		setInputButton(buttonSer.getButtonSer(buttonText, aTag));
		setInputButtonTag(aTag);


	}

	//Mutators
	//Parses the string to a keycode to be used as an Input
	public void setInputKeyCode(string anInput)
	{

		inputName = (KeyCode)Enum.Parse(typeof(KeyCode), anInput);

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

	//Accessors
	public KeyCode getInputKeyCode()
	{

		return inputName;

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

	//Called from SaveLoad
	public static void setInputFromData(string aKey, Button aButton)
	{

		Inputs inputForDict = new Inputs(aKey, aButton.tag, aButton);
		inputDict.Add(inputForDict.getInputTag(), inputForDict);

	}

	//First argument will be the previous tag to carry over, buttonForInput will be the buton to change to,
	//aKey will be which key button on keyboard to replace with
	public static void setInput(Button buttonForTag, Button buttonForInput, string aKey)
	{
	
		Inputs inputForDict = new Inputs(aKey, buttonForTag.tag, buttonForInput);
		inputDict.Add(inputForDict.getInputTag(), inputForDict);
		Debug.Log ("Key to change to: "+inputDict[inputForDict.getInputTag()].getInputKeyCode().ToString());

	}

	//Removes the previous button
	private static void removeInput(Button anInput)
	{

		inputDict.Remove(anInput.tag);

	}

}
