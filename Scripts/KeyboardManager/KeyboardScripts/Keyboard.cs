using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Keyboard {

	public static Color whiteCol = Color.white;
	public static Color inUseCol = new Color(0,45,178,255);

	//Removes the button within buttonList based on the tag
	public static void removeKeyboardKey(Button input)
	{
		
		input.GetComponent<Image>().color = whiteCol;
		Inputs.inputDict.Remove(input.tag);
		
	}

	public static void resetKeyboard()
	{
		foreach(Button key in AllKeys.allKeys)
			key.GetComponent<Image>().color = whiteCol;	
	}

	//Initial call to make another one below
	public static void setKeyboardBasedOnTags(Button buttonInput, Button buttonForTag, string keyCode,
	                                          string aType, string aName)
	{
		//Calls the remove option above
		removeKeyboardKey(buttonForTag);
		//Adds the previous button's tag, and the new button
		Inputs.inputDict.Add(buttonForTag.tag, new Inputs(keyCode, buttonForTag.tag, buttonInput, aType, aName));
		KeyBindings.colorKeyboard();
		for(int i = 0; i < InputManager.inputManagerList.Count; i++)
		{
			if(buttonInput.tag.Equals(InputManager.inputManagerList[i].Tag))
			{
				InputManager.inputManagerList[i].Key = Inputs.inputDict[buttonForTag.tag].getInputButton();
				InputManager.inputManagerList[i].Input = Inputs.inputDict[buttonForTag.tag].getInputKeyCode();
			}

		}
		
	}

	public static void setKeyboardBasedOnTags(Button buttonInput, string aTag, string keyCode,
	                                          string aType, string aName)
	{
	
		//Adds the previous button's tag, and the new button
		Inputs.inputDict.Add(aTag, new Inputs(keyCode, aTag, buttonInput, aType, aName));
		KeyBindings.colorKeyboard();
		for(int i = 0; i < InputManager.inputManagerList.Count; i++)
		{
			if(buttonInput.tag.Equals(InputManager.inputManagerList[i].Tag))
			{
				InputManager.inputManagerList[i].Key = Inputs.inputDict[aTag].getInputButton();
				InputManager.inputManagerList[i].Input = Inputs.inputDict[aTag].getInputKeyCode();
			}
			
		}
		
	}
	
/***********************************************************************************************************
 * 
 * The rest will be classes from here down 
 * 
***/

	public class KeyboardTags
	{

		public class TagsAndTypes
		{

			private string keyboardTag;
			private string keyboardType;

			public TagsAndTypes(string aTag, string aType)
			{

				keyboardTag = aTag;
				keyboardType = aType;

			}

			public string getKeyboardTag()
			{

				return keyboardTag;

			}

			public string getKeyboardType()
			{

				return keyboardType;

			}

		}

		public static Dictionary<string, TagsAndTypes> keyboardTagAndTypeList;

		public static void keyboardTagsAndTypes()
		{

			keyboardTagAndTypeList = new Dictionary<string, TagsAndTypes>();

			foreach(InputManager.INPUT_CLASS inputClass in InputManager.inputManagerList)
				keyboardTagAndTypeList.Add(inputClass.Name, new TagsAndTypes(inputClass.Tag, inputClass.Type));


		}
		
	}

	public class KeyBindings
	{

		public AllKeys allKeys;
		
		public static void DISTRIBUTE_KEYS(InputManager.INPUT_CLASS inputClass)
		{
			
			KEYS (inputClass.Tag, inputClass.Key, inputClass.Type, inputClass.Name);
			
		}
		
		public static void KEYS(string aTag, Button aButton, string aType, string aName)
		{
			
			aButton.tag = aTag;
			Inputs.inputDict.Add(aTag, new Inputs(aButton.name, aTag, aButton, aType, aName));
			colorKeyboard(aButton);
			
		}
		
		//For Inputs class
		public static void DEFAULT_KEYS(List<InputManager.INPUT_CLASS> inputManagerList)
		{
			
			//String = Tag; Inputs = an Instance of Inputs
			Inputs.inputDict = new Dictionary<string, Inputs>();

			for(int i = 0; i < inputManagerList.Count; i++)
				Inputs.inputDict.Add(inputManagerList[i].Tag, 
				                     new Inputs(inputManagerList[i].Input.ToString(), inputManagerList[i].Tag, 
												inputManagerList[i].Key, inputManagerList[i].Type,
				           						inputManagerList[i].Name));
			
			colorKeyboard();
			
		}

		public static void colorKeyboard()
		{
			
			foreach(KeyValuePair<string, Inputs> aButton in Inputs.inputDict)
				aButton.Value.getInputButton().GetComponent<Image>().color = Keyboard.inUseCol;
			
		}
		
		private static void colorKeyboard(Button aButton)
		{
			
			aButton.GetComponent<Image>().color = Keyboard.inUseCol;
			
		}

	}

}

