using UnityEngine;
using System.Collections;

public class InventoryScript : MonoBehaviour {

	public Camera mainCamera;
	public PauseMenu pauseMenu;
	public GameObject rucksack;
	public GameObject rucksack_INIT;
	public GameObject rucksack_END;
	public Quaternion initialRotation;

	//public CanvasGroup inventoryBack;
	//public CanvasGroup inventorySlots;

	public bool RPressed;
	public bool firstPass;

	//float elapsedTime = 0;
	//float canvasTime = 0;

	// Update is called once per frame
	void LateUpdate () {
		//TODO

		if (InputManager.GetKeyDown("inventory") || InputManager.GetKeyDown("inventorySecondary"))
		{
			RPressed = !RPressed;
			//elapsedTime = 0;
			//canvasTime = 0;
		}

		if (RPressed) 
		{
			if(firstPass)
			{
				initialRotation = mainCamera.transform.rotation;
				firstPass = false;
			}

			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;

			FVAPI.lerpVector3TimeMultiplied(rucksack.transform, rucksack_END.transform, 2);
			mainCamera.transform.LookAt(rucksack_END.transform);
			//elapsedTime += Time.deltaTime;
			//inventoryBack.alpha = Mathf.Lerp (inventoryBack.alpha, 1, elapsedTime);	
			//inventoryBack.blocksRaycasts = true;
			//Time.timeScale = Mathf.Lerp(Time.timeScale, 0f, elapsedTime*2);
			//if(Time.timeScale <= 0.4)
			//{

				//canvasTime += Time.deltaTime;
				//inventorySlots.alpha = Mathf.Lerp(inventorySlots.alpha, 1, canvasTime);
				//inventorySlots.interactable = true;
				//inventorySlots.blocksRaycasts = true;
				//xLook.GetComponent<MouseLook>().enabled = false;
				//yLook.GetComponent<MouseLook>().enabled = false;

			//}
		
		} 
		else if (!RPressed && !pauseMenu.escKey)
		{

			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;

			FVAPI.lerpVector3TimeMultiplied(rucksack.transform, rucksack_INIT.transform, 2);
			firstPass = true;
			FVAPI.lerpQuaternionTimeMultiplied(mainCamera.transform.rotation, initialRotation, 2);

			//xLook.GetComponent<MouseLook>().enabled = true;
			//yLook.GetComponent<MouseLook>().enabled = true;
			//canvasTime += Time.deltaTime;
			//inventorySlots.alpha = Mathf.Lerp(inventorySlots.alpha, 0, canvasTime);
			//inventorySlots.interactable = false;
			//inventorySlots.blocksRaycasts = false;
			/*if(inventorySlots.alpha <= 0)
			{

				elapsedTime += Time.deltaTime;
				inventoryBack.alpha = Mathf.Lerp (inventoryBack.alpha, 0, elapsedTime);	
				inventoryBack.blocksRaycasts = false;
				Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, elapsedTime);

			}*/	
		}
	}
}
