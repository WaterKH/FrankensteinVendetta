using UnityEngine;
using System.Collections;

public class glassUse : MonoBehaviour {

	public Camera secCamera;
	public MeshRenderer glassRen;
	public BoxCollider glassCol;

	public Inputs inputs;

	// Update is called once per frame
	void Update () {

		//TODO FIX GLITCH
		/*
		if (Input.inputString.Equals(inputs.lookBehind)) {
			secCamera.GetComponent<Camera>().enabled = !secCamera.GetComponent<Camera>().enabled;
			glassCol.enabled = !glassCol.enabled;
			glassRen.enabled = !glassRen.enabled;

		} 
*/
	}

}
