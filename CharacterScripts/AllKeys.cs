using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//Stores all of the Keys on the virtual keyboard
public class AllKeys : MonoBehaviour {

	public static List<Button> allKeys;
	public GameObject KeyboardLayout;

	void Awake()
	{

		allKeys = new List<Button>();
		Transform[] children = KeyboardLayout.GetComponentsInChildren<Transform>();
		foreach(Transform key in children)
			if(key.gameObject.GetComponent<Button>() != null)
				allKeys.Add(key.gameObject.GetComponent<Button>());

		Debug.Log(allKeys.Count);

	}

	public static List<Button> getButtons()
	{

		return allKeys;

	}

}
