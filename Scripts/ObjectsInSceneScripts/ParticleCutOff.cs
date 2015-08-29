using UnityEngine;
using System.Collections;

public class ParticleCutOff : MonoBehaviour {

	public ParticleEmitter particleToDim;
	float timer = 11;    
	float particleSize; //ParticleEmitter;

	void Awake()
	{
			particleToDim.emit = true;
	}

	void Update(){

		timer -= Time.deltaTime;

		SlowDimSize();
		float particleMinEmit = 0;
		float particleMaxEmit = 30;

		float emission = Mathf.Lerp(particleMaxEmit, particleMinEmit, Time.deltaTime);

		if(timer <= 0){
				timer = 0;
				particleToDim.emit = false;

		}
	}

	void SlowDimEmit(){

		float particleMinEmit = 0;
		float particleMaxEmit = 30;

		float emission = Mathf.Lerp(particleMaxEmit, particleMinEmit, Time.deltaTime);

	}

	void SlowDimSize(){

		float intensityC = 0;

		particleSize = intensityC;

		//particleSize.maxEmission = Mathf.Lerp(ParticleEmitter, particleSize, Time.deltaTime / 5);

	}
}
