using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class KeyboardUI {
	
	private Button keyOnBoard;
	private string keyTag;
	
	public static Dictionary<string, KeyboardUI> buttonList;
	
	public Color whiteCol = Color.white;
	public static Color inUseCol = new Color(0,45,178,255);
	
	//Default Constructor
	public KeyboardUI()
	{
		
		keyOnBoard = null;
		keyTag = "";
		
	}
	
	//Paramaterized Constructor
	public KeyboardUI(string aTag, Button aButton)
	{
		
		setKeyboardButton(aButton);
		setKeyTag(aTag);
		
	}
	
	
	//Mutators
	public void setKeyboardButton(Button aButton)
	{
		
		keyOnBoard = aButton;
		
	}
	
	public void setKeyTag(string aTag)
	{
		
		keyTag = aTag;
		
	}
	
	//Accessors
	public Button getKeyboardButton()
	{
		
		return keyOnBoard;
		
	}
	
	public string getTag()
	{
		
		return keyTag;
		
	}
	
	//Removes the button within buttonList based on the tag
	public void removeKeyboardKey(Button input)
	{
		
		input.GetComponent<Image>().color = whiteCol;
		buttonList.Remove(input.tag);
		
	}
	
	//Initial call to make another one below
	public void setKeyBoardBasedOnTags(Button input, string tagString)
	{
		
		//Calls the remove option above
		removeKeyboardKey(input);
		//Adds the previous button's tag, and the new button
		buttonList.Add(tagString, new KeyboardUI(tagString, input));
		setKeyboardBasedOnTags(input.GetComponent<Image>(), tagString);
		
	}
	
	//Changes the color of the button based on the tag
	private void setKeyboardBasedOnTags(Image input, string tagString)
	{
		
		switch(tagString)
		{
		case "moveForward":
			input.color = inUseCol;
			Debug.Log(tagString+" was recolored");
			break;
		case "moveBackward":
			input.color = inUseCol;
			Debug.Log(tagString+" was recolored");
			break;
		case "moveLeft":
			input.color = inUseCol;
			Debug.Log(tagString+" was recolored");
			break;
		case "moveRight":
			input.color = inUseCol;
			Debug.Log(tagString+" was recolored");
			break;
		case "leanLeft":
			input.color = inUseCol;
			Debug.Log(tagString+" was recolored");
			break;
		case "leanRight":
			input.color = inUseCol;
			Debug.Log(tagString+" was recolored");
			break;
		case "inventory":
			input.color = inUseCol;
			Debug.Log(tagString+" was recolored");
			break;
		case "inventorySecondary":
			input.color = inUseCol;
			Debug.Log(tagString+" was recolored");
			break;
		case "notes":
			input.color = inUseCol;
			Debug.Log(tagString+" was recolored");
			break;
		case "lightMatch":
			input.color = inUseCol;
			Debug.Log(tagString+" was recolored");
			break;
		case "action":
			input.color = inUseCol;
			Debug.Log(tagString+" was recolored");
			break;
		case "crouch":
			input.color = inUseCol;
			Debug.Log(tagString+" was recolored");
			break;
		case "run":
			input.color = inUseCol;
			Debug.Log(tagString+" was recolored");
			break;
		case "jump":
			input.color = inUseCol;
			Debug.Log(input.name);
			Debug.Log(tagString+" was recolored");
			break;
		case "pause":
			input.color = inUseCol;
			Debug.Log(tagString+" was recolored");
			break;
		case "pauseSecondary":
			input.color = inUseCol;
			Debug.Log(tagString+" was recolored");
			break;
		case "lookBehind":
			input.color = inUseCol;
			Debug.Log(tagString+" was recolored");
			break;
		default:
			Debug.Log("No tag could be found");
			input.color = whiteCol;
			break;
			
		}
		
	}
	
}
