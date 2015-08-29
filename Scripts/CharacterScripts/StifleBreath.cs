//TODO Fix this code
using UnityEngine;
using System.Collections;

public class StifleBreath : MonoBehaviour {

	bool stifleBreath;
	bool running;
	bool breathingHard;
	bool breathingSoft;

	void Start () {

		stifleBreath = false;
		running = false;
		breathingHard = false;
		breathingSoft = true;

	}

	void Update () {

		if(InputManager.GetKey(KeyboardTags.run))
			running = true; 

		if(!InputManager.GetKey(KeyboardTags.run))
			running = false;

		if(running == true)
			stifleBreath = true;

		if(stifleBreath == true)
			breathingHard = true;

		if(breathingHard == true)
			breathingSoft = false;
		
		if(breathingSoft == true)
			breathingHard = false;

		if(running == false)
			breathingSoft = true;
				
	}
}
