﻿using UnityEngine;
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
		DefaultKeyBindings.DEFAULT_HOVER_KEYS();
		DefaultKeyBindings.DEFAULT_LIST_FOR_LEGEND();

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
		if(!KeyboardUI.checkSpecialInput(buttonInput, isOn))
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
						KeyboardUI.removeKeyboardKey(buttonInput);
						//Gets the tag from buttonInput, button to add, String value of what was pressed
						Inputs.setInput(buttonInput, aButton, setInput.ToUpper());
						//Gets the button that was added above, and the tag from above
						KeyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag);
						//Sets the value of the hover input
						HoverHelperText.setHoverKeys(buttonInput.tag);
						HoverKeyboard.keyboardKeyboardExit();
						KeyLevels.setLegendKey(buttonInput.tag, Inputs.inputDict[buttonInput.tag].getInputKeyCode().ToString());
						HoverHelperText.setLegendKeys(buttonInput.tag);

					}
					
				}
				setInput = "";
				isOn = false;
				
			}
			
		}
		
	}

}