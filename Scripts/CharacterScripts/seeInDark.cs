using UnityEngine;
using System.Collections;

public class seeInDark : MonoBehaviour {
	
	public Light directLight;
	
	void OnTriggerExit(Collider other){

		float newDirectLight = directLight.intensity;

		if(other.tag == "light")
			Mathf.Lerp(newDirectLight, 4.0f, Time.deltaTime);

	}

	void OnTriggerEnter(Collider other){

		float newDirectLight = directLight.intensity;

		if(other.tag == "light")
				Mathf.Lerp (newDirectLight, 0f, Time.deltaTime);

	}

}
