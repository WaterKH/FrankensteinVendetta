using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DefaultKeyBindings {

	public AllKeys allKeys;

	//For Inputs class
	public static void DEFAULT_KEYS(List<Button> buttonList)//allKeys.getButtons(); <-- Gets all keys
	{

		//String = Tag; Inputs = an Instance of Inputs
		Inputs.inputDict = new Dictionary<string, Inputs>();

		Inputs.inputDict.Add(KeyboardTags.moveForward, new Inputs("W", KeyboardTags.moveForward, buttonList[2]));
		Inputs.inputDict.Add(KeyboardTags.moveBackward, new Inputs("S", KeyboardTags.moveBackward, buttonList[11]));
		Inputs.inputDict.Add(KeyboardTags.moveLeft, new Inputs("A", KeyboardTags.moveLeft, buttonList[10]));
		Inputs.inputDict.Add(KeyboardTags.moveRight, new Inputs("D", KeyboardTags.moveRight, buttonList[12]));
		Inputs.inputDict.Add(KeyboardTags.leanLeft, new Inputs("Q", KeyboardTags.leanLeft, buttonList[1]));
		Inputs.inputDict.Add(KeyboardTags.leanRight, new Inputs("E", KeyboardTags.leanRight, buttonList[3]));
		Inputs.inputDict.Add(KeyboardTags.action, new Inputs("R", KeyboardTags.action, buttonList[4]));
		Inputs.inputDict.Add(KeyboardTags.lightMatch, new Inputs("F", KeyboardTags.lightMatch, buttonList[13]));
		Inputs.inputDict.Add(KeyboardTags.notes, new Inputs("C", KeyboardTags.notes, buttonList[21]));
		Inputs.inputDict.Add(KeyboardTags.lookBehind, new Inputs("V", KeyboardTags.lookBehind, buttonList[22]));
		Inputs.inputDict.Add(KeyboardTags.inventory, new Inputs("Tab", KeyboardTags.inventory, buttonList[51]));
		Inputs.inputDict.Add(KeyboardTags.inventorySecondary, new Inputs("I", KeyboardTags.inventorySecondary, buttonList[8]));
		Inputs.inputDict.Add(KeyboardTags.pause, new Inputs("Escape", KeyboardTags.pause, buttonList[53]));
		Inputs.inputDict.Add(KeyboardTags.pauseSecondary, new Inputs("P", KeyboardTags.pauseSecondary, buttonList[6]));
		Inputs.inputDict.Add(KeyboardTags.run, new Inputs("LeftShift", KeyboardTags.run, buttonList[49]));
		Inputs.inputDict.Add(KeyboardTags.crouch, new Inputs("LeftControl", KeyboardTags.crouch, buttonList[55]));
		Inputs.inputDict.Add(KeyboardTags.jump, new Inputs("Space", KeyboardTags.jump, buttonList[56]));

	}

	//TODO Do we need both an inputDict and a buttonList, seems like they are acting the same way
	//For KeyboardUI class
	public static void DEFAULT_KEYBOARD(List<Button> listOfButtons)//allKeys.getButtons(); <-- Gets all keys
	{
	
		//String = Tag; Button = Able to change; But set through a list
		KeyboardUI.buttonList = new Dictionary<string, KeyboardUI>();
		
		KeyboardUI.buttonList.Add(KeyboardTags.moveForward, new KeyboardUI(KeyboardTags.moveForward, listOfButtons[2]));
		KeyboardUI.buttonList.Add(KeyboardTags.moveBackward, new KeyboardUI(KeyboardTags.moveBackward, listOfButtons[11]));
		KeyboardUI.buttonList.Add(KeyboardTags.moveLeft, new KeyboardUI(KeyboardTags.moveLeft, listOfButtons[10]));
		KeyboardUI.buttonList.Add(KeyboardTags.moveRight, new KeyboardUI(KeyboardTags.moveRight, listOfButtons[12]));
		KeyboardUI.buttonList.Add(KeyboardTags.leanLeft, new KeyboardUI(KeyboardTags.leanLeft, listOfButtons[1]));
		KeyboardUI.buttonList.Add(KeyboardTags.leanRight, new KeyboardUI(KeyboardTags.leanRight, listOfButtons[3]));
		KeyboardUI.buttonList.Add(KeyboardTags.action, new KeyboardUI(KeyboardTags.action, listOfButtons[4]));
		KeyboardUI.buttonList.Add(KeyboardTags.lightMatch, new KeyboardUI(KeyboardTags.lightMatch, listOfButtons[13]));
		KeyboardUI.buttonList.Add(KeyboardTags.notes, new KeyboardUI(KeyboardTags.notes, listOfButtons[21]));
		KeyboardUI.buttonList.Add(KeyboardTags.lookBehind, new KeyboardUI(KeyboardTags.lookBehind, listOfButtons[22]));
		KeyboardUI.buttonList.Add(KeyboardTags.inventory, new KeyboardUI(KeyboardTags.inventory, listOfButtons[51]));
		KeyboardUI.buttonList.Add(KeyboardTags.inventorySecondary, new KeyboardUI(KeyboardTags.inventorySecondary, listOfButtons[8]));
		KeyboardUI.buttonList.Add(KeyboardTags.pause, new KeyboardUI(KeyboardTags.pause, listOfButtons[53]));
		KeyboardUI.buttonList.Add(KeyboardTags.pauseSecondary, new KeyboardUI(KeyboardTags.pauseSecondary, listOfButtons[6]));
		KeyboardUI.buttonList.Add(KeyboardTags.run, new KeyboardUI(KeyboardTags.run, listOfButtons[49]));
		KeyboardUI.buttonList.Add(KeyboardTags.crouch, new KeyboardUI(KeyboardTags.crouch, listOfButtons[55]));
		KeyboardUI.buttonList.Add(KeyboardTags.jump, new KeyboardUI(KeyboardTags.jump, listOfButtons[56]));
		
		foreach(KeyValuePair<string, KeyboardUI> aButton in KeyboardUI.buttonList)
			aButton.Value.getKeyboardButton().GetComponent<Image>().color = KeyboardUI.inUseCol;
		
	}

	//For Hover Classes
	public static void DEFAULT_HOVER_KEYS()
	{

		//String = Tag; String = Keycode
		HoverKeyboard.hoverHelperText = new Dictionary<string, string>();
	
		HoverKeyboard.hoverHelperText.Add(KeyboardTags.moveForward, Inputs.inputDict[KeyboardTags.moveForward].getInputKeyCode().ToString());
		HoverKeyboard.hoverHelperText.Add(KeyboardTags.moveBackward, Inputs.inputDict[KeyboardTags.moveBackward].getInputKeyCode().ToString());
		HoverKeyboard.hoverHelperText.Add(KeyboardTags.moveLeft, Inputs.inputDict[KeyboardTags.moveLeft].getInputKeyCode().ToString());
		HoverKeyboard.hoverHelperText.Add(KeyboardTags.moveRight, Inputs.inputDict[KeyboardTags.moveRight].getInputKeyCode().ToString());
		HoverKeyboard.hoverHelperText.Add(KeyboardTags.leanLeft, Inputs.inputDict[KeyboardTags.leanLeft].getInputKeyCode().ToString());
		HoverKeyboard.hoverHelperText.Add(KeyboardTags.leanRight, Inputs.inputDict[KeyboardTags.leanRight].getInputKeyCode().ToString());
		HoverKeyboard.hoverHelperText.Add(KeyboardTags.action, Inputs.inputDict[KeyboardTags.action].getInputKeyCode().ToString());
		HoverKeyboard.hoverHelperText.Add(KeyboardTags.lightMatch, Inputs.inputDict[KeyboardTags.lightMatch].getInputKeyCode().ToString());
		HoverKeyboard.hoverHelperText.Add(KeyboardTags.notes, Inputs.inputDict[KeyboardTags.notes].getInputKeyCode().ToString());
		HoverKeyboard.hoverHelperText.Add(KeyboardTags.lookBehind, Inputs.inputDict[KeyboardTags.lookBehind].getInputKeyCode().ToString());
		HoverKeyboard.hoverHelperText.Add(KeyboardTags.inventory, Inputs.inputDict[KeyboardTags.inventory].getInputKeyCode().ToString());
		HoverKeyboard.hoverHelperText.Add(KeyboardTags.inventorySecondary, Inputs.inputDict[KeyboardTags.inventorySecondary].getInputKeyCode().ToString());
		HoverKeyboard.hoverHelperText.Add(KeyboardTags.pause, Inputs.inputDict[KeyboardTags.pause].getInputKeyCode().ToString());
		HoverKeyboard.hoverHelperText.Add(KeyboardTags.pauseSecondary, Inputs.inputDict[KeyboardTags.pauseSecondary].getInputKeyCode().ToString());
		HoverKeyboard.hoverHelperText.Add(KeyboardTags.run, Inputs.inputDict[KeyboardTags.run].getInputKeyCode().ToString());
		HoverKeyboard.hoverHelperText.Add(KeyboardTags.crouch, Inputs.inputDict[KeyboardTags.crouch].getInputKeyCode().ToString());
		HoverKeyboard.hoverHelperText.Add(KeyboardTags.jump, Inputs.inputDict[KeyboardTags.jump].getInputKeyCode().ToString());
		
		DEFAULT_LEGEND();
		
	}
	
	public static void DEFAULT_LEGEND()
	{

		//String = Tag; String = Sort type
		HoverKeyboard.legendText = new Dictionary<string, string>();
		
		HoverKeyboard.legendText.Add(KeyboardTags.moveForward, KeyboardTags.Movement);
		HoverKeyboard.legendText.Add(KeyboardTags.moveBackward, KeyboardTags.Movement);
		HoverKeyboard.legendText.Add(KeyboardTags.moveLeft, KeyboardTags.Movement);
		HoverKeyboard.legendText.Add(KeyboardTags.moveRight, KeyboardTags.Movement);
		HoverKeyboard.legendText.Add(KeyboardTags.leanLeft, KeyboardTags.Modification);
		HoverKeyboard.legendText.Add(KeyboardTags.leanRight, KeyboardTags.Modification);
		HoverKeyboard.legendText.Add(KeyboardTags.action, KeyboardTags.Action);
		HoverKeyboard.legendText.Add(KeyboardTags.lightMatch, KeyboardTags.Action);
		HoverKeyboard.legendText.Add(KeyboardTags.notes, KeyboardTags.Action);
		HoverKeyboard.legendText.Add(KeyboardTags.lookBehind, KeyboardTags.Action);
		HoverKeyboard.legendText.Add(KeyboardTags.inventory, KeyboardTags.Action);
		HoverKeyboard.legendText.Add(KeyboardTags.inventorySecondary, KeyboardTags.Action);
		HoverKeyboard.legendText.Add(KeyboardTags.pause, KeyboardTags.Modification);
		HoverKeyboard.legendText.Add(KeyboardTags.pauseSecondary, KeyboardTags.Modification);
		HoverKeyboard.legendText.Add(KeyboardTags.run, KeyboardTags.Modification);
		HoverKeyboard.legendText.Add(KeyboardTags.crouch, KeyboardTags.Modification);
		HoverKeyboard.legendText.Add(KeyboardTags.jump, KeyboardTags.Movement);
		
	}

	public static void DEFAULT_LIST_FOR_LEGEND(GameObject movement, GameObject modification, GameObject action)
	{

		KeyLevels.legendList = new List<Button>();
		
		Transform[] children = movement.GetComponentsInChildren<Transform>();
		foreach(Transform key in children)
			if(key.gameObject.GetComponent<Button>() != null)
				KeyLevels.legendList.Add(key.gameObject.GetComponent<Button>());
		
		children = modification.GetComponentsInChildren<Transform>();
		foreach(Transform key in children)
			if(key.gameObject.GetComponent<Button>() != null)
				KeyLevels.legendList.Add(key.gameObject.GetComponent<Button>());
		
		children = action.GetComponentsInChildren<Transform>();
		foreach(Transform key in children)
			if(key.gameObject.GetComponent<Button>() != null)
				KeyLevels.legendList.Add(key.gameObject.GetComponent<Button>());

		Debug.Log(KeyboardTags.keyboardTagsList[0]);

		for(int i = 0; i < KeyLevels.legendList.Count; i++)
			KeyLevels.legendList[i].GetComponentInChildren<Text>().text = Inputs.inputDict[KeyboardTags.keyboardTagsList[i]].getInputButton().GetComponentInChildren<Text>().text;

	}

}
