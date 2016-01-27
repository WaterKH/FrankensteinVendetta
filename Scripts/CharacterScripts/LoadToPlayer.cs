using UnityEngine;
using System.Collections;
using UnityEditor;

public class LoadToPlayer : MonoBehaviour {

	public GameObject mainCamera;
	public StaticVolumeSettings volumeSettings;

	public void loadOptionsToPlayer(OptionsData optionsData)
	{
		// TODO Add a line that sets the player main camera
		//GENERAL
		if(mainCamera != null)
		{
			mainCamera.GetComponentInParent<MouseLook>().sensitivityX = optionsData.mouseSensitivity;
			if(optionsData.mouseInversion)
			{
				mainCamera.GetComponent<MouseLook>().sensitivityY = -optionsData.mouseSensitivity;
			}
			else
			{
				mainCamera.GetComponent<MouseLook>().sensitivityY = optionsData.mouseSensitivity;
			}
			mainCamera.GetComponent<Camera>().fieldOfView = optionsData.fieldOfView;

			if(optionsData.subtitles)
			{
				//TODO Write a subtitle feature
			}

			//AUDIO
			//TODO Do something about the master volume
			volumeSettings.updateEffect(optionsData.effectsLevel);
			volumeSettings.updateDialogue(optionsData.voiceLevel);
			volumeSettings.updateMusic(optionsData.musicLevel);

			//GRAPHICS
			Screen.SetResolution(optionsData.resX, optionsData.resY, optionsData.windowedOrFullscreen);
			//TODO Figure out brightness
			//TODO Do the graphics...?

			//ADVANCED
			//TODO AntiAliasing
			//TODO Filtering 
		}
	}
}
