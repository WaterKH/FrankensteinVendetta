//TODO Fix this code
using UnityEngine;
using System.Collections;

public class StifleBreathOrCoverLight : MonoBehaviour {

	public bool allowedToStifleBreath;
	public bool allowedToCoverLight;	
	public bool running;
	public bool breathingHard;
	public bool breathingSoft;
	public static bool canBeHeard;
	public static bool stifleBreath;
	public static bool coverLight;
	bool hasNotStarted = true;

	public float timeSpentRunning = 0.0f;

	void Start () {

		allowedToStifleBreath = false;
		running = false;
		breathingHard = false;
		breathingSoft = true;

	}

	//TODO Figure out how to set it up so that you can stifle breath or cover your light.
	// This means I need to figure out what I want as conditions to do either of these.
	void Update () {

		if(InputManager.GetKey("run"))
			running = true; 
		else
			running = false;
		
		if(running)
		{
			breathingHard = true;
			breathingSoft = false;
			allowedToStifleBreath = true;
			hasNotStarted = true;
		}
		else
		{
			StartCoolDown();
		}

		if(breathingHard)
		{
			canBeHeard = true;
		}
		
		if(breathingSoft)
		{
			canBeHeard = false;
		}

		if(allowedToStifleBreath)
		{
			if(InputManager.GetKey("stifleBreathORCoverLight"))
			{
				Debug.Log("Stifling breath");
				stifleBreath = true;
			}
			else
				stifleBreath = false;
		}
		else
		{
			if(InputManager.GetKey("stifleBreathORCoverLight"))
			{
				Debug.Log("Covering light");
				coverLight = true;
			}
			else
				coverLight = false;
		}
				
	}

	public void StartCoolDown()
	{

		if(hasNotStarted)
		{
			hasNotStarted = false;
			Debug.Log("Cooling Down..");
			StartCoroutine(CoolDown());
		}

	}

	IEnumerator CoolDown()
	{

		//Add a multiplier to this to read how long we should be cooling down for. TODO
		yield return new WaitForSeconds(5.0f * timeSpentRunning);
		breathingHard = false;
		breathingSoft = true;
		Debug.Log("Cooling Complete");
	}

}
