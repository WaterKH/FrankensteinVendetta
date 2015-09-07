using UnityEngine;
using System.Collections;

public class Match : MonoBehaviour {

	public MatchBoxScript matchScript;
	public Inputs inputs;
	public FPSwalkerEnhanced walkerEn;

	public Light matchLight;
	bool canRun;
	int runningNumb;
	// Update is called once per frame
	void Update ()
	{

		if (InputManager.GetKeyDown("lightMatch") && !walkerEn.running) {
			if (matchScript.match >= 1)
			{
				matchScript.counting = !matchScript.counting;
				matchScript.timeLeft = 30;
				runningNumb++;

				if(runningNumb == 1)
				{

					StartCoroutine (CountDown ());

				}
				StartCoroutine (MatchCounter ());
			}
			else if(matchScript.match == 0)
			{

				matchScript.counting = false;
				matchScript.timeLeft = 30;
				canRun = false;
				StopCoroutine(CountDown());

			}

		}


		if (matchScript.timeLeft <= 0 && matchLight && matchLight.enabled) {
			matchLight.enabled = false;
			matchScript.counting = !matchScript.counting;
			matchScript.timeLeft = 30;
			canRun = false;
			StopCoroutine(CountDown());
		}

		if (matchScript.counting)
			matchScript.matchStickGO.GetComponent<MeshRenderer>().enabled = true;
		else
			matchScript.matchStickGO.GetComponent<MeshRenderer>().enabled = false;

		if (InputManager.GetKey("run")) {    	
			matchLight.enabled = false;

			if (matchScript.counting)
				matchScript.counting = false;
			matchScript.timeLeft = 30;
		}

	}

	IEnumerator CountDown()
	{

		if(matchScript.match >= 0)
       	{
         	if(matchScript.counting && matchScript.timeLeft > 0)
         	{
	          	matchScript.timeLeft--;
				yield return new WaitForSeconds(1);
				
				StartCoroutine(CountDown());
         	}
			else
			{
				
				StopCoroutine(CountDown());
				runningNumb = 0;

			}	

       	}


	}

	IEnumerator MatchCounter()
	{        


	    if(matchScript.match >= 1)
	    {
	       if(InputManager.GetKeyDown("lightMatch"))
	       {
	         if(!matchLight.enabled)
	         {
	          	matchLight.enabled = true;
	         	matchScript.match--;
	         }
	         else { 
	         	matchLight.enabled = false;
	         }
	       }
	       yield return new WaitForSeconds(1);
	    }
	}

}
