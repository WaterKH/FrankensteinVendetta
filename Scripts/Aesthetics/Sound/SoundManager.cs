using UnityEngine;
using System.Collections;

public static class SoundManager {

	public static void playSound(GameObject audioSource, bool loop)
	{

		if(loop)
			audioSource.GetComponent<AudioSource>().Play();
		else
			audioSource.GetComponent<AudioSource>().PlayOneShot(audioSource.GetComponent<AudioClip>());

	}

	public static void stopSound(GameObject audioSource)
	{

		audioSource.GetComponent<AudioSource>().Stop();

	}

}
