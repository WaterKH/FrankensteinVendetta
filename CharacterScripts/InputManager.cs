using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class InputManager : MonoBehaviour {

	Inputs inputs = new Inputs();
	KeyboardUI keyboardUI = new KeyboardUI();
	public HoverKeyboard hoverKeyboard;

	bool isOn;
	Button buttonInput;

	void Start()
	{
	
		DEFAULT_LAYOUT(AllKeys.getButtons());

	}

	//Called for when a button is clicked on the keyboard
	public void setINDIVID_KEY(Button aButton)
	{

		//Button grabbed here for use in the Update method
		buttonInput = aButton;
		foreach(KeyValuePair<string, KeyboardUI> input in KeyboardUI.buttonList)
		{

			//If the button clicked is in my button list I can continue
			if(buttonInput.tag.Equals(input.Key))
			{
				isOn = true;
				break;
			}
			
		}
		if(!isOn)
			Debug.Log("Please choose a key already binded.");

	}

	//Called by Default Button
	public void DEFAULT_LAYOUT()
	{

		DEFAULT_LAYOUT(AllKeys.getButtons());

	}

	//Sets the keys to default
	public void DEFAULT_LAYOUT(List<Button> buttonList)
	{

		DefaultKeyBindings.DEFAULT_KEYS(buttonList);
		DefaultKeyBindings.DEFAULT_KEYBOARD(buttonList);

	}

	void Update()
	{

		if(isOn)
		{
			
			setKey ();

		}

	}

	/*
	 * 
	 * Code below changes the keyboard and input
	 * 
	 */

	private void setKey()
	{
		
		//Checks the above method for special cases
		if(!checkSpecialInput())
		{
			
			//sets the string to what's pressed on the keyboard
			string setInput = Input.inputString;
			if(!setInput.Equals(""))
			{
			
				foreach(Button aButton in AllKeys.getButtons())
				{
					
					//If any button equals the key pressed by user..
					if(aButton.name.ToLower().Equals(setInput))
					{
						//Removes the current button (Got from when the player clicks the button above)
						keyboardUI.removeKeyboardKey(buttonInput);
						//Gets the tag from buttonInput, button to add, String value of what was pressed
						inputs.setInput(buttonInput, aButton, setInput.ToUpper());
						//Gets the button that was added above, and the tag from above
						keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
						//Sets the value of the hover input
						HoverHelperText.setHoverKeys(buttonInput.tag);
						hoverKeyboard.keyboardKeyboardExit();
						KeyLevels.setLegendKey(buttonInput.tag, Inputs.inputDict[buttonInput.tag].getInputKeyCode().ToString());
						HoverHelperText.setLegendKeys(buttonInput.tag);

					}
					
				}
				setInput = "";
				isOn = false;
				
			}
			
		}
		
	}

	//This method takes care of all of the odd keys that don't return the KeyCode string
	public bool checkSpecialInput()
	{

		if(Input.GetKeyDown(KeyCode.Tab))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[51], "Tab");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			KeyLevels.setLegendKey(buttonInput.tag, "Tab");
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKeyDown(KeyCode.LeftAlt))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[54], "LeftAlt");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "L Alt");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKeyDown(KeyCode.LeftShift))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[49], "LeftShift");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "L Shift");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKeyDown(KeyCode.RightAlt))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[57], "RightAlt");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "R Alt");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKeyDown(KeyCode.RightShift))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[48], "RightShift");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "R Shift");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKeyDown(KeyCode.LeftControl))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[55], "LeftControl");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "L Control");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKeyDown(KeyCode.Backspace))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[43], "Backspace");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "Backspace");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKeyDown(KeyCode.Space))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[56], "Space");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "Space");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKey(KeyCode.Escape))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[53], "Escape");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "Escape");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKey(KeyCode.CapsLock))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[50], "CapsLock");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "C Lock");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;

		}
		else if(Input.GetKey(KeyCode.Semicolon))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[26], "Semicolon");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "Semicolon");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKey(KeyCode.Quote))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[27], "Quote");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "Quote");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKey(KeyCode.LeftBracket))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[28], "LeftBracket");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "L Bracket");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKey(KeyCode.RightBracket))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[29], "RightBracket");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "R Bracket");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKey(KeyCode.Backslash))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[42], "Backslash");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "Backslash");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKey(KeyCode.Slash))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[47], "Slash");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "Slash");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKey(KeyCode.Period))
		{
		
			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[46], "Period");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "Period");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKey(KeyCode.Equals))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[41], "Equals");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "Equals");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKey(KeyCode.BackQuote))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[52], "BackQuote");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "BackQuote");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKey(KeyCode.Return))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[44], "Return");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "Return");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKey(KeyCode.Minus))
		{
		
			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[40], "Minus");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "Dash");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[60], "RightArrow");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "R Arrow");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKey(KeyCode.LeftArrow))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[61], "LeftArrow");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "L Arrow");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKey(KeyCode.DownArrow))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[59], "DownArrow");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "D Arrow");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		else if(Input.GetKey(KeyCode.UpArrow))
		{

			keyboardUI.removeKeyboardKey(buttonInput);
			inputs.setInput(buttonInput, AllKeys.allKeys[58], "UpArrow");
			keyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
			KeyLevels.setLegendKey(buttonInput.tag, "U Arrow");
			HoverHelperText.setHoverKeys(buttonInput.tag);
			hoverKeyboard.keyboardKeyboardExit();
			HoverHelperText.setLegendKeys(buttonInput.tag);
			isOn = false;
			return true;
			
		}
		
		return false;
		
	}

}
