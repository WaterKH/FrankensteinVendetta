//On Any Item that is PickupAble
using UnityEngine;
using System.Collections;

//Causes the Item that is able to be picked up to glow
//ONLY WORKS SO FAR WITH STANDARD SHADER
public class HoverItem : MonoBehaviour {

	//Instance variables
	Material itemMat;
	bool hovering;
	bool transition;
	float emission;
	Color baseColor;
	//Color initialColor;
	Color finalColor;

	//Called when the Users mouse enters the Collider
	void OnMouseEnter()
	{

		//Sets the itemMaterial variable to the current material on the object
		itemMat = GetComponent<Renderer>().material;
		baseColor = Color.blue;
		//initialColor = itemMat.color;
		//Enable emission
		itemMat.EnableKeyword("_EMISSION");
		hovering = true;
		transition = true;

	}

	//Called when the Users mouse exits the Collider
	void OnMouseExit()
	{

		hovering = false;
	
	}

	void Update () {

		if(hovering)
		{
			//if transition is true (Only true when the User initially enters)
			if(transition)
			{

				emission = Mathf.Lerp(emission, .9f, Time.deltaTime*4);
				finalColor = baseColor * Mathf.LinearToGammaSpace(emission/5);
				itemMat.SetColor("_EmissionColor", finalColor);
				//if the emission gets to .8f, then this if statements breaks
				if(emission > .8)
					transition = false;
			}
			//Once the emission gets to .8f this statement will run
			else
			{

				emission = Mathf.PingPong(Time.time, 1f);
				finalColor = baseColor * Mathf.LinearToGammaSpace(emission/5);
				itemMat.SetColor("_EmissionColor", finalColor);
				//Then the current material will be set to the itemMaterial variable
				GetComponent<Renderer>().material = itemMat;

			}

		}
		else

			//If the ItemMaterial is not null
			if(itemMat != null)
			{
				//Will lerp down to 0
				emission = Mathf.Lerp(emission, 0, Time.deltaTime*4);
				finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
				itemMat.SetColor("_EmissionColor", finalColor);

			}

	}

}
