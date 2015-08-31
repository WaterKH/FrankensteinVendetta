using UnityEngine;
using System.Collections;

public class CanvasCircuit : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	GameObject camObject;
	public GameObject circuitBoard;
	
	// Use this for initialization
	void Start () {
	
		camObject = GameObject.FindGameObjectWithTag ("MainCamera");
		circuitBoard = GameObject.FindGameObjectWithTag ("CircuitBoardCam");

	}
	
	// Update is called once per frame
	void Update () {

		if(FVAPI.playerClicked(100, camObject, "CircuitBoard"))
			circuitBoard.SetActive (true);
	
	}

}
