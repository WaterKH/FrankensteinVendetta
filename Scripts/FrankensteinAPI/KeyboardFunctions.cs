using UnityEngine;
using System.Collections;

public class KeyboardFunctions : MonoBehaviour {
		
	//FOR TESTING PURPOSES
	void Update () 
	{
		if(InputManager.GetKeyDown("action"))
		{
			Debug.Log("Performed Action.");
		}
		else if(InputManager.GetKey("action"))
		{
			Debug.Log("Still performing action.");
		}
		else if(InputManager.GetKeyDown ("actionSecondary"))
		{
			Debug.Log("Performed Action.");
		}
		else if(InputManager.GetKey("actionSecondary"))
		{
			Debug.Log("Still performing action.");
		}
	}
}
