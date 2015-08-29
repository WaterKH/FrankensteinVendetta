using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {


	public float minLightIntensity = 0.5f;
	public float maxLightIntensity = 2.0f;
	public float minVariationFactor = 0.9f; //1.0 => no variation
	public float maxVariationFactor = 1.1f; //...
	public float speedFactor = 2.0f; //1.0 => normal speed

	float variationFactor;
	public GameObject LightObj;

	void FixedUpdate()
	{
		
		variationFactor = Random.Range(minVariationFactor, maxVariationFactor);
		
	}

	// Update is called once per frame
	void Update () 
	{
		//Randomly pingpongs the light to random intensities
		LightObj.GetComponent<Light>().intensity = (minLightIntensity + Mathf.PingPong(Time.time * speedFactor, maxLightIntensity)) * variationFactor;
	
	}

}
