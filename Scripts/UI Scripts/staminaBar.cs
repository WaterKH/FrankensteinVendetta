//On StaminaBar
//TODO I believe this is broken right now
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class staminaBar : MonoBehaviour {

	public Slider staminaSlider;
	public bool shiftPressed;

	private bool isRunning;
	RectTransform stamina;
	Vector2 currPos;
	float elapsedTime = 0;
	
	void Start () 
	{

		staminaSlider.enabled = false;

	}
	
	void Awake () 
	{

		stamina = GetComponent<RectTransform> ();
		currPos = stamina.anchoredPosition;

	}
	
	void Update () {

		//If LeftShift is down, shiftPressed becomes true which is used below in LateUpdate Method
		if (Input.GetKeyDown (KeyCode.LeftShift))
		{
			shiftPressed = true;
			elapsedTime = 0;

		}
		//Else it becomes false
		else if (Input.GetKeyUp (KeyCode.LeftShift))
		{

			shiftPressed = false;
			elapsedTime = 0;

		}

	}

	void LateUpdate(){

		//If the shift is pressed, the stamina bar will decrease
		if (shiftPressed)
		{

			elapsedTime += Time.deltaTime;
			stamina.anchoredPosition = Vector3.Lerp (new Vector3 (currPos.x, currPos.y, 0), new Vector3 (currPos.x, 320, 0), 2 * elapsedTime);	
		
		} 
		//Else the stamina bar will increase
		else if (shiftPressed == false) 
		{

			elapsedTime += Time.deltaTime;
			stamina.anchoredPosition = Vector3.Lerp (new Vector3 (currPos.x, 320, 0), new Vector3 (currPos.x, 350, 0), 3/2 * elapsedTime);	
		
		}

	}

}
