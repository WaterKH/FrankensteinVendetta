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

				if((Input.GetKey("left shift"))){
						running = true; 

				}

				if((Input.GetKeyUp("left shift"))){
						running = false;

				}

				if(running == true){
						stifleBreath = true;
						//Debug.Log("Stifle your breath or the monsters will kill you.");
				}

				if(stifleBreath == true){
						breathingHard = true;
				}

				if(breathingHard == true){
						breathingSoft = false;
						//Debug.Log("Breathing hard.");

				}

				if(breathingSoft == true){
						breathingHard = false;
				}

				if(running == false){
						breathingSoft = true;
						//Debug.Log("Breathing softly.");

				}
		}
}
