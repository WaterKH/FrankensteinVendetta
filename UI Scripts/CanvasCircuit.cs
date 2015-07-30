using UnityEngine;
using System.Collections;

public class CanvasCircuit : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	Camera camObject;
	public GameObject circuitBoard;
	
	// Use this for initialization
	void Start () {
	
				camObject = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
				circuitBoard = GameObject.FindGameObjectWithTag ("CircuitBoardCam");

	}
	
	// Update is called once per frame
	void Update () {

				if(camObject.enabled == true)
						ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Input.GetMouseButtonDown (0)) {       
						if (Physics.Raycast (ray, out hit, 100)) {
								if (hit.collider.gameObject.tag == "CircuitBoard")
										circuitBoard.SetActive (true);
						}
				}
	
	}
}
