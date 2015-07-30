using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//Stores all of the Keys on the virtual keyboard
public class AllKeys : MonoBehaviour {

	public static List<Button> allKeys;
	public GameObject KeyboardLayout;

	public GameObject movementKeys;
	public GameObject modificationKeys;
	public GameObject actionKeys;

	void Awake()
	{

		allKeys = new List<Button>();
		Transform[] children = KeyboardLayout.GetComponentsInChildren<Transform>();
		foreach(Transform key in children)
			if(key.gameObject.GetComponent<Button>() != null)
				allKeys.Add(key.gameObject.GetComponent<Button>());

		if(allKeys.Count == 62)
			Debug.Log("All keys successfully found");

	}

	public static List<Button> getButtons()
	{

		return allKeys;

	}

	public void objectsForDefaultClass()
	{

		DefaultKeyBindings.DEFAULT_LIST_FOR_LEGEND(movementKeys, modificationKeys, actionKeys);

	}

}
