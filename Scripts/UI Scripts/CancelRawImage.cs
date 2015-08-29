using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Analysis disable CheckNamespace
public class CancelRawImage : MonoBehaviour {
// Analysis restore CheckNamespace

	RawImage rawImage;
	public CircuitFound foundObj;

	// Use this for initialization
	void Start () {
	
		rawImage = GameObject.FindGameObjectWithTag ("RawImage").GetComponent<RawImage>();
		rawImage.enabled = false;

	}

	
	// Update is called once per frame
	void FixedUpdate () {

		if (foundObj.fuseFound) {
				
				rawImage.enabled = true;

		}
	
	}
}
