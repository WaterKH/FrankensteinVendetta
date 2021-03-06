﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebuggerHub : MonoBehaviour {

	public Player_MAIN player;

	public CanvasGroup debugMenu;
	public bool displayDebugMenu;

	public CanvasGroup playerStats;
	public bool displayPStats;

	public Text playerHealth;
	public Slider playerHealthManipulator;

	public Text framesPerSecond;

	public Text playerName;
	public Text playerSpeed;
	public Text playerLocation;

	int m_frameCounter = 0;
	float m_timeCounter = 0.0f;
	float m_lastFramerate = 0.0f;
	public float m_refreshTime = 0.5f;
	
	
	void Update()
	{

		if( m_timeCounter < m_refreshTime )
		{
			m_timeCounter += Time.deltaTime;
			m_frameCounter++;
		}
		else
		{
			m_lastFramerate = (float)m_frameCounter/m_timeCounter;
			m_frameCounter = 0;
			m_timeCounter = 0.0f;
			if(m_lastFramerate <= 25)
				framesPerSecond.color = Color.red;
			else
				framesPerSecond.color = Color.white;
			framesPerSecond.text = m_lastFramerate.ToString();
		}

		updateLocation();
		updateSpeed();
	}

	void Awake()
	{
		assignName();
		changeHealthOnValueChanged();
		updateLocation();
		updateSpeed();
	}

	public void displayMenu()
	{

		displayDebugMenu = !displayDebugMenu;

		if(displayDebugMenu)
		{
			debugMenu.alpha = 1;
			debugMenu.interactable = true;
		}
		else
		{
			debugMenu.alpha = 0;
			debugMenu.interactable = false;
			playerStats.alpha = 0;
			playerStats.interactable = false;
		}

	}

	//TODO 
	/*
	 * Include player height, FPS, and look up some other debug uses
	 * 
	 */ 

	public void spawnEnemy()
	{

		//TODO

	}

	//Toggleable
	//Simply displays the character stats
	public void displayPlayerStats()
	{

		displayPStats = !displayPStats;

		if(displayPStats)
		{
			playerStats.alpha = 1;
			playerStats.interactable = true;
		}
		else
		{
			playerStats.alpha = 0;
			playerStats.interactable = false;
		}

	}

	public void changeHealthOnValueChanged()
	{
		
		playerHealth.text = playerHealthManipulator.value.ToString();
		Player_MAIN.player.setHealth(playerHealthManipulator.value);
		player.displayDamage();
		
	}
	public void assignName()
	{
		playerName.text = Player_MAIN.player.getName();
	}
	public void updateSpeed()
	{
		playerSpeed.text = (Player_MAIN.player.getSpeed() / 10).ToString();
	}
	public void updateLocation()
	{
		playerLocation.text = Player_MAIN.player.getPosition().ToString();
	}

	//Toggleable
	public void displayImageEffects()
	{

		//TODO

	}

	public void noClip()
	{

		//TODO

	}

	public void infiniteItems()
	{

		//TODO

	}

	public void watchAnimations()
	{

		//TODO I want this to pull up another screen and be able to show all animations for all characters.
		//I'm not sure this is possible though. WE SHALL SEEEEEE

	}

}
