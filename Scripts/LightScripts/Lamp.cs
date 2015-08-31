//Under Lamp on PointLight FrankensteinChapter1
using UnityEngine;
using System.Collections;

public class Lamp : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	
		if(GetComponent<Light>().intensity > 0.0f)
			IntensityChanging ();

	}

	void IntensityChanging()
	{
		float lampIntensity = 0f;
		//Lerps the intensity of light until it is 0
		GetComponent<Light>().intensity = Mathf.Lerp(GetComponent<Light>().intensity, lampIntensity, Time.deltaTime / 5);

	}

}
