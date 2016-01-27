using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Character {

	private string characterName;
	private int characterID; // <-- This determines whether the character is the main character, 
							 //NPC, or enemy, respectively
	private float speed;

	public Character()
	{

		characterName = "unnamed";
		characterID = -1;
		speed = 0;

	}

	public Character(string aName, int anID, float aSpeed)
	{
		setName(aName);
		setID(anID);
		setSpeed(aSpeed);
	}

	public void setName(string aName)
	{
		characterName = aName;
	}
	public void setID(int anID)
	{
		characterID = anID;
	}
	public void setSpeed(float aSpeed)
	{
		speed = aSpeed;
	}

	public string getName()
	{
		return characterName;
	}
	public int getID()
	{
		return characterID;
	}
	public float getSpeed()
	{
		return speed;
	}
}
