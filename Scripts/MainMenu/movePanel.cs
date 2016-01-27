//On MovePanel
using UnityEngine;
using System.Collections;

public class movePanel : MonoBehaviour {

	//Instance Variables
	Vector3 initialVect;
	Vector3 toVect;
	float elapsedTime = 0f;
	bool switchPan = false;

	public RectTransform general;
	public RectTransform sound;
	public RectTransform graphics;
	public RectTransform advanced;

	public CanvasGroup generalGroup;
	public CanvasGroup soundGroup;
	public CanvasGroup graphicsGroup;
	public CanvasGroup advancedGroup;

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
		if(toVect == general.position)
		{

			FVAPI.lerpAlphaChannelTimeMultiplied(generalGroup, 1, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(soundGroup, 0, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(graphicsGroup, 0, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(advancedGroup, 0, 3);
			//soundGroup.alpha = Mathf.Lerp(soundGroup.alpha, 0, Time.deltaTime*3);
			//graphicsGroup.alpha = Mathf.Lerp(graphicsGroup.alpha, 1, Time.deltaTime*3);
			//controlsGroup.alpha = Mathf.Lerp(controlsGroup.alpha, 0, Time.deltaTime*3);

			generalGroup.interactable = true;
			soundGroup.interactable = false;
			graphicsGroup.interactable = false;
			advancedGroup.interactable = false;

			generalGroup.blocksRaycasts = true;
			soundGroup.blocksRaycasts = false;
			graphicsGroup.blocksRaycasts = false;
			advancedGroup.blocksRaycasts = false;

		}
		else if(toVect == sound.position)
		{

			FVAPI.lerpAlphaChannelTimeMultiplied(generalGroup, 0, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(soundGroup, 1, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(graphicsGroup, 0, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(advancedGroup, 0, 3);
			//soundGroup.alpha = Mathf.Lerp(soundGroup.alpha, 1, Time.deltaTime);
			//graphicsGroup.alpha = Mathf.Lerp(graphicsGroup.alpha, 0, Time.deltaTime*3);
			//controlsGroup.alpha = Mathf.Lerp(controlsGroup.alpha, 0, Time.deltaTime*3);

			generalGroup.interactable = false;
			soundGroup.interactable = true;
			graphicsGroup.interactable = false;
			advancedGroup.interactable = false;

			generalGroup.blocksRaycasts = false;
			soundGroup.blocksRaycasts = true;
			graphicsGroup.blocksRaycasts = false;
			advancedGroup.blocksRaycasts = false;

		}
		else if(toVect == graphics.position)
		{
			
			FVAPI.lerpAlphaChannelTimeMultiplied(generalGroup, 0, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(soundGroup, 0, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(graphicsGroup, 1, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(advancedGroup, 0, 3);
			//soundGroup.alpha = Mathf.Lerp(soundGroup.alpha, 0, Time.deltaTime*3);
			//graphicsGroup.alpha = Mathf.Lerp(graphicsGroup.alpha, 1, Time.deltaTime*3);
			//controlsGroup.alpha = Mathf.Lerp(controlsGroup.alpha, 0, Time.deltaTime*3);
			
			generalGroup.interactable = false;
			soundGroup.interactable = false;
			graphicsGroup.interactable = true;
			advancedGroup.interactable = false;
			
			generalGroup.blocksRaycasts = false;
			soundGroup.blocksRaycasts = false;
			graphicsGroup.blocksRaycasts = true;
			advancedGroup.blocksRaycasts = false;
			
		}
		else if(toVect == advanced.position)
		{

			FVAPI.lerpAlphaChannelTimeMultiplied(generalGroup, 0, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(soundGroup, 0, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(graphicsGroup, 0, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(advancedGroup, 1, 3);
			//soundGroup.alpha = Mathf.Lerp(soundGroup.alpha, 0, Time.deltaTime*3);
			//graphicsGroup.alpha = Mathf.Lerp(graphicsGroup.alpha, 0, Time.deltaTime*3);
			//controlsGroup.alpha = Mathf.Lerp(controlsGroup.alpha, 1, Time.deltaTime*3);

			generalGroup.interactable = false;
			soundGroup.interactable = false;
			graphicsGroup.interactable = false;
			advancedGroup.interactable = true;

			generalGroup.blocksRaycasts = false;
			soundGroup.blocksRaycasts = false;
			graphicsGroup.blocksRaycasts = false;
			advancedGroup.blocksRaycasts = true;

		}
		else
		{
			FVAPI.lerpAlphaChannelTimeMultiplied(generalGroup, 1, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(soundGroup, 0, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(graphicsGroup, 0, 3);
			FVAPI.lerpAlphaChannelTimeMultiplied(advancedGroup, 0, 3);
			//soundGroup.alpha = Mathf.Lerp(soundGroup.alpha, 0, Time.deltaTime*3);
			//graphicsGroup.alpha = Mathf.Lerp(graphicsGroup.alpha, 1, Time.deltaTime*3);
			//controlsGroup.alpha = Mathf.Lerp(controlsGroup.alpha, 0, Time.deltaTime*3);
			
			generalGroup.interactable = true;
			soundGroup.interactable = false;
			graphicsGroup.interactable = false;
			advancedGroup.interactable = false;
			
			generalGroup.blocksRaycasts = true;
			soundGroup.blocksRaycasts = false;
			graphicsGroup.blocksRaycasts = false;
			advancedGroup.blocksRaycasts = false;
		}

	}

}
