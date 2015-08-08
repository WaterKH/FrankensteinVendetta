using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class InputManager : MonoBehaviour {

	Inputs inputs = new Inputs();
	KeyboardUI keyboardUI = new KeyboardUI();
	public HoverKeyboard hoverKeyboard;
	public AllKeys allKeys;
	public SaveLoad saveLoad;
	public ButtonSerializable buttonSer = new ButtonSerializable();

	bool isOn;
	Button buttonInput;

	//TODO For testing purposes only!: Remove when done
	void Awake()
	{

		saveLoad.LoadKeyboard();

	}

	//Called by Default Button
	public void DEFAULT_LAYOUT()
	{

		KeyboardUI.resetKeyboard();
		Inputs.inputDict = new Dictionary<string, Inputs>();
		HoverKeyboard.hoverHelperText = new Dictionary<string, string>();
		AllKeys.legendList = new List<Button>();

		DEFAULT_LAYOUT(AllKeys.getButtons());
		
	}
	
	//Sets the keys to default
	public void DEFAULT_LAYOUT(List<Button> buttonList)
	{

		KeyboardTags.keyboardTags();
		DefaultKeyBindings.DEFAULT_KEYS(buttonList);
		DefaultKeyBindings.DEFAULT_HOVER_KEYS();
		allKeys.objectsForDefaultClass();
		
	}

	//Called for when a button is clicked on the keyboard
	public void setINDIVID_KEY(Button aButton)
	{

		//Button grabbed here for use in the Update method
		if(!aButton.tag.Equals("Untagged"))
		{

			buttonInput = Inputs.inputDict[aButton.tag].getInputButton();
			foreach(KeyValuePair<string, Inputs> input in Inputs.inputDict)
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
		else
			Debug.Log("Please choose a key already binded.");
	
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
	
					if(!Inputs.inputDict.ContainsKey(aButton.tag))
					{

						//If any button equals the key pressed by user..
						if(aButton.name.ToLower().Equals(setInput))
						{

							//Removes the current button (Got from when the player clicks the button above)
							KeyboardUI.removeKeyboardKey(buttonInput);
							//Gets the tag from buttonInput, button to add, String value of what was pressed
							Inputs.setInput(buttonInput, aButton, setInput.ToUpper());
							//Gets the button that was added above, and the tag from above
							KeyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag, setInput.ToUpper());
							//Sets the value of the hover input
							HoverHelperText.setHoverKeys(buttonInput.tag);
							//Causes the tool tip to disappear
							AllKeys.setLegendKey(buttonInput.tag, Inputs.inputDict[buttonInput.tag].getInputKeyCode().ToString());
							HoverHelperText.setLegendKeys(buttonInput.tag);
				
						}

					}
					
				}
				buttonInput.tag = "Untagged";
				hoverKeyboard.keyboardKeyboardExit();
				setInput = "";
				isOn = false;
				
			}
			
		}
		
	}

	public void setKey(Button aButtonInput, string anInput)
	{

		//Gets the tag from buttonInput, button to add, String value of what was pressed
		Inputs.setInput(aButtonInput, aButtonInput, anInput);
		//Gets the button that was added above, and the tag from above
		KeyboardUI.setKeyBoardBasedOnTags(Inputs.inputDict[aButtonInput.tag].getInputButton(), aButtonInput.tag,
		                                  Inputs.inputDict[aButtonInput.tag].getInputKeyCode().ToString());
		//Sets the value of the hover input
		HoverHelperText.setHoverKeys(aButtonInput.tag);
		AllKeys.setLegendKey(aButtonInput.tag, Inputs.inputDict[aButtonInput.tag].getInputKeyCode().ToString());
		HoverHelperText.setLegendKeys(aButtonInput.tag);

	}

	public static bool GetKey(string aKey)
	{

		return Input.GetKey(Inputs.inputDict[aKey].getInputKeyCode());

	}

	public static bool GetKeyDown(string aKey)
	{

		return Input.GetKeyDown(Inputs.inputDict[aKey].getInputKeyCode());
	
	}

	public static bool GetKeyUp(string aKey)
	{

		return Input.GetKeyUp(Inputs.inputDict[aKey].getInputKeyCode());

	}

	public static float GetAxis(string aKey)
	{
	
		if(Input.GetKey(Inputs.inputDict[aKey].getInputKeyCode()))
		{

			if(Inputs.inputDict[aKey].getInputKeyCode().ToString().Equals(
				Inputs.inputDict[KeyboardTags.moveForward].getInputKeyCode().ToString())
			   		||Inputs.inputDict[aKey].getInputKeyCode().ToString().Equals(
				Inputs.inputDict[KeyboardTags.moveRight].getInputKeyCode().ToString()))
			{

				return 1.0f;

			}
			else if(Inputs.inputDict[aKey].getInputKeyCode().ToString().Equals(
				Inputs.inputDict[KeyboardTags.moveBackward].getInputKeyCode().ToString())
			        || Inputs.inputDict[aKey].getInputKeyCode().ToString().Equals(
				Inputs.inputDict[KeyboardTags.moveLeft].getInputKeyCode().ToString()))
			{

				return -1.0f;

			}

		}

		return 0.0f;

	}

}
