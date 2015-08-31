//On HintMarkers in FrankensteinChapter1
using UnityEngine;
using System.Collections;

public class HintScripts : MonoBehaviour {
	
	public CanvasGroup hintTextGroup;
	public CanvasGroup actualHintGroup;
	bool triggerEntered;
	float elapsedTime = 0f;
	float canvasTime = 0f;

	//If User enters the collider
	void OnTriggerEnter()
	{

		triggerEntered = true;
			
	}

	void Update()
	{
		//If User enters the collider..
		if (triggerEntered) {
				
			elapsedTime += Time.deltaTime;
			//The "Hint" text becomes visible
			FVAPI.lerpAlphaChannel(hintTextGroup, 1, elapsedTime);
			//hintTextGroup.alpha = Mathf.Lerp(hintTextGroup.alpha,1,elapsedTime);
			//as well as the actual hint text
			FVAPI.lerpAlphaChannel(actualHintGroup, 1, elapsedTime);
			//actualHintGroup.alpha = Mathf.Lerp (0, 1, elapsedTime);
			//After three seconds
			if (elapsedTime > 3) {
				canvasTime += Time.deltaTime;
				//The text disappears
				FVAPI.lerpAlphaChannel(hintTextGroup, 0, canvasTime/2);
				FVAPI.lerpAlphaChannel(actualHintGroup, 0, canvasTime/2);
				//hintTextGroup.alpha = Mathf.Lerp (hintTextGroup.alpha, 0, canvasTime/2);
				//actualHintGroup.alpha = Mathf.Lerp (1, 0, canvasTime / 2);
				//Once invisible, the triggerEntered bool becomes false
				if (hintTextGroup.alpha <= 0)
					triggerEntered = false;

			}

		}

	}

}
