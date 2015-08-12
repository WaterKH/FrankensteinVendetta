using UnityEngine;
using System.Collections;

public class KeyboardVisible : MonoBehaviour {

	public CanvasGroup keyboard;
	bool isOn;

	public void visibleKeyboard()
	{

		isOn = true;

	}

	public void invisibleKeyboard()
	{

		isOn = false;

	}

	// Update is called once per frame
	void Update () {

		if(isOn)
		{

			keyboard.interactable = true;
			keyboard.blocksRaycasts = true;
			keyboard.alpha = Mathf.Lerp(keyboard.alpha, 1, Time.deltaTime*2);

		}
		else if(isOn && Input.GetKeyDown(KeyCode.Escape))
		{

			isOn = false;

		}
		else
		{

			keyboard.interactable = false;
			keyboard.blocksRaycasts = false;
			keyboard.alpha = Mathf.Lerp(keyboard.alpha, 0, Time.deltaTime*2);

		}
	
	}

}
