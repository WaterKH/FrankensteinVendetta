using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Character {

	private string characterName;
	private int characterID; // <-- This determines whether the character is the main character, 
							 //NPC, or enemy, respectively

	public Character()
	{

		characterName = "unnamed";
		characterID = -1;

	}

	public Character(string aName, int anID)
	{

		setName(aName);
		setID(anID);

	}

	public void setName(string aName)
	{

		characterName = aName;

	}

	public void setID(int anID)
	{

		characterID = anID;

	}

	public string getName()
	{

		return characterName;

	}

	public int getID()
	{

		return characterID;

	}

}
