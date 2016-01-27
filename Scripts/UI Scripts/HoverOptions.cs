using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

public class HoverOptions : MonoBehaviour {

	public bool toolTipHelpOn;
	public bool hovering;
	public Vector3 mousePos;
	public GameObject hoverHelper;

	public void toggleToolTip()
	{
		toolTipHelpOn = !toolTipHelpOn;
		Debug.Log("Tool Tip is now: " + toolTipHelpOn);
	}

	public void hoverOverOption(GameObject hoverObject)
	{
		if(toolTipHelpOn)
		{
			Debug.Log("Create Tool Tip For " + hoverObject.name);
			Transform parent = hoverObject.transform.parent;
			hovering = true;
			hoverHelper = Instantiate(Resources.Load("OptionsHoverHelper") as GameObject);
			hoverHelper.transform.SetParent(parent);
			//Vector3 inputPosition = Input.mousePosition; 
			//hoverHelper.transform.position = Camera.main.ScreenToWorldPoint(inputPosition);
			//hoverHelper.transform.position = new Vector3(Input.mousePosition.x+60f, 
			                                             //Input.mousePosition.y+25f, 
			                                             //Input.mousePosition.z+5f);
			Debug.Log (hoverHelper.name);
			Debug.Log(parent.name);
			mousePos = hoverHelper.transform.position;
			hoverHelper.GetComponentInChildren<Text>().text = 
				hoverHelperText(hoverObject);
		}
	}

	public void hoverExitOption()
	{
//1		Debug.Log("Destroy Tool Tip");
		//hovering = false;
		//if(hoverHelper != null)
		//	Destroy(hoverHelper.gameObject);

	}

	public string hoverHelperText(GameObject hoverObject)
	{
		string objectText = hoverObject.GetComponent<Text>().text;
		switch(hoverObject.name)
		{
		case "MouseSensText":
			return objectText + " - Current Mouse Sensitivity : " + hoverObject.GetComponentInChildren<Slider>().value;
			break;
		case "FOVText":
			return objectText + " - Current FOV : " + hoverObject.GetComponentInChildren<Slider>().value;
			break;
		case "SubtitlesText":
			string isSubtitlesOn;
			if(hoverObject.GetComponentInChildren<Toggle>().isOn)
				isSubtitlesOn = "Yes";
			else
				isSubtitlesOn = "No";
			return objectText + " - Are Subtitles enabled? " + isSubtitlesOn;
			break;
		case "MouseInversText":
			string isMouseInverOn;
			if(hoverObject.GetComponentInChildren<Toggle>().isOn)
				isMouseInverOn = "Yes";
			else
				isMouseInverOn = "No";
			return objectText + " - Is Mouse Inversion enabled? " + isMouseInverOn;
			break;
		case "MasterLevelText":
			return objectText + " - Current Master Audio Level : " + hoverObject.GetComponentInChildren<Slider>().value;
			break;
		case "EffectText":
			return objectText + " - Current Effects Audio Level : " + hoverObject.GetComponentInChildren<Slider>().value;
			break;
		case "VoiceText":
			return objectText + " - Current Voice Audio Level : " + hoverObject.GetComponentInChildren<Slider>().value;
			break;
		case "MusicText":
			return objectText + " - Current Music Audio Level : " + hoverObject.GetComponentInChildren<Slider>().value;
			break;
		case "ResolutionText":
			return objectText + " - Current Resolution : " + UnityStats.screenRes;
			break;
		case "FullScreenText":
			string isFullScreenOn;
			if(hoverObject.GetComponentInChildren<Toggle>().isOn)
				isFullScreenOn = "Yes";
			else
				isFullScreenOn = "No";
			return objectText + " - Is Full Screen enabled? " + isFullScreenOn;
			break;
		case "BrightnessText":
			return objectText + " - Current Brightness Level : " + hoverObject.GetComponentInChildren<Slider>().value;
			break;
		case "GraphicsText":
			return objectText + " - Current Graphics Level : "; // TODO What do we add here?
			break;
		case "AntialiasingText":
			return objectText + " - Current Antialiasing Setting : "; // TODO What do we add here?
			break;
		case "FilteringText":
			return objectText + " - Current Filtering Setting : "; // TODO What do we add here?
			break;
		default:
			return "No tool tip found...";
			break;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
