//On Pencil
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewPlayerHover : MonoBehaviour {

	public CanvasGroup addPlayer;
	bool hovering;

	//When the mouse hovers over the Pencil
	void OnMouseEnter()
	{

		hovering = true;

	}

	//When the mouse exits the Pencil
	void OnMouseExit()
	{

		hovering = false;

	}

	void Update () {

		//If the mouse is over the Pencil, the add Player text will appear
		if(hovering)
			addPlayer.alpha = Mathf.Lerp(addPlayer.alpha, 1, Time.deltaTime);
		//Else the text will disappear
		else
			addPlayer.alpha = Mathf.Lerp(addPlayer.alpha, 0, Time.deltaTime*2);
	}
}
