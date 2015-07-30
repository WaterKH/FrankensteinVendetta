using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HoverKeyboard : MonoBehaviour {

	bool hovering;
	Vector3 mousePos;
	GameObject hoverHelper;
	public static Dictionary<string, string> hoverHelperText;
	public static Dictionary<string, string> legendText;

	public GameObject movement;
	public GameObject modification;
	public GameObject action;

	public GameObject initMove;
	public GameObject initModi;
	public GameObject initAction;

	void Start()
	{

		//HoverHelperText.DEFAULT_HOVER_KEYS();

	}

	public void keyboardHoverEnter(Button aButton)
	{
		if(KeyboardUI.buttonList.ContainsKey(aButton.tag))
		{
		
			Transform parent = aButton.transform.parent;
			hovering = true;
			hoverHelper = Instantiate(Resources.Load("HoverHelper") as GameObject);
			hoverHelper.transform.SetParent(parent);
			hoverHelper.transform.position = new Vector3(Input.mousePosition.x+60f, Input.mousePosition.y+25f, Input.mousePosition.z+5f);
			mousePos = hoverHelper.transform.position;
			hoverHelper.GetComponentInChildren<Text>().text = HoverHelperText.hoverHelperText(hoverHelperText, aButton);

		}

	}

	public void keyboardKeyboardExit()
	{

		hovering = false;
		if(hoverHelper != null)
			Destroy(hoverHelper.gameObject);

	}

	void Update()
	{

		if(hovering)
		{

			if(Input.mousePosition != mousePos)
			{

				hoverHelper.transform.position = new Vector3(Input.mousePosition.x+60f, Input.mousePosition.y+25f, Input.mousePosition.z+5f);
				mousePos = hoverHelper.transform.position;

			}

		}

	}

}
