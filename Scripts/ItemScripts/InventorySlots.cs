using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour {

	public InventoryScript inventory;
	public PauseMenu pauseMenu;
	//TODO Add lists of inventory
	public RenderTextureScript rendTexture;

	//TODO add inventory to SaveLoad
	public List<RawImage> inventoryList;
	int numObjects;
	int listCount;
	float rad = 250f;
	public bool turnRight;

	void Awake()
	{

		inventoryList.Clear();

	}

	void Update () {

		numObjects = inventoryList.Count; 

		if(inventory.RPressed && !pauseMenu.escKey)
		{

			//TODO Add mouse functionality
			for(int i = 0; i < inventoryList.Count; i++)
			{

				float theta = (2 * Mathf.PI / numObjects) * i;
				inventoryList[i].GetComponent<RectTransform>().anchoredPosition = 
					new Vector2 ((Mathf.Sin(theta) * rad), (Mathf.Cos(theta) * rad));

			}

			//Used for rotation -- Not currently in use though
			/*foreach(GameObject item in playerStats.listInventoryObjects)
			{
					
				item.transform.rotation = 
					new Quaternion(
					   item.transform.rotation.x, 
		               item.transform.rotation.y,
					   item.transform.rotation.z+angle, 
						item.transform.rotation.w);

			}*/

			//Used to clear flags so there's no shadowing -- Not currently in use though
			/*foreach(Camera rendCam in rendTexture.rendTextCameras)
				rendCam.clearFlags = CameraClearFlags.SolidColor;*/

		}

	}

}