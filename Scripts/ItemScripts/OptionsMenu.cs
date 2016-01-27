using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEditor;

public class OptionsMenu : MonoBehaviour {

	/****************************************************************
	 * General
	 */ 
	public Slider mouseSens;
	public Text mouseSenseValue;
	public Slider fovValue;
	public Text fovTextValue;
	public Toggle subtitlesOnOff;
	public Toggle mouseInver;

	/****************************************************************
	 * Audio
	 */ 
	public Slider masterVol;
	public Slider effectVol;
	public Slider voiceVol;
	public Slider musicVol;

	/****************************************************************
	 * Graphics
	 */ 
	public enum resolutions {
		//TODO Add resolutions when you get the chance
	};
	public int currentResolution = 0;
	public Button resolutionButton;
	public CanvasGroup resolutionSelection;
	public int currResolutionX = 0;
	public int currResolutionY = 0;
	public Text actualCurrentResolution;
	public Toggle windowFull;
	public Slider brightness;
	public enum graphics {
		low = 0,
		med = 1,
		high = 2,
		shigh = 3,
	};
	public int currentGraphics = 1;
	public Button graphicsButton;
	public CanvasGroup graphicsSelection;

	/****************************************************************
	 * Advanced
	 */ 
	public enum AA {
		//TODO Add AA options
	};
	public int currentAA;
	public Button AAButton;
	public CanvasGroup AASelection;
	public enum filtering {
		//TODO Add trilinear, bilinear, anisotropic
	};
	public int currentFiltering;
	public Button filteringButton;
	public CanvasGroup filteringSelection;
	//TODO Add stuff from SaveLoad.cs

	//TODO Is this needed anymore?
	public StaticVolumeSettings volumeSettings;

	public SaveLoad saveLoad;

	void Awake()
	{
		actualCurrentResolution.text = UnityStats.screenRes;
	}

	// TODO Add general functions...
	public void changeFOVSlider(Slider fovSlider)
	{
		fovTextValue.text = fovSlider.value.ToString();
	}
	public void changeMouseSensSlider(Slider mouseSensSlider)
	{
		mouseSenseValue.text = mouseSensSlider.value.ToString();
	}

	public void masterVolumeLevel(Slider masterVolume)
	{
		AudioListener.volume = masterVolume.value;
	}

	public void effectVolumeLevel(Slider effectVolume)
	{
		StaticVolumeSettings.effectVolume = effectVolume.value;
		volumeSettings.updateEffect(effectVolume.value);
	}

	public void dialogueVolumeLevel(Slider dialogueVolume)
	{
		StaticVolumeSettings.dialogueVolume = dialogueVolume.value;
		volumeSettings.updateDialogue(dialogueVolume.value);	
	}

	public void musicVolumeLevel(Slider musicVolume)
	{
		StaticVolumeSettings.musicVolume = musicVolume.value;
		volumeSettings.updateMusic(musicVolume.value);
	}

	public void setResolution(int x, int y)
	{
		currResolutionX = x;
		currResolutionY = y;
	}

}
