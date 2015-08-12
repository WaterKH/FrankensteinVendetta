using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//Stores all of the Keys on the virtual keyboard
public class AllKeys : MonoBehaviour {

	public static List<Button> allKeys;
	public static List<Button> legendList;

	public GameObject KeyboardLayout;
	public GameObject MouseLayout;

	public static GameObject NonUILayout;

	public static GameObject movementKeys;
	public static GameObject modificationKeys;
	public static GameObject actionKeys;

	public GameObject nonUISet;
	public GameObject movementSet;
	public GameObject modifiSet;
	public GameObject actionSet;

	static Vector3 startPos;

	void Awake()
	{

		allKeys = new List<Button>();
		Transform[] children = KeyboardLayout.GetComponentsInChildren<Transform>();
		foreach(Transform key in children)
			if(key.gameObject.GetComponent<Button>() != null)
				allKeys.Add(key.gameObject.GetComponent<Button>());

		children = MouseLayout.GetComponentsInChildren<Transform>();
		foreach(Transform key in children)
			if(key.gameObject.GetComponent<Button>() != null)
				allKeys.Add(key.gameObject.GetComponent<Button>());

		if(allKeys.Count == 64)
			Debug.Log("All keys successfully found");


		NonUILayout = nonUISet;
		movementKeys = movementSet;
		modificationKeys = modifiSet;
		actionKeys = actionSet;

		startPos = NonUILayout.transform.position;

	}

	public static List<Button> getButtons()
	{

		return allKeys;

	}

	/*
	public void objectsForKeys()
	{

		//KeyBindings.LIST_FOR_LEGEND(movementKeys, modificationKeys, actionKeys);

	}*/

	public static void setLegendKey(string buttonTag, string keyCode)
	{
		
		foreach(Button aLegendButton in legendList)
			if(aLegendButton.tag.Equals(buttonTag))
			{
				aLegendButton.GetComponentInChildren<Text>().text = keyCode;
				break;
			}
		
	}

	public static void LIST_LEGEND(string anInput, string aType)
	{

		GameObject inputDescr = Instantiate(Resources.Load("InputNonUI")) as GameObject;
		inputDescr.transform.SetParent(NonUILayout.transform, false);
		inputDescr.transform.position = new Vector3(startPos.x, startPos.y-25f, startPos.z);
		inputDescr.name = anInput;
		inputDescr.GetComponent<Text>().text = anInput;

		GameObject inputButton = Instantiate(Resources.Load("InputNonUIButton")) as GameObject;
		if(aType.Equals("Movement"))
			inputButton.transform.SetParent(movementKeys.transform, false);
		else if(aType.Equals("Modification"))
			inputButton.transform.SetParent(modificationKeys.transform, false);
		else if(aType.Equals("Action"))
			inputButton.transform.SetParent(actionKeys.transform, false);
		inputButton.transform.position = new Vector3(startPos.x+40f, startPos.y, startPos.z);
		inputButton.name = anInput+"Button";
		inputButton.GetComponentInChildren<Text>().text = Inputs.inputDict[anInput].getInputKeyCode().ToString();

		startPos = inputDescr.transform.position;
		AllKeys.legendList.Add(inputButton.GetComponent<Button>());

		Debug.Log(inputButton.name);

	}

}
