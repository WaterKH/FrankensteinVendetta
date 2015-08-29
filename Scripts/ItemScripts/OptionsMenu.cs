using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class OptionsMenu : MonoBehaviour {

	//Graphics
	public Text getGraphics;
	public Button increaseButton;
	public Button decreaseButton;

	//Brightness
	public Slider brightnessSlider;
	public Color ambientDark;
	public Color ambientLight;

	//Window Size
	public Text getScreenSize;
	public Button windowedButton;
	public Button fullScreenButton;

	//AnisoLevel
	public Button disableAnisoButton;
	public Button enableAnisoButton;
	public Button forceEnableAnisoButton;

	//Volume
	public Slider effectSlider;
	public Slider dialogueSlider;
	public Slider musicSlider;

	public StaticVolumeSettings volumeSettings;

	void Awake()
	{

		int graphics = QualitySettings.GetQualityLevel()-2;
		getGraphics.text = graphics.ToString();
		RenderSettings.ambientLight = Color.Lerp (ambientLight, ambientDark, brightnessSlider.value);
		fullScreenButton.interactable = false;

		effectVolumeLevel(effectSlider);
		dialogueVolumeLevel(dialogueSlider);
		musicVolumeLevel(musicSlider);

	}

	public void decreaseGraphics()
	{

		QualitySettings.DecreaseLevel();
		int graphics = QualitySettings.GetQualityLevel()-2;
		getGraphics.text = graphics.ToString();
		if(graphics == 0)
			decreaseButton.interactable = false;
		increaseButton.interactable = true;

	}

	public void increaseGraphics()
	{

		QualitySettings.IncreaseLevel();
		int graphics = QualitySettings.GetQualityLevel()-2;
		getGraphics.text = graphics.ToString();
		if(graphics == 3)
			increaseButton.interactable = false;
		decreaseButton.interactable = true;

	}

	public void windowed()
	{

		getScreenSize.text = "Windowed";
		windowedButton.interactable = false;
		fullScreenButton.interactable = true;
		Screen.fullScreen = false;

	}

	public void fullScreen()
	{

		getScreenSize.text = "Full Screen";
		fullScreenButton.interactable = false;
		windowedButton.interactable = true;
		Screen.fullScreen = true;

	}

	public void brightnessBar(Slider brightnessBarVal)
	{

		RenderSettings.ambientLight = Color.Lerp (ambientLight, ambientDark, brightnessBarVal.value);

	}

	public void disableAniso()
	{

		QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
		disableAnisoButton.interactable = false;
		enableAnisoButton.interactable = true;
		forceEnableAnisoButton.interactable = true;

	}

	public void enableAniso()
	{

		QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
		disableAnisoButton.interactable = true;
		enableAnisoButton.interactable = false;
		forceEnableAnisoButton.interactable = true;

	}

	public void forceEnableAniso()
	{
		
		QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
		disableAnisoButton.interactable = true;
		enableAnisoButton.interactable = true;
		forceEnableAnisoButton.interactable = false;

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

}
