using UnityEngine;
using System.Collections;
using System;

[Serializable]
//Self explanatory method -- Used for MainMenu users and save Data
public class User {
	
	private string playerName;
	private bool completedGame;
	private int layer;
	private int id;

	public User()
	{

		playerName = "";
		completedGame = false;
		layer = 0;
		id = 0;

	}

	public User(string aName, bool complete, int aLayer, int anID)
	{

		setPlayerName(aName);
		setCompletetion(complete);
		setLayer(aLayer);
		setPlayerID(anID);

	}

	public bool getCompletetion()
	{

		return completedGame;

	}

	public string getPlayerName()
	{

		return playerName;

	}

	public int getPlayerLayer()
	{

		return layer;

	}

	public int getPlayerID()
	{

		return id;

	}

	public void setCompletetion(bool complete)
	{

		completedGame = complete;

	}

	public void setPlayerName(string aName)
	{

		playerName = aName;

	}

	public void setLayer(int aLayer)
	{

		layer = aLayer;

	}

	public void setPlayerID(int anID)
	{

		id = anID;

	}

}
