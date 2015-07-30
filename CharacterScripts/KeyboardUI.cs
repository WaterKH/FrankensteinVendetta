using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class KeyboardUI {
	
	private Button keyOnBoard;
	private string keyTag;
	
	public static Dictionary<string, KeyboardUI> buttonList;
	
	public static Color whiteCol = Color.white;
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
	public static void removeKeyboardKey(Button input)
	{
		
		input.GetComponent<Image>().color = whiteCol;
		buttonList.Remove(input.tag);
		
	}
	
	//Initial call to make another one below
	public static void setKeyBoardBasedOnTags(Button input, string tagString)
	{
		
		//Calls the remove option above
		removeKeyboardKey(input);
		//Adds the previous button's tag, and the new button
		buttonList.Add(tagString, new KeyboardUI(tagString, input));
		setKeyboardBasedOnTags(input.GetComponent<Image>(), tagString);
		
	}
	
	//Changes the color of the button based on the tag
	private static void setKeyboardBasedOnTags(Image input, string tagString)
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

	public static void resetKeyboard()
	{

		foreach(Button key in AllKeys.allKeys)
			key.GetComponent<Image>().color = whiteCol;

	}

	//This method takes care of all of the odd keys that don't return the KeyCode string
	public static bool checkSpecialInput(Button buttonInput, bool isOn)
	{
		bool foundKey = false;
		string key = "";
		string shortenedKey = "";
		int index = 0;
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			
			foundKey = true;
			key = "Tab";
			shortenedKey = "Tab";
			index = 51;
			
		}
		else if(Input.GetKeyDown(KeyCode.LeftAlt))
		{
			
			foundKey = true;
			key = "LeftAlt";
			shortenedKey = "L Alt";
			index = 54;
			
		}
		else if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			
			foundKey = true;
			key = "LeftShift";
			shortenedKey = "L Shift";
			index = 49;
			
		}
		else if(Input.GetKeyDown(KeyCode.RightAlt))
		{
			
			foundKey = true;
			key = "RightAlt";
			shortenedKey = "R Alt";
			index = 57;
			
		}
		else if(Input.GetKeyDown(KeyCode.RightShift))
		{
			
			foundKey = true;
			key = "RightShift";
			shortenedKey = "R Shift";
			index = 48;
			
		}
		else if(Input.GetKeyDown(KeyCode.LeftControl))
		{
			
			foundKey = true;
			key = "LeftControl";
			shortenedKey = "L Control";
			index = 55;
			
		}
		else if(Input.GetKeyDown(KeyCode.Backspace))
		{
			
			foundKey = true;
			key = "Backspace";
			shortenedKey = "Backspace";
			index = 43;
			
		}
		else if(Input.GetKeyDown(KeyCode.Space))
		{
			
			foundKey = true;
			key = "Space";
			shortenedKey = "Space";
			index = 56;
			
		}
		else if(Input.GetKeyDown(KeyCode.Escape))
		{
			
			foundKey = true;
			key = "Escape";
			shortenedKey = "Escape";
			index = 53;
			
		}
		else if(Input.GetKeyDown(KeyCode.CapsLock))
		{
			
			foundKey = true;
			key = "CapsLock";
			shortenedKey = "C Lock";
			index = 50;
			
		}
		else if(Input.GetKeyDown(KeyCode.Semicolon))
		{
			
			foundKey = true;
			key = "Semicolon";
			shortenedKey = "Semicolon";
			index = 26;
			
		}
		else if(Input.GetKeyDown(KeyCode.Quote))
		{
			
			foundKey = true;
			key = "Quote";
			shortenedKey = "Quote";
			index = 27;
			
		}
		else if(Input.GetKeyDown(KeyCode.LeftBracket))
		{
			
			foundKey = true;
			key = "LeftBracket";
			shortenedKey = "L Bracket";
			index = 28;
			
		}
		else if(Input.GetKeyDown(KeyCode.RightBracket))
		{
			
			foundKey = true;
			key = "RightBracket";
			shortenedKey = "R Bracket";
			index = 29;
			
		}
		else if(Input.GetKeyDown(KeyCode.Backslash))
		{
			
			foundKey = true;
			key = "Backslash";
			shortenedKey = "Backslash";
			index = 42;
			
		}
		else if(Input.GetKeyDown(KeyCode.Slash))
		{
			
			foundKey = true;
			key = "Slash";
			shortenedKey = "Slash";
			index = 47;
			
		}
		else if(Input.GetKeyDown(KeyCode.Period))
		{
			
			foundKey = true;
			key = "Period";
			shortenedKey = "Period";
			index = 46;
			
		}
		else if(Input.GetKeyDown(KeyCode.Equals))
		{
			
			foundKey = true;
			key = "Equals";
			shortenedKey = "Equals";
			index = 41;
			
		}
		else if(Input.GetKeyDown(KeyCode.BackQuote))
		{
			
			foundKey = true;
			key = "BackQuote";
			shortenedKey = "BackQuote";
			index = 52;
			
		}
		else if(Input.GetKeyDown(KeyCode.Return))
		{
			
			foundKey = true;
			key = "Return";
			shortenedKey = "Return";
			index = 44;
			
		}
		else if(Input.GetKeyDown(KeyCode.Minus))
		{
			
			foundKey = true;
			key = "Minus";
			shortenedKey = "Minus";
			index = 40;
			
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			
			foundKey = true;
			key = "RightArrow";
			shortenedKey = "R Arrow";
			index = 60;
			
		}
		else if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			
			foundKey = true;
			key = "LeftArrow";
			shortenedKey = "L Arrow";
			index = 61;
			
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			
			foundKey = true;
			key = "DownArrow";
			shortenedKey = "D Arrow";
			index = 59;
			
		}
		else if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			
			foundKey = true;
			key = "UpArrow";
			shortenedKey = "U Arrow";
			index = 58;
			
		}
		else if(Input.GetKeyDown(KeyCode.Comma))
		{
			
			
			foundKey = true;
			key = "Comma";
			shortenedKey = "Comma";
			index = 45;
			
		}
		
		if(foundKey)
		{

			removeKeyboardKey(buttonInput);
			Inputs.setInput(buttonInput, AllKeys.allKeys[index], key);
			setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			HoverHelperText.setHoverKeys(buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, shortenedKey);
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		
		return false;
		
	}
	
}
