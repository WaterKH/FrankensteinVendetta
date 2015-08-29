//On MovePanel
using UnityEngine;
using System.Collections;

public class movePanel : MonoBehaviour {

	//Instance Variables
	Vector2 initialVect;
	Vector2 toVect;
	float elapsedTime = 0f;
	bool switchPan = false;

	public RectTransform graphics;
	public RectTransform sound;
	public RectTransform controls;

	public CanvasGroup scrollOver;
	public CanvasGroup graphicsGroup;
	public CanvasGroup soundGroup;
	public CanvasGroup controlsGroup;

	//Called on Multiple buttons in OptionsMenu Canvas
	public void panelMove(RectTransform rectT)
	{

		initialVect = GetComponent<RectTransform>().anchoredPosition;
		toVect = rectT.anchoredPosition;
		switchPan = true;
		elapsedTime = 0;

	}

	void Update()
	{
		//If switchPan is true, move panel to the correct option
		if (switchPan) {

			elapsedTime += Time.deltaTime;
			GetComponent<RectTransform> ().anchoredPosition = Vector2.Lerp (initialVect, new Vector2(toVect.x-425, toVect.y), elapsedTime);
			if (GetComponent<RectTransform> ().anchoredPosition == new Vector2(toVect.x-425, toVect.y))
				switchPan = false;
		} else
			elapsedTime = 0;

		//TODO Finish the Options Menu
		//Shows correct menu based on which option is selected
		if(scrollOver.alpha <= 0)
		{

			soundGroup.alpha = Mathf.Lerp(soundGroup.alpha, 0, Time.deltaTime*5);
			graphicsGroup.alpha = Mathf.Lerp(graphicsGroup.alpha, 0, Time.deltaTime*5);
			controlsGroup.alpha = Mathf.Lerp(controlsGroup.alpha, 0, Time.deltaTime*5);

			soundGroup.interactable = false;
			graphicsGroup.interactable = false;
			controlsGroup.interactable = false;

			soundGroup.blocksRaycasts = false;
			graphicsGroup.blocksRaycasts = false;
			controlsGroup.blocksRaycasts = false;

		}
		else if(toVect == graphics.anchoredPosition)
		{

			soundGroup.alpha = Mathf.Lerp(soundGroup.alpha, 0, Time.deltaTime*3);
			graphicsGroup.alpha = Mathf.Lerp(graphicsGroup.alpha, 1, Time.deltaTime*3);
			controlsGroup.alpha = Mathf.Lerp(controlsGroup.alpha, 0, Time.deltaTime*3);

			soundGroup.interactable = false;
			graphicsGroup.interactable = true;
			controlsGroup.interactable = false;

			soundGroup.blocksRaycasts = false;
			graphicsGroup.blocksRaycasts = true;
			controlsGroup.blocksRaycasts = false;

		}
		else if(toVect == sound.anchoredPosition)
		{
			
			soundGroup.alpha = Mathf.Lerp(soundGroup.alpha, 1, Time.deltaTime);
			graphicsGroup.alpha = Mathf.Lerp(graphicsGroup.alpha, 0, Time.deltaTime*3);
			controlsGroup.alpha = Mathf.Lerp(controlsGroup.alpha, 0, Time.deltaTime*3);

			soundGroup.interactable = true;
			graphicsGroup.interactable = false;
			controlsGroup.interactable = false;
			
			soundGroup.blocksRaycasts = true;
			graphicsGroup.blocksRaycasts = false;
			controlsGroup.blocksRaycasts = false;

		}
		else if(toVect == controls.anchoredPosition)
		{

			soundGroup.alpha = Mathf.Lerp(soundGroup.alpha, 0, Time.deltaTime*3);
			graphicsGroup.alpha = Mathf.Lerp(graphicsGroup.alpha, 0, Time.deltaTime*3);
			controlsGroup.alpha = Mathf.Lerp(controlsGroup.alpha, 1, Time.deltaTime*3);

			soundGroup.interactable = false;
			graphicsGroup.interactable = false;
			controlsGroup.interactable = true;

			soundGroup.blocksRaycasts = false;
			graphicsGroup.blocksRaycasts = false;
			controlsGroup.blocksRaycasts = true;

		}

	}

}
