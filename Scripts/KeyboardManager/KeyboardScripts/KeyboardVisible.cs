using UnityEngine;
using System.Collections;

public class KeyboardVisible : MonoBehaviour {

	public CanvasGroup keyboard;
	public CanvasGroup askToSave;
	bool isOn;

	public void visibleKeyboard()
	{

		isOn = true;

	}

	public void invisibleKeyboard()
	{

		askToSave.alpha = 0;
		askToSave.blocksRaycasts = false;
		askToSave.interactable = false;
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
		else if(isOn && Input.GetKeyDown(KeyCode.Escape))
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
