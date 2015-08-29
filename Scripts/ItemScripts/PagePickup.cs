//On Note in FrankensteinChapter1
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PagePickup : MonoBehaviour {

	bool isActivated;
	float elapsedTime;
	float canvasTime;
	public CanvasGroup pageAlpha;
	RenderTextureScript rendTexture;
	bool hasRan = false;

	void Awake()
	{

		rendTexture = GameObject.Find ("FPC").GetComponent<RenderTextureScript>();

	}

	//If the User clicks on the Collider
	void OnMouseDown()
	{
		//Renderer and Collider invisible
		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<Collider>().enabled = false;

		isActivated = true;
		elapsedTime = 0;
		canvasTime = 0;
		if(!hasRan)
		{
			rendTexture.CreateRendTexture(gameObject);
			hasRan = true;

		}

	}

	void Update ()
	{

		//isActivated by OnMouseDown()
		if (isActivated) 
		{

			elapsedTime += Time.deltaTime;
			//Displays the "Added note to Journal" 
			pageAlpha.alpha = Mathf.Lerp (0, 1, elapsedTime);
			if (elapsedTime >= 10) {

				canvasTime += Time.deltaTime;
				//Slowly lerps to invisible
				pageAlpha.alpha = Mathf.Lerp(1, 0, canvasTime);
				if(pageAlpha.alpha <= 0)
				{
					//Breaks loop and sets the object to false to save on resources
					isActivated = false;
					gameObject.SetActive(false);

				}
			}
		}
	}
}
