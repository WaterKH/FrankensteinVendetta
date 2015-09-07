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
				                            objToMove[i].GetComponent<RectTransform>().anchoredPosition.y+30f);
			else
				finalTrans[i] = new Vector2(objToMove[i].GetComponent<RectTransform>().anchoredPosition.x,
				                            objToMove[i].GetComponent<RectTransform>().anchoredPosition.y-30f);

		}

	}

	public void changeToUI()
	{

		UIGroup.alpha = 1;
		UIGroup.interactable = true;
		UIGroup.blocksRaycasts = true;

		NonUIGroup.alpha = 0;
		NonUIGroup.interactable = false;
		NonUIGroup.blocksRaycasts = false;
		
	}

	public void changeToNonUI()
	{
		
		UIGroup.alpha = 0;
		UIGroup.interactable = false;
		UIGroup.blocksRaycasts = false;
		
		NonUIGroup.alpha = 1;
		NonUIGroup.interactable = true;
		NonUIGroup.blocksRaycasts = true;

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