using UnityEngine;
using System.Collections;

public class StaticVolumeSettings : MonoBehaviour {

	//Static Variables
	public static float effectVolume;
	public static float musicVolume;
	public static float dialogueVolume;

	void Awake()
	{

		Debug.Log ("Setting Volume Levels");

		updateEffect(effectVolume);
		updateMusic(musicVolume);
		updateDialogue(dialogueVolume);

		Debug.Log("Volume Levels Complete");

	}

	public void updateEffect(float value)
	{

		GameObject[] effectArr = GameObject.FindGameObjectsWithTag("eff");
		foreach(GameObject eff in effectArr)
			eff.GetComponent<AudioSource>().volume = value;

	}

	public void updateMusic(float value)
	{

		GameObject[] musicArr = GameObject.FindGameObjectsWithTag("mus");
		foreach(GameObject mus in musicArr)
			mus.GetComponent<AudioSource>().volume = value;

	}

	public void updateDialogue(float value)
	{

		GameObject[] dialogueArr = GameObject.FindGameObjectsWithTag("dia");
		foreach(GameObject dia in dialogueArr)
			dia.GetComponent<AudioSource>().volume = value;

	}

}
