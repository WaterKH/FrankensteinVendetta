using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//Stores all of the Keys on the virtual keyboard
public class AllKeys : MonoBehaviour {

	public static List<Button> allKeys;
	public static List<Button> legendList;
	static int counter = 0;

	public InputManager inputMan;
	public static InputManager inputManSta;

	public GameObject KeyboardLayout;
	public GameObject MouseLayout;
	public static GameObject parent;
	public static GameObject startRefNameSta;
	public static GameObject startRefButtonSta;
	public GameObject parentSet;
	public GameObject startRefName;
	public GameObject startRefButton;

	static Vector3 startPosName;
	static Vector3 startPosButton;

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

		parent = parentSet;
		startRefNameSta = startRefName;
		startRefButtonSta = startRefButton;

		startPosName = startRefName.transform.position;
		startPosButton = startRefButton.transform.position;

		inputManSta = inputMan;

	}

	public static void removeLegend()
	{

		Transform[] children = parent.GetComponentsInChildren<Transform>();
		for(int i = 2; i < children.Length; i++)
			Destroy(children[i].gameObject);
		counter = 0;
		startPosName = new Vector3(0,0,0);
		startPosButton = new Vector3(0,0,0);

	}

	public static List<Button> getButtons()
	{

		return allKeys;

	}

	public static void setLegendKey(string buttonTag, string keyCode)
	{
		
		foreach(Button aLegendButton in legendList)
			if(aLegendButton.tag.Equals(buttonTag))
			{

				aLegendButton.GetComponentInChildren<Text>().text = keyCode;
				legendList.Add(aLegendButton);
				break;
			}
		
	}

	public static void INITIAL_LIST_LEGEND(string anInput, string aTag)
	{

		GameObject inputDescr = Instantiate(Resources.Load("InputNonUI") as GameObject);
		inputDescr.transform.SetParent(parent.transform, false);
		if(startPosName == new Vector3(0,0,0))
		{
			startPosName = startRefNameSta.transform.position;
			inputDescr.transform.position = new Vector2(startPosName.x, startPosName.y);
		}
		else if(counter == 0)
		{
			startPosName = startRefNameSta.transform.position;
			inputDescr.transform.position = new Vector2(startPosName.x+500, startPosName.y);

		}
		else
			inputDescr.transform.position = new Vector2(startPosName.x, startPosName.y-40);

		inputDescr.name = anInput;
		inputDescr.GetComponent<Text>().text = anInput;

		GameObject inputButton = Instantiate(Resources.Load("InputNonUIButton") as GameObject);
		inputButton.transform.SetParent(parent.transform, false);
		if(startPosButton == new Vector3(0,0,0))
		{
			startPosButton = startRefButtonSta.transform.position;
			inputButton.transform.position = new Vector2(startPosButton.x, startPosButton.y);
		}
		else if(counter == 0)
		{
			startPosButton = startRefButtonSta.transform.position;
			inputButton.transform.position = new Vector2(startPosButton.x+500, startPosButton.y);

		}
		else
			inputButton.transform.position = new Vector2(startPosButton.x, startPosButton.y-40);

		inputButton.tag = aTag;
		inputButton.name = aTag;
		inputButton.GetComponentInChildren<Text>().text = Inputs.inputDict[aTag].getInputKeyCode().ToString();

		counter++;
		if(counter < 13)
		{
			startPosName = inputDescr.transform.position;
			startPosButton = inputButton.transform.position;
		}
		else
			counter = 0;

		AllKeys.legendList.Add(inputButton.GetComponent<Button>());

		inputButton.GetComponent<Button>().onClick.AddListener(() => 
		                                   inputManSta.setINDIVID_KEY(inputButton.GetComponent<Button>()));

	}
	
	public static void INITIAL_LIST_LEGEND(List<InputManager.INPUT_CLASS> inputManagerList)
	{

		for(int i = 0; i < inputManagerList.Count; i++)
			INITIAL_LIST_LEGEND(inputManagerList[i].Name, inputManagerList[i].Tag);

	}

}
