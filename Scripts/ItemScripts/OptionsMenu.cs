using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class OptionsMenu : MonoBehaviour {

	/****************************************************************
	 * General
	 */ 
	public Text mouseSensText;
	public Slider mouseSens;
	public Text FOVText;
	public Slider fovValue;
	public Text subtitles;
	public Toggle subtitlesOnOff;
	public Text languageText;
	public enum languages {
		english = 0,
		//TODO What languages do we want?
	};
	public Button languageButton;
	public CanvasGroup languagesSelection; 
	public Text mouseInverText;
	public Toggle mouseInver;

	/****************************************************************
	 * Audio
	 */ 
	public Text masterVolText;
	public Slider masterVol;
	public Text effectVolText;
	public Slider effectVol;
	public Text voiceVolText;
	public Slider voiceVol;
	public Text musicVolText;
	public Slider musicVol;

	/****************************************************************
	 * Graphics
	 */ 
	public Text resolutionText;
	public enum resolutions {
		//TODO Add resolutions when you get the chance
	};
	public Button resolutionButton;
	public CanvasGroup resolutionSelection;
	public Text windowFullText;
	public Toggle windowFull;
	public Text brightnessText;
	public Slider brightness;
	public Text graphicsText;
	public enum graphics {
		low = 0,
		med = 1,
		high = 2,
		shigh = 3,
	};
	public Button graphicsButton;
	public CanvasGroup graphicsSelection;

	/****************************************************************
	 * Advanced
	 */ 
	public Text AAText;
	public enum AA {
		//TODO Add AA options
	};
	public Button AAButton;
	public CanvasGroup AASelection;
	public Text filteringText;
	public enum filtering {
		//TODO Add trilinear, bilinear, anisotropic
	};
	public Button filteringButton;
	public CanvasGroup filteringSelection;
	//TODO Add stuff from SaveLoad.cs

	public StaticVolumeSettings volumeSettings;

	void Awake()
	{

	}

	//TODO Add general functions...

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

}
