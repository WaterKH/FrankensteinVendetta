using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HoverHelperText {

	public static void setHoverKeys(string buttonTag)
	{

		HoverKeyboard.hoverHelperText.Remove(buttonTag);
		HoverKeyboard.hoverHelperText.Add(buttonTag, Inputs.inputDict[buttonTag].getInputKeyCode().ToString());

	}

	public static void setLegendKeys(string buttonTag)
	{

		string legendKey = HoverKeyboard.legendText[buttonTag];
		HoverKeyboard.legendText.Remove(buttonTag);
		HoverKeyboard.legendText.Add(buttonTag, legendKey);

	}

	public static string hoverHelperText(Dictionary<string, string> aDict, Button aButton)
	{
		
		foreach(KeyValuePair<string, string> hoverText in aDict)
		{
			
			if(aButton.tag.Equals(hoverText.Key))
			{
				switch(hoverText.Key)
				{
					
				case "moveForward":
					return HoverKeyboard.legendText["moveForward"]+": To move forward, press the "+hoverText.Value+" key.";
				case "moveBackward":
					return HoverKeyboard.legendText["moveBackward"]+": To move backward, press the "+hoverText.Value+" key.";
				case "moveLeft":
					return HoverKeyboard.legendText["moveLeft"]+": To move left, press the "+hoverText.Value+" key.";
				case "moveRight":
					return HoverKeyboard.legendText["moveRight"]+": To move right, press the "+hoverText.Value+" key.";
				case "leanLeft":
					return HoverKeyboard.legendText["leanLeft"]+": To lean left, press the "+hoverText.Value+" key.";
				case "leanRight":
					return HoverKeyboard.legendText["leanRight"]+": To lean right, press the "+hoverText.Value+" key.";
				case "action":
					return HoverKeyboard.legendText["action"]+": To interact with objects, press the "+hoverText.Value+" key.";
				case "lightMatch":
					return HoverKeyboard.legendText["lightMatch"]+": To light a match, press the "+hoverText.Value+" key.";
				case "notes":
					return HoverKeyboard.legendText["notes"]+": To view your notes, press the "+hoverText.Value+" key.";
				case "lookBehind":
					return HoverKeyboard.legendText["lookBehind"]+": To use your mirror , press, and hold, the "+hoverText.Value+" key.";
				case "inventory":
					return HoverKeyboard.legendText["inventory"]+": To view the contents of your rucksack, press the "+hoverText.Value+" key.";
				case "inventorySecondary":
					return HoverKeyboard.legendText["inventorySecondary"]+": To view the contents of your rucksack, press the "+hoverText.Value+" key.";	
				case "pause":
					return HoverKeyboard.legendText["pause"]+": To pause your session, press the "+hoverText.Value+" key.";
				case "pauseSecondary":
					return HoverKeyboard.legendText["pauseSecondary"]+": To pause your session, press the "+hoverText.Value+" key.";
				case "run":
					return HoverKeyboard.legendText["run"]+": To run, press, and hold, the "+hoverText.Value+" key, with any of the Movement" +
						" keys.";	
				case "crouch":
					return HoverKeyboard.legendText["crouch"]+": To crouch, press the "+hoverText.Value+" key.";	
				case "jump":
					return HoverKeyboard.legendText["jump"]+": To jump, press the "+hoverText.Value+" key.";
				default:
					return "No function is binded to this key.";
					
				}
			}
			
		}
		return "This should never run because the default case should run first";
		
	}

}
