//TODO Is this being Used? If so, is it necessary?
using UnityEngine;
using System.Collections;

public class CircuitBoardGUI : MonoBehaviour {

		Ray ray;
		RaycastHit hit;
		public Camera camObj;
		public float alphaFadeValue = 0.5f;
		private CirGUI currentGUIState;

		public enum CirGUI
		{

			Normal,
			CircuitG

		}

	// Use this for initialization
	void Awake () {
	
		camObj = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (camObj.enabled)
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if(Input.GetMouseButtonDown(0))
		{
						if (Physics.Raycast(ray, out hit,100))
			{

				if(hit.collider.gameObject.tag == "CircuitBoard")
				{
					TransitionToState(CirGUI.CircuitG);
										Debug.Log ("Ran");
				}

			}

		}

	}

	void OnGUI()
	{
		switch (currentGUIState) 
		{
		case CirGUI.Normal:
			alphaFadeValue = 0f;

			break;
		case CirGUI.CircuitG:
			alphaFadeValue = 0.5f;
			GUI.color = new Color (alphaFadeValue, alphaFadeValue, alphaFadeValue, alphaFadeValue);
			DrawCircuitBoard ();
			break;
		}
	}

	void TransitionToState(CirGUI gui)
	{
		currentGUIState = gui;

		switch (currentGUIState) 
		{

		case CirGUI.Normal:
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			break;
		case CirGUI.CircuitG:
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			break;

		}

	}

	void DrawCircuitBoard()
	{
		
			
	}
}
