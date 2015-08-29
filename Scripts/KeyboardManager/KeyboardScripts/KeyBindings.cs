﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class KeyBindings {

	public AllKeys allKeys;

	public static void KEYS(string anInput, Button aButton)
	{

		aButton.tag = anInput;
		if(!Inputs.inputDict.ContainsKey(anInput))
			Inputs.inputDict.Add(anInput, new Inputs(aButton.name, anInput, aButton));
		colorKeyboard(aButton);

	}

	public static void HOVER_KEYS(string anInput, Button aButton)
	{
		if(!HoverKeyboard.hoverHelperText.ContainsKey(anInput))
			HoverKeyboard.hoverHelperText.Add(anInput, aButton.name);

	}

	public static void LEGEND(string anInput, string aType)
	{
		if(!HoverKeyboard.legendText.ContainsKey(anInput))
			HoverKeyboard.legendText.Add(anInput, aType);

	}

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
		Inputs.inputDict.Add(KeyboardTags.actionSecondary, new Inputs("Mouse1", KeyboardTags.actionSecondary, buttonList[63]));
		Inputs.inputDict.Add (KeyboardTags.stifleBreathORCoverLight, new Inputs("Mouse0", 
		                                                                        KeyboardTags.stifleBreathORCoverLight,
		                                                                        buttonList[62]));

		colorKeyboard();

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
		HoverKeyboard.hoverHelperText.Add(KeyboardTags.actionSecondary, Inputs.inputDict[KeyboardTags.actionSecondary].getInputKeyCode().ToString());
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
		HoverKeyboard.hoverHelperText.Add(KeyboardTags.stifleBreathORCoverLight,
		                                  Inputs.inputDict[KeyboardTags.stifleBreathORCoverLight].getInputKeyCode().ToString());
		
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
		HoverKeyboard.legendText.Add(KeyboardTags.actionSecondary, KeyboardTags.Action);
		HoverKeyboard.legendText.Add(KeyboardTags.lightMatch, KeyboardTags.Action);
		HoverKeyboard.legendText.Add(KeyboardTags.notes, KeyboardTags.Action);
		HoverKeyboard.legendText.Add(KeyboardTags.lookBehind, KeyboardTags.Action);
		HoverKeyboard.legendText.Add(KeyboardTags.inventory, KeyboardTags.Action);
		HoverKeyboard.legendText.Add(KeyboardTags.inventorySecondary, KeyboardTags.Action);
		HoverKeyboard.legendText.Add(KeyboardTags.pause, KeyboardTags.Modification);
		HoverKeyboard.legendText.Add(KeyboardTags.pauseSecondary, KeyboardTags.Modification);
		HoverKeyboard.legendText.Add(KeyboardTags.run, KeyboardTags.Action);
		HoverKeyboard.legendText.Add(KeyboardTags.crouch, KeyboardTags.Action);
		HoverKeyboard.legendText.Add(KeyboardTags.jump, KeyboardTags.Movement);
		HoverKeyboard.legendText.Add(KeyboardTags.stifleBreathORCoverLight, KeyboardTags.Action);
		
	}

	private static void colorKeyboard()
	{
		
		foreach(KeyValuePair<string, Inputs> aButton in Inputs.inputDict)
			aButton.Value.getInputButton().GetComponent<Image>().color = KeyboardUI.inUseCol;
		
	}
	
	private static void colorKeyboard(Button aButton)
	{
		
		aButton.GetComponent<Image>().color = KeyboardUI.inUseCol;
		
	}

}