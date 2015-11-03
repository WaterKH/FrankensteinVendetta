using UnityEngine;
using System.Collections;

public class InventoryScript : MonoBehaviour {

	public GameObject xLook;
	public GameObject yLook;
	public PauseMenu pauseMenu;
	public Inputs inputs;

	public CanvasGroup inventoryBack;
	public CanvasGroup inventorySlots;

	public bool RPressed;

	float elapsedTime = 0;
	float canvasTime = 0;

	// Update is called once per frame
	void LateUpdate () {
		//TODO

		if (InputManager.GetKeyDown("inventory") || InputManager.GetKeyDown("inventorySecondary"))
		{
			RPressed = !RPressed;
			elapsedTime = 0;
			canvasTime = 0;
		}

		if (RPressed) 
		{

			elapsedTime += Time.deltaTime;
			inventoryBack.alpha = Mathf.Lerp (inventoryBack.alpha, 1, elapsedTime);	
			inventoryBack.blocksRaycasts = true;
			Time.timeScale = Mathf.Lerp(Time.timeScale, 0f, elapsedTime*2);
			if(Time.timeScale <= 0.4)
			{

				canvasTime += Time.deltaTime;
				inventorySlots.alpha = Mathf.Lerp(inventorySlots.alpha, 1, canvasTime);
				inventorySlots.interactable = true;
				inventorySlots.blocksRaycasts = true;
				xLook.GetComponent<MouseLook>().enabled = false;
				yLook.GetComponent<MouseLook>().enabled = false;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;

			}
		
		} 
		else if (!RPressed && !pauseMenu.escKey)
		{
		
//			xLook.GetComponent<MouseLook>().enabled = true;
//			yLook.GetComponent<MouseLook>().enabled = true;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			canvasTime += Time.deltaTime;
			inventorySlots.alpha = Mathf.Lerp(inventorySlots.alpha, 0, canvasTime);
			inventorySlots.interactable = false;
			inventorySlots.blocksRaycasts = false;
			if(inventorySlots.alpha <= 0)
			{

				elapsedTime += Time.deltaTime;
				inventoryBack.alpha = Mathf.Lerp (inventoryBack.alpha, 0, elapsedTime);	
				inventoryBack.blocksRaycasts = false;
				Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, elapsedTime);

			}
		
		}

	}

}
