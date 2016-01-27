using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadingScreen : MonoBehaviour {

	//public InventoryScript inventory;
	public PauseMenu pauseMenu;
	public List<GameObject> loadingCircles;

	int numObjects;
	
	float angle = 0f;
	float timer = 0f;
	float rad = 250f;
	
	void Update () {
		
		numObjects = loadingCircles.Count; 
		
		if(/*inventory.RPressed && */!pauseMenu.escKey)
		{
			for(int i = 0; i < loadingCircles.Count; i++)
			{
				
				timer += 0.005f;
				angle = timer;
				float theta = (2 * Mathf.PI / numObjects) * i+1;
				loadingCircles[i].GetComponent<RectTransform>().anchoredPosition = 
					new Vector2 ((Mathf.Sin(theta*angle) * rad), (Mathf.Cos(theta*angle) * rad));
				
			}
			
		}
		
	}

}
