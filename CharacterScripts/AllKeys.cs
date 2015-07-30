using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//Stores all of the Keys on the virtual keyboard
public class AllKeys : MonoBehaviour {

	public static List<Button> allKeys;

	public static List<Button> getButtons()
	{

		return allKeys;

	}

}
