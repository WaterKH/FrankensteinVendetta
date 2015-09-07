using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class InputManager : MonoBehaviour {

	//TODO FIX ALL OF THE "" SET FOR TYPES
	//TODO What is anInput? Keycode Input or string Tag
	public HoverKeyboard hoverKeyboard;
	public AllKeys allKeys;
	public SaveLoadKeyboard saveLoadKey;
	public ChangeHelpMenuText changeText;
	ButtonSerializable buttonSer = new ButtonSerializable();

	public static bool isOn;
	Button buttonInput;

	public List<INPUT_CLASS> inputManagerList_FROM_INSPECTOR = new List<INPUT_CLASS>(1);
	public static List<INPUT_CLASS> inputManagerList;

	[System.Serializable]
	public class INPUT_CLASS_FOR_DATA_STORAGE
	{
		
		public KeyCode Input;
		public ButtonSerializable Key;
		public string Type;
		public string Tag;
		public string Name;
		
		public INPUT_CLASS_FOR_DATA_STORAGE(KeyCode anInput, ButtonSerializable aKey, string aType, string aTag, 
		                                    string aName)
		{
			
			Input = anInput;
			Key = aKey;
			Type = aType;
			Tag = aTag;
			Name = aName;
			
		}
		
	}
	
	[System.Serializable]
	public class INPUT_CLASS
	{
		
		public KeyCode Input;
		public Button Key;
		public string Type;
		public string Tag;
		public string Name;

		public INPUT_CLASS(KeyCode anInput, Button aKey, string aType, string aTag, string aName)
		{

			Input = anInput;
			Key = aKey;
			Type = aType;
			Tag = aTag;
			Name = aName;

		}
		
	}

	void Start()
	{

		//TODO Include a save function of the inputManagerList
		if (File.Exists (Application.persistentDataPath + "/KeyboardInfo.dat"))
			saveLoadKey.LoadKeyboard();
		else
		{
			inputManagerList = new List<INPUT_CLASS>();
			DEFAULT_LAYOUT();
		}

	}

	//Called by Default Button
	public void CONFIGURE_LAYOUT()
	{

		Keyboard.resetKeyboard();
		AllKeys.removeLegend();
		Inputs.inputDict = new Dictionary<string, Inputs>();
		AllKeys.legendList = new List<Button>();

		if(inputManagerList.Count > 0)
		{

			for(int i = 0; i < inputManagerList.Count; i++)
			{

				Keyboard.KeyboardTags.keyboardTagsAndTypes();
				Keyboard.KeyBindings.DISTRIBUTE_KEYS (inputManagerList[i]);
				AllKeys.INITIAL_LIST_LEGEND(inputManagerList[i].Name, inputManagerList[i].Tag);

			}

		}
		else
			Debug.Log("No user input located");
	
	}
	
	//Sets the keys to default
	public void DEFAULT_LAYOUT()
	{
		inputManagerList.Clear();
		foreach(INPUT_CLASS inputClass in inputManagerList_FROM_INSPECTOR)
		{
			INPUT_CLASS tempInputClass = new INPUT_CLASS(inputClass.Input, inputClass.Key,
			                                             inputClass.Type, inputClass.Tag,
			                                             inputClass.Name);
			inputManagerList.Add(tempInputClass);
		}
		CONFIGURE_LAYOUT();
		
	}

	//Called for when a button is clicked on the keyboard
	public void setINDIVID_KEY(Button aButton)
	{

		//Button grabbed here for use in the Update method
		if(!aButton.tag.Equals("Untagged"))
		{

			changeText.selectedText(aButton.name);
			buttonInput = Inputs.inputDict[aButton.tag].getInputButton();
			Debug.Log("Key to be changed: "+buttonInput.name);
			foreach(KeyValuePair<string, Inputs> input in Inputs.inputDict)
			{

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
		if(!SpecialInputCheck.checkSpecialInput(buttonInput, changeText, hoverKeyboard))
		{
	
			//sets the string to what's pressed on the keyboard
			string setInput = Input.inputString;
			bool contained = false;
			foreach(KeyValuePair<string, Inputs> anInput in Inputs.inputDict)
			{
				
				if(anInput.Value.getInputButton().GetComponentInChildren<Text>().text.ToLower().Equals(setInput.ToLower()))
				{

					changeText.changedText("This key has already been binded, please choose another one");
					contained = true;
					isOn = false;
					Debug.Log("This key has already been binded, choose another one.");
					break;
					
				}

			}

			if(!setInput.Equals("") && setInput.Length == 1 && !contained)
			{

				foreach(Button aButton in AllKeys.getButtons())
				{
	
					//If any button equals the key pressed by user..
					if(aButton.name.ToLower().Equals(setInput))
					{

						changeText.changedText(aButton.name);
						//TODO RENAME THESE VARS
						for(int i = 0; i < inputManagerList.Count; i++)
						{	
							if(inputManagerList[i].Tag.Equals(buttonInput.tag))
							{
								Keyboard.setKeyboardBasedOnTags(aButton, 
								                                buttonInput,
								                                aButton.name,
								                                inputManagerList[i].Type, 
								                                aButton.name);
								break;
							}
						}	
						AllKeys.setLegendKey(aButton.tag, aButton.name);
						saveLoadKey.hasSaved = false;
						break;
			
					}

				}
				buttonInput.tag = "Untagged";
				hoverKeyboard.keyboardKeyboardExit();
				setInput = "";
				isOn = false;
				
			}
			else if(setInput.Length > 1)
				Debug.Log("You pressed two keys..");
			
		}
		
	}
	
	public void setKey(InputManager.INPUT_CLASS inputClass)
	{

		//Gets the button that was added above, and the tag from above
		Keyboard.setKeyboardBasedOnTags(inputClass.Key, inputClass.Tag, inputClass.Input.ToString(), inputClass.Type,
		                                inputClass.Name);

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
	//TODO FIX THIS ASAP!!!!

	public static float GetAxis(string aKey)
	{
	
		if(Input.GetKey(Inputs.inputDict[aKey].getInputKeyCode()))
		{

			if(Inputs.inputDict[aKey].getInputTag().Equals("moveForward")
			   		||Inputs.inputDict[aKey].getInputTag().Equals("moveRight"))
			{

				return 1.0f;

			}
			else if(Inputs.inputDict[aKey].getInputTag().Equals("moveBackward")
			        || Inputs.inputDict[aKey].getInputTag().Equals("moveLeft"))
			{

				return -1.0f;

			}

		}

		return 0.0f;

	}

}
