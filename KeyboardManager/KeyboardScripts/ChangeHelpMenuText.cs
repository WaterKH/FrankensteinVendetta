using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeHelpMenuText : MonoBehaviour {

	public Text helpText;
	string initialText;
	bool isOn;
	
	void Awake()
	{
		
		initialText = helpText.text;
		
	}
	
	public void resetText()
	{
		
		helpText.text = initialText;
		isOn = false;
		
	}
	
	public void selectedText(string aKey)
	{
		
		helpText.text = "Selected key: "+aKey;
		StopCoroutine(Wait());
		isOn = false;
	}
	
	public void changedText(string aKey)
	{
		if(aKey.Equals("This key has already been binded, choose another one"))
			helpText.text = aKey;
		else
			helpText.text = "Changed to: "+aKey;
		StartCoroutine(Wait());
		isOn = true;
		
	}
	
	IEnumerator Wait()
	{
		Debug.Log(initialText);
		yield return new WaitForSeconds(3f);
		if(isOn)
			resetText();
		
	}
	
}