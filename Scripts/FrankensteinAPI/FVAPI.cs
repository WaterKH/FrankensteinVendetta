using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FVAPI {

	public Button getButton(GameObject anObject)
	{

		return anObject.GetComponent<Button>();

	}

	public Text getText(GameObject anObject)
	{

		return anObject.GetComponent<Text>();

	}

	public string getTextString(GameObject anObject)
	{

		return anObject.GetComponent<Text>().text;

	}

	public GameObject getMainCharacter()
	{

		return GameObject.Find("FPC");

	}

	public GameObject[] getAllCharacters()
	{

		return GameObject.FindGameObjectsWithTag("Character");

	}

	public int getCharacterID(GameObject anObject)
	{

		//If ID == 0, character is not an enemy
		//Else if ID == 1, character is an enemy
		return anObject.GetComponent<Character>().getID();

	}

	public string getCharacterName(GameObject anObject)
	{

		return anObject.GetComponent<Character>().getName();

	}

	public void playAudioTrack(GameObject anObject, bool loop)
	{

		SoundManager.playSound(anObject, loop);

	}

	public void stopAudioTrack(GameObject anObject)
	{

		SoundManager.stopSound(anObject);

	}

	public void playAnimation(GameObject anObject, bool loop, string state)
	{

		AnimManager.playAnim(anObject, loop, state);

	}

	public void stopAnimation(GameObject anObject, string state)
	{

		AnimManager.stopAnim(anObject, state);

	}

}
