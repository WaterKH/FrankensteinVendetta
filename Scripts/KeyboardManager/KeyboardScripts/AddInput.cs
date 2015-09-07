using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AddInput : MonoBehaviour {

	public CanvasGroup InputFillOut;
	public CanvasGroup ToolTip;
	public CanvasGroup MainFillOut;
	public InputField input;
	public InputField button;
	public InputField type;
	public InputField nameLeg;
	public InputField toolTip;
	ButtonSerializable buttonSer = new ButtonSerializable();
	public HoverKeyboard hoverHelperText;
	public HoverKeyboard hoverKeyboard;
	string tempText;

	Button tempButton = null;

	public void addAnInput()
	{

		MainFillOut.alpha = 1; 
		MainFillOut.interactable = true;
		MainFillOut.blocksRaycasts = true;

		InputFillOut.alpha = 1;
		InputFillOut.blocksRaycasts = true;
		InputFillOut.interactable = true;

	}
	/*
	public void clickedSubmitInput()
	{

		bool inputBool = true;
		bool buttonBool = true;
		bool nameBool = true;

		if(input.text == "" || button.text == "" || type.text == "" || nameLeg.text == "")
			Debug.Log("One or more of the items are null");

		for(int i = 0; i < InputManager.inputManagerList.Count; i++)
		{

			if(InputManager.inputManagerList[i].Input.ToString().ToLower().Equals(input.text.ToLower()))
			{	
				Debug.Log("This tag/ input is already in use");
				inputBool = false;
				break;
			}

		}

		foreach(Button aKey in AllKeys.getButtons())
		{

			if(button.text.ToLower().Equals(aKey.GetComponentInChildren<Text>().text.ToLower()))
			{

				if(HoverKeyboard.hoverHelperText.ContainsValue(aKey.name))
				{

					Debug.Log("This button is already in use");
					buttonBool = false;
					break;
				}
				else
					tempButton = aKey;

			}

		}

		foreach(string aKey in InputManager.NAMES_STATIC)
		{

			if(nameLeg.text.ToLower().Equals(aKey.ToLower ()))
			{

				Debug.Log("This name is already in use");
				nameBool = false;
				break;

			}

		}

		if(inputBool && buttonBool && nameBool)
		{

			KeyboardTags.keyboardTagsList.Add(input.text);
			KeyBindings.KEYS(input.text, tempButton);
			KeyBindings.HOVER_KEYS(input.text, tempButton.name);
			KeyBindings.LEGEND(input.text, type.text);
			AllKeys.INITIAL_LIST_LEGEND(nameLeg.text, input.text);
			
		}

		InputFillOut.alpha = 0;
		InputFillOut.blocksRaycasts = false;
		InputFillOut.interactable = false;

		ToolTip.alpha = 1;
		ToolTip.blocksRaycasts = true;
		ToolTip.interactable = true;

	}

	public void clickedSubmitToolTip()
	{

		addToolTipText(toolTip.text, type.text);
		
		EventTrigger trigger = tempButton.GetComponent<EventTrigger>();
		EventTrigger.Entry entry = new EventTrigger.Entry();
		trigger.triggers.RemoveAt(0);
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener( (eventData) => { addToolTip (tempButton); } );
		trigger.triggers.Add(entry);

		ToolTip.alpha = 0;
		ToolTip.blocksRaycasts = false;
		ToolTip.interactable = false;

		MainFillOut.alpha = 0; 
		MainFillOut.interactable = false;
		MainFillOut.blocksRaycasts = false;

	}

	public void addToolTip(Button aButton)
	{
		
		if(Inputs.inputDict.ContainsKey(aButton.tag))
		{
			
			Transform parent = aButton.transform.parent;
			hoverKeyboard.hovering = true;
			hoverKeyboard.hoverHelper = Instantiate(Resources.Load("HoverHelper") as GameObject);
			hoverKeyboard.hoverHelper.transform.SetParent(parent);
			hoverKeyboard.hoverHelper.transform.position = new Vector3(Input.mousePosition.x+60f, Input.mousePosition.y+25f, Input.mousePosition.z+5f);
			hoverKeyboard.mousePos = hoverKeyboard.hoverHelper.transform.position;
			hoverKeyboard.hoverHelper.GetComponentInChildren<Text>().text = HoverKeyboard.legendText[input.text];
			
		}

	}

	public void addToolTipText(string inputField, string typeText)
	{

		HoverKeyboard.legendText.Remove(input.text);
		tempText = typeText+": "+inputField+".";
		HoverKeyboard.legendText.Add(input.text, tempText);
		
	}
	*/
}