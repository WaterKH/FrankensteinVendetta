//TODO Used for the Demo at IndieBits, Need to see if we will use this actually
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemsInInventory : MonoBehaviour {

		public List<GameObject> Inventory = new List<GameObject>();
		Ray ray;
		RaycastHit hit;
		public GameObject Fuse;

		public CircuitFound circuitFound;

		public List<GameObject> LightList = new List<GameObject>();

		void Awake()
		{

				LightList.AddRange(GameObject.FindGameObjectsWithTag("hospitalLight"));

		}

	void Update ()
	{
		
		if (circuitFound.fuseFound) {	
			foreach (GameObject aLight in LightList)
				aLight.GetComponent<Light> ().enabled = true;
		
		}
	}
}