using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeUI : MonoBehaviour {

	public CanvasGroup UIGroup;
	public CanvasGroup NonUIGroup;
	Vector2[] finalTrans;
	Vector2[] initialTrans;
	public GameObject[] objToMove;
	public bool[] reached;
	public int index = 0;
	public int prevIndex = 0;

	public GameObject defaultObject;
	public GameObject saveObject;

	bool UIBool = false;

	void Awake()
	{

		finalTrans = new Vector2[objToMove.Length];
		initialTrans = new Vector2[objToMove.Length];
		reached = new bool[objToMove.Length];

		for(int i = 0; i < objToMove.Length; i++)
		{

			initialTrans[i] = objToMove[i].GetComponent<RectTransform>().anchoredPosition;
			if(i < 3)
				finalTrans[i] = new Vector2(objToMove[i].GetComponent<RectTransform>().anchoredPosition.x,
				                            objToMove[i].GetComponent<RectTransform>().anchoredPosition.y+40f);
			else
				finalTrans[i] = new Vector2(objToMove[i].GetComponent<RectTransform>().anchoredPosition.x,
				                            objToMove[i].GetComponent<RectTransform>().anchoredPosition.y-45f);

		}

	}

	public void changeToUI()
	{
		if(UIBool)
		{
			UIGroup.alpha = 1;
			UIGroup.interactable = true;
			UIGroup.blocksRaycasts = true;

			NonUIGroup.alpha = 0;
			NonUIGroup.interactable = false;
			NonUIGroup.blocksRaycasts = false;

			initialTrans[3] = new Vector2(objToMove[3].GetComponent<RectTransform>().anchoredPosition.x,
			                              objToMove[3].GetComponent<RectTransform>().anchoredPosition.y+160f);
			initialTrans[4] = new Vector2(objToMove[4].GetComponent<RectTransform>().anchoredPosition.x,
			                              objToMove[4].GetComponent<RectTransform>().anchoredPosition.y+160f);

			objToMove[3].GetComponent<RectTransform>().anchoredPosition = new Vector2(
				objToMove[3].GetComponent<RectTransform>().anchoredPosition.x,
				objToMove[3].GetComponent<RectTransform>().anchoredPosition.y+160f);
			objToMove[4].GetComponent<RectTransform>().anchoredPosition = new Vector2(
				objToMove[4].GetComponent<RectTransform>().anchoredPosition.x,
				objToMove[4].GetComponent<RectTransform>().anchoredPosition.y+160f);

			finalTrans[3] = new Vector2(objToMove[3].GetComponent<RectTransform>().anchoredPosition.x,
			                            objToMove[3].GetComponent<RectTransform>().anchoredPosition.y-45f);
			finalTrans[4] = new Vector2(objToMove[4].GetComponent<RectTransform>().anchoredPosition.x,
			                            objToMove[4].GetComponent<RectTransform>().anchoredPosition.y-45f);

			defaultObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(
				defaultObject.GetComponent<RectTransform>().anchoredPosition.x,
				defaultObject.GetComponent<RectTransform>().anchoredPosition.y+160f);
			saveObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(
				saveObject.GetComponent<RectTransform>().anchoredPosition.x,
				saveObject.GetComponent<RectTransform>().anchoredPosition.y+160f);

			UIBool = false;

		}

	}

	public void changeToNonUI()
	{
		if(!UIBool)
		{
			UIGroup.alpha = 0;
			UIGroup.interactable = false;
			UIGroup.blocksRaycasts = false;
			
			NonUIGroup.alpha = 1;
			NonUIGroup.interactable = true;
			NonUIGroup.blocksRaycasts = true;

			initialTrans[3] = new Vector2(objToMove[3].GetComponent<RectTransform>().anchoredPosition.x,
			                              objToMove[3].GetComponent<RectTransform>().anchoredPosition.y-160f);
			initialTrans[4] = new Vector2(objToMove[4].GetComponent<RectTransform>().anchoredPosition.x,
			                              objToMove[4].GetComponent<RectTransform>().anchoredPosition.y-160f);

			objToMove[3].GetComponent<RectTransform>().anchoredPosition = new Vector2(
				objToMove[3].GetComponent<RectTransform>().anchoredPosition.x,
				objToMove[3].GetComponent<RectTransform>().anchoredPosition.y-160f);
			objToMove[4].GetComponent<RectTransform>().anchoredPosition = new Vector2(
				objToMove[4].GetComponent<RectTransform>().anchoredPosition.x,
				objToMove[4].GetComponent<RectTransform>().anchoredPosition.y-160f);

			finalTrans[3] = new Vector2(objToMove[3].GetComponent<RectTransform>().anchoredPosition.x,
			                            objToMove[3].GetComponent<RectTransform>().anchoredPosition.y-45f);
			finalTrans[4] = new Vector2(objToMove[4].GetComponent<RectTransform>().anchoredPosition.x,
			                            objToMove[4].GetComponent<RectTransform>().anchoredPosition.y-45f);

			defaultObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(
				defaultObject.GetComponent<RectTransform>().anchoredPosition.x,
				defaultObject.GetComponent<RectTransform>().anchoredPosition.y-160f);
			saveObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(
				saveObject.GetComponent<RectTransform>().anchoredPosition.x,
				saveObject.GetComponent<RectTransform>().anchoredPosition.y-160f);

			UIBool = true;

		}

	}

	public void slideIntoView_FINAL(RectTransform aTrans)
	{
	
		reached[index] = false;
		prevIndex = index;

	}

	public void slideIntoView_INIT(RectTransform aTrans)
	{

		for(int i = 0; i < objToMove.Length; i++)
			if(objToMove[i] == aTrans.gameObject)
				index = i;

		reached[index] = true;

	}

	void Update()
	{
		if(reached[index])
		{
			objToMove[index].GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(
				objToMove[index].GetComponent<RectTransform>().anchoredPosition, finalTrans[index], 
				Time.deltaTime*7);

			if(prevIndex != index)
				objToMove[prevIndex].GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(
					objToMove[prevIndex].GetComponent<RectTransform>().anchoredPosition, initialTrans[prevIndex], 
					Time.deltaTime*7);

		}
		else if(!reached[index])
		{
			objToMove[index].GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(
				objToMove[index].GetComponent<RectTransform>().anchoredPosition, initialTrans[index], 
				Time.deltaTime*7);

		}

	}

}