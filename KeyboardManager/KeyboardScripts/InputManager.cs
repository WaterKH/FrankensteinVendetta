using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class InputManager : MonoBehaviour {

	public HoverKeyboard hoverKeyboard;
	public AllKeys allKeys;
	public SaveLoadKeyboard saveLoad;
	public ChangeHelpMenuText changeText;
	ButtonSerializable buttonSer = new ButtonSerializable();
	
	//!! Make sure that they correspond !!
	//!! THIS WILL BE EDITED IN THE INSPECTOR
	//This will be where you input in the inspector what names you want for your keys
	public List<string> INPUTS;
	//This will be where you add the buttons from the scene
	public List<Button> BUTTONS;
	public static List<Button> BUTTONS_STATIC;
	//This will be where you add your types/ classifications for each key (ie - moveForward = Movement, pause = Modification)
	public List<string> TYPES;
	//This will be where you add the button names for each key
	public List<string> NAMES;
	//!! THIS WILL BE EDITED IN THE INSPECTOR
	//!! Make sure that they correspond !!
	
	public static bool isOn;
	Button buttonInput;

	void Awake()
	{

		BUTTONS_STATIC = BUTTONS;

	}

	//Called by Default Button
	public void CONFIGURE_LAYOUT()
	{
		KeyboardUI.resetKeyboard();
		Inputs.inputDict = new Dictionary<string, Inputs>();
		HoverKeyboard.hoverHelperText = new Dictionary<string, string>();
		HoverKeyboard.legendText = new Dictionary<string, string>();
		AllKeys.legendList = new List<Button>();

		if(INPUTS.Count == BUTTONS.Count && INPUTS.Count > 0)
		{

			KeyboardTags.keyboardTagsList = new List<string>();

			for(int i = 0; i < INPUTS.Count; i++)
			{

				KeyboardTags.keyboardTagsList.Add(INPUTS[i]);
				KeyBindings.KEYS(INPUTS[i], BUTTONS[i]);
				KeyBindings.HOVER_KEYS(INPUTS[i], BUTTONS[i]);
				KeyBindings.LEGEND(INPUTS[i], TYPES[i]);
				AllKeys.INITIAL_LIST_LEGEND(NAMES[i], INPUTS[i]);

			}

		}
		else
		{
			Debug.Log("Inputs didn't match buttons or there was no user input..");
			DEFAULT_LAYOUT(AllKeys.getButtons());

		}
		
	}
	
	//Sets the keys to default
	private void DEFAULT_LAYOUT(List<Button> buttonList)
	{

		KeyboardTags.keyboardTags();
		KeyBindings.DEFAULT_KEYS(buttonList);
		KeyBindings.DEFAULT_HOVER_KEYS();
		AllKeys.INITIAL_LIST_LEGEND(buttonList);
		
	}

	//Called for when a button is clicked on the keyboard
	public void setINDIVID_KEY(Button aButton)
	{

		//Button grabbed here for use in the Update method
		if(!aButton.tag.Equals("Untagged"))
		{

			buttonInput = Inputs.inputDict[aButton.tag].getInputButton();
			Debug.Log("Key to be changed: "+buttonInput.name);
			foreach(KeyValuePair<string, Inputs> input in Inputs.inputDict)
			{

				if(buttonInput.tag.Equals(input.Key))
				{
					changeText.selectedText(buttonInput.name);
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
		if(!KeyboardUI.checkSpecialInput(buttonInput, changeText, hoverKeyboard))
		{
	
			//sets the string to what's pressed on the keyboard
			string setInput = Input.inputString;
			bool contained = false;
			foreach(KeyValuePair<string, Inputs> anInput in Inputs.inputDict)
			{
				
				if(anInput.Value.getInputButton().GetComponentInChildren<Text>().text.ToLower().Equals(setInput.ToLower()))
				{

					contained = true;
					isOn = false;
					changeText.changedText("This key has already been binded, choose another one");
					Debug.Log("This key has already been binded, choose another one.");
					break;
					
				}

			}

			if(!setInput.Equals("") && !contained)
			{

				foreach(Button aButton in AllKeys.getButtons())
				{
	
					//If any button equals the key pressed by user..
					if(aButton.name.ToLower().Equals(setInput))
					{
						changeText.changedText(aButton.name);
						//Removes the current button (Got from when the player clicks the button above)
						KeyboardUI.removeKeyboardKey(buttonInput);
						//Gets the tag from buttonInput, button to add, String value of what was pressed
						Inputs.setInput(buttonInput, aButton, setInput.ToUpper());
						//Gets the button that was added above, and the tag from above
						KeyboardUI.setKeyboardBasedOnTags(Inputs.inputDict[buttonInput.tag].getInputButton(), buttonInput.tag, setInput.ToUpper());
						//Sets the value of the hover input
						HoverHelperText.setHoverKeys(buttonInput.tag);
						//Causes the tool tip to disappear
						AllKeys.setLegendKey(buttonInput.tag, Inputs.inputDict[buttonInput.tag].getInputKeyCode().ToString());
						HoverHelperText.setLegendKeys(buttonInput.tag);
			
					}

				}
				buttonInput.tag = "Untagged";
				hoverKeyboard.keyboardKeyboardExit();
				setInput = "";
				isOn = false;
				
			}
			
		}
		
	}

	public void setKey(string anInput, Button aButtonInput)
	{

		//Gets the tag from buttonInput, button to add, String value of what was pressed
		Inputs.setInputFromData(anInput, aButtonInput);
		//Gets the button that was added above, and the tag from above
		KeyboardUI.setKeyboardBasedOnTags(Inputs.inputDict[aButtonInput.tag].getInputButton(), aButtonInput.tag,
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
