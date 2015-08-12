using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HoverKeyboard : MonoBehaviour {

	static bool hovering;
	Vector3 mousePos;
	static GameObject hoverHelper;
	public static Dictionary<string, string> hoverHelperText;
	public static Dictionary<string, string> legendText;

	public void keyboardHoverEnter(Button aButton)
	{

		if(Inputs.inputDict.ContainsKey(aButton.tag))
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
