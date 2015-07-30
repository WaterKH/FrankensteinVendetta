using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyboardTags {

	public static List<string> keyboardTagsList;

	//Holds all the tags to be referenced
	public static string moveForward = "moveForward";
	public static string moveBackward = "moveBackward";
	public static string moveLeft = "moveLeft";
	public static string moveRight = "moveRight";
	public static string leanLeft = "leanLeft";
	public static string leanRight = "leanRight";
	public static string action = "action";
	public static string lightMatch = "lightMatch";
	public static string notes = "notes";
	public static string lookBehind = "lookBehind";
	public static string inventory = "inventory";
	public static string inventorySecondary = "inventorySecondary";
	public static string pause = "pause";
	public static string pauseSecondary = "pauseSecondary";
	public static string run = "run";
	public static string crouch = "crouch";
	public static string jump = "jump";

	//Sorting type
	public static string Movement = "Movement";
	public static string Modification = "Modification";
	public static string Action = "Action";

	public static void keyboardTags()
	{
		keyboardTagsList = new List<string>();

		keyboardTagsList.Add(moveForward);
		keyboardTagsList.Add(moveBackward);
		keyboardTagsList.Add(moveLeft);
		keyboardTagsList.Add(moveRight);
		keyboardTagsList.Add(leanLeft);
		keyboardTagsList.Add(leanRight);
		keyboardTagsList.Add(action);
		keyboardTagsList.Add(lightMatch);
		keyboardTagsList.Add(notes);
		keyboardTagsList.Add(lookBehind);
		keyboardTagsList.Add(inventory);
		keyboardTagsList.Add(inventorySecondary);
		keyboardTagsList.Add(pause);
		keyboardTagsList.Add(pauseSecondary);
		keyboardTagsList.Add(run);
		keyboardTagsList.Add(crouch);
		keyboardTagsList.Add(jump);

	}

}
