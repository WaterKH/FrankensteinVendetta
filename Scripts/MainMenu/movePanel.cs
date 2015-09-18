//On MovePanel
using UnityEngine;
using System.Collections;

public class movePanel : MonoBehaviour {

	//Instance Variables
	Vector3 initialVect;
	Vector3 toVect;
	float elapsedTime = 0f;
	bool switchPan = false;

	public RectTransform graphics;
	public RectTransform sound;
	public RectTransform controls;

	public CanvasGroup graphicsGroup;
	public CanvasGroup soundGroup;
	public CanvasGroup controlsGroup;

	//Called on Multiple buttons in OptionsMenu Canvas
	public void panelMove(RectTransform rectT)
	{

		initialVect = GetComponent<RectTransform>().position;
		toVect = rectT.position;
		switchPan = true;
		elapsedTime = 0;

	}

	void Update()
	{
		//If switchPan is true, move panel to the correct option
		if (switchPan) 
		{

			elapsedTime += Time.deltaTime;
			GetComponent<RectTransform> ().position = Vector3.Lerp (GetComponent<RectTransform>().position, 
			                                                                toVect, elapsedTime);
			if (GetComponent<RectTransform> ().position == toVect)
				switchPan = false;

		} 
		else
			elapsedTime = 0;

		//TODO Finish the Options Menu
		//Shows correct menu based on which option is selected
		if(toVect == graphics.position)
		{

			FVAPI.lerpAlphaChannelTimeMultiplied(soundGroup, 0, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(graphicsGroup, 1, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(controlsGroup, 0, 3);
			//soundGroup.alpha = Mathf.Lerp(soundGroup.alpha, 0, Time.deltaTime*3);
			//graphicsGroup.alpha = Mathf.Lerp(graphicsGroup.alpha, 1, Time.deltaTime*3);
			//controlsGroup.alpha = Mathf.Lerp(controlsGroup.alpha, 0, Time.deltaTime*3);

			soundGroup.interactable = false;
			graphicsGroup.interactable = true;
			controlsGroup.interactable = false;

			soundGroup.blocksRaycasts = false;
			graphicsGroup.blocksRaycasts = true;
			controlsGroup.blocksRaycasts = false;

		}
		else if(toVect == sound.position)
		{

			FVAPI.lerpAlphaChannelTimeMultiplied(soundGroup, 1, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(graphicsGroup, 0, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(controlsGroup, 0, 3);
			//soundGroup.alpha = Mathf.Lerp(soundGroup.alpha, 1, Time.deltaTime);
			//graphicsGroup.alpha = Mathf.Lerp(graphicsGroup.alpha, 0, Time.deltaTime*3);
			//controlsGroup.alpha = Mathf.Lerp(controlsGroup.alpha, 0, Time.deltaTime*3);

			soundGroup.interactable = true;
			graphicsGroup.interactable = false;
			controlsGroup.interactable = false;
			
			soundGroup.blocksRaycasts = true;
			graphicsGroup.blocksRaycasts = false;
			controlsGroup.blocksRaycasts = false;

		}
		else if(toVect == controls.position)
		{

			FVAPI.lerpAlphaChannelTimeMultiplied(soundGroup, 0, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(graphicsGroup, 0, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(controlsGroup, 1, 3);
			//soundGroup.alpha = Mathf.Lerp(soundGroup.alpha, 0, Time.deltaTime*3);
			//graphicsGroup.alpha = Mathf.Lerp(graphicsGroup.alpha, 0, Time.deltaTime*3);
			//controlsGroup.alpha = Mathf.Lerp(controlsGroup.alpha, 1, Time.deltaTime*3);

			soundGroup.interactable = false;
			graphicsGroup.interactable = false;
			controlsGroup.interactable = true;

			soundGroup.blocksRaycasts = false;
			graphicsGroup.blocksRaycasts = false;
			controlsGroup.blocksRaycasts = true;

		}

	}

}
