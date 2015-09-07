using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeHelpMenuText : MonoBehaviour {

	public Text helpText;
	string initialText;
	bool isOn;
	IEnumerator waitEnum;
	
	void Awake()
	{

		waitEnum = Wait();
		initialText = helpText.text;
		
	}
	
	public void resetText()
	{
		
		helpText.text = initialText;
		
	}
	
	public void selectedText(string aKey)
	{
		
		helpText.text = "Selected key: "+aKey;
		isOn = false;
		
	}
	
	public void changedText(string aKey)
	{
		if(aKey.Equals("This key has already been binded, please choose another one"))
			helpText.text = aKey;
		else
			helpText.text = "Changed to: "+aKey;
		isOn = true;
		StartCoroutine(Wait());
		
	}
	
	IEnumerator Wait()
	{
		
		yield return new WaitForSeconds(3f);
		if(isOn)
			resetText();
		
	}

}
