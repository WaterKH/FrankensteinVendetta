using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyboardVisible : MonoBehaviour
{
	
	public CanvasGroup keyboard;
	public CanvasGroup askToSave;
	static CanvasGroup askToSave_STATIC;
	public static bool isOn;

	public Button backButton;
	public static Button backButton_STATIC;

	void Awake()
	{

		askToSave_STATIC = askToSave;
		backButton_STATIC = backButton;

	}

	public void visibleKeyboardCall()
	{

		visibleKeyboard();
		backButton.interactable = false;

	}
	
	public static void visibleKeyboard()
	{
		
		isOn = true;
		
	}

	public void invisibleKeyboardCall()
	{

		invisibleKeyboard();

	}
	
	public static void invisibleKeyboard()
	{
		
		askToSave_STATIC.alpha = 0;
		askToSave_STATIC.blocksRaycasts = false;
		askToSave_STATIC.interactable = false;
		backButton_STATIC.interactable = true;
		isOn = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isOn)
		{
			
			keyboard.interactable = true;
			keyboard.blocksRaycasts = true;
			FVAPI.lerpAlphaChannelTimeMultiplied(keyboard, 1, 2);
			//keyboard.alpha = Mathf.Lerp(keyboard.alpha, 1, Time.deltaTime*2);
			
		}
		else if(isOn && InputManager.GetKeyDown("pause"))
		{
			
			isOn = false;
			
		}
		else
		{
			keyboard.interactable = false;
			keyboard.blocksRaycasts = false;
			FVAPI.lerpAlphaChannelTimeMultiplied(keyboard, 0, 2);
			//keyboard.alpha = Mathf.Lerp(keyboard.alpha, 0, Time.deltaTime*2);
			
		}
		
	}

}
