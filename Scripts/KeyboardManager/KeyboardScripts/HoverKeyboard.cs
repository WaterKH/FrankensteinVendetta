using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class HoverKeyboard : MonoBehaviour {

	public bool hovering;
	public Vector3 mousePos;
	public GameObject hoverHelper;

	public void keyboardHoverEnter(Button aButton)
	{

		if(Inputs.inputDict.ContainsKey(aButton.tag))
		{

			Transform parent = aButton.transform.parent;
			hovering = true;
			hoverHelper = Instantiate(Resources.Load("HoverHelper") as GameObject);
			hoverHelper.transform.SetParent(parent);
			hoverHelper.transform.position = new Vector3(Input.mousePosition.x+60f, 
			                                             Input.mousePosition.y+25f, 
			                                             Input.mousePosition.z+5f);
			mousePos = hoverHelper.transform.position;
			hoverHelper.GetComponentInChildren<Text>().text = 
				hoverHelperText(InputManager.inputManagerList, aButton);

		}

	}

	public void keyboardKeyboardExit()
	{

		hovering = false;
		if(hoverHelper != null)
			Destroy(hoverHelper.gameObject);

	}

	public static string hoverHelperText(List<InputManager.INPUT_CLASS> inputManagerList, Button aButton)
	{
		
		foreach(InputManager.INPUT_CLASS inputClass in inputManagerList)
			if(aButton.tag.Equals(inputClass.Tag)) 
				return "\b"+inputClass.Type+"\b:\n"+inputClass.Name+":\n"+inputClass.Input.ToString();
		
		return "No tag associated with this.";
		
	}

	void Update()
	{

		if(hovering)
		{

			if(Input.mousePosition != mousePos)
			{

				hoverHelper.transform.position = new Vector3(Input.mousePosition.x+60f, 
				                                             Input.mousePosition.y+25f, 
				                                             Input.mousePosition.z+5f);
				mousePos = hoverHelper.transform.position;

			}

		}

	}

}