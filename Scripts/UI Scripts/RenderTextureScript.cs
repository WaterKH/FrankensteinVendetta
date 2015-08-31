using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//TODO AHHHHH FIXXXXXXXXX
public class RenderTextureScript : MonoBehaviour {

	public GameObject position;
	public GameObject nextPos;
	public GameObject canvasPos;

	public OnItemClick itemClick;
	//TODO Save this
	public List<Camera> rendTextCameras;

	float angle; 

	public void CreateRendTexture(GameObject item)
	{

		RenderTexture rendTexture = new RenderTexture(256, 256, 16);
		rendTexture.Create();
		GameObject rendCamera = Instantiate(Resources.Load("InventoryCam")) as GameObject;
		rendCamera.transform.parent = position.transform;
		if(nextPos != null)
			rendCamera.transform.position = new Vector3(nextPos.transform.position.x+10f, nextPos.transform.position.y,
			                                            nextPos.transform.position.z);
		else
			rendCamera.transform.position = new Vector3(position.transform.position.x+10f, position.transform.position.y,
		                                          	  position.transform.position.z);

		nextPos = rendCamera;
		GameObject itemClone = Instantiate(item) as GameObject;
		itemClone.transform.parent = nextPos.transform;
		itemClone.transform.position = new Vector3(nextPos.transform.position.x, nextPos.transform.position.y,
		                                      nextPos.transform.position.z+0.5f);

		itemClone.transform.rotation = new Quaternion(itemClone.transform.rotation.x, itemClone.transform.rotation.y,
		                                              itemClone.transform.rotation.z, itemClone.transform.rotation.w);

		itemClone.GetComponent<Renderer>().enabled = true;
		rendCamera.GetComponent<Camera>().targetTexture = rendTexture;
		GameObject inventoryImage = new GameObject();
		rendTexture.name = item.name+"texture";
		inventoryImage.name = item.name;
		itemClone.layer = 8;
		inventoryImage.transform.parent = canvasPos.transform;
		inventoryImage.AddComponent<RawImage>();
		inventoryImage.GetComponent<RawImage>().texture = rendTexture;
		itemClick.ItemClick (inventoryImage, true);
		itemClick.ItemClick (itemClone, false);
		rendTextCameras.Add(rendCamera.GetComponent<Camera>());

	}

}
