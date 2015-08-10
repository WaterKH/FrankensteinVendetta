using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class SaveLoadKeyboard : MonoBehaviour {

	public ButtonSerializable buttonSer = new ButtonSerializable();
	public InputManager inputManager;
	public AllKeys allKeys;

	public void SaveKeyboard()
	{
		
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/KeyboardInfo.dat");
		KeyboardDataSer keyData = new KeyboardDataSer();
		
		keyData.keyCodes = new List<string>();
		keyData.buttonTags = new List<string>();
		keyData.buttonNames = new List<string>();
		keyData.hoverHelperDictKey = new List<string>();
		keyData.hoverHelperValue = new List<string>();
		keyData.legendDictKey = new List<string>();
		keyData.legendDictValue = new List<string>();
		keyData.legendList = new List<string>();
		
		foreach(KeyValuePair<string, Inputs> input in Inputs.inputDict)
		{
			
			keyData.keyCodes.Add(input.Value.getInputKeyCode().ToString());
			keyData.buttonTags.Add(input.Key);
			keyData.buttonNames.Add(input.Value.getInputButton().name);
			
		}
		
		
		foreach(KeyValuePair<string, string> input in HoverKeyboard.hoverHelperText)
		{
			
			keyData.hoverHelperDictKey.Add(input.Key);
			keyData.hoverHelperValue.Add(input.Value);
			
		}
		
		foreach(KeyValuePair<string, string> input in HoverKeyboard.legendText)
		{
			
			keyData.legendDictKey.Add(input.Key);
			keyData.legendDictValue.Add(input.Value);
			
		}
		
		foreach(Button input in AllKeys.legendList)
			keyData.legendList.Add(buttonSer.returnButtonText(input));
		
		bf.Serialize(file, keyData);
		file.Close();
		
	}
	
	//TODO Fix the userName 
	public void LoadKeyboard()
	{
		
		if (File.Exists (Application.persistentDataPath + "/KeyboardInfo.dat")) {
			
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/KeyboardInfo.dat", FileMode.Open);
			KeyboardDataSer keyData = (KeyboardDataSer)bf.Deserialize(file);
			file.Close();
			
			Inputs.inputDict = new Dictionary<string, Inputs>();
			HoverKeyboard.hoverHelperText = new Dictionary<string, string>();
			HoverKeyboard.legendText = new Dictionary<string, string>();
			AllKeys.legendList = new List<Button>();
			KeyboardTags.keyboardTagsList = new List<string>();
			
			for(int i = 0; i < keyData.keyCodes.Count; i++)
			{
				
				
				inputManager.setKey(buttonSer.getButtonSer(keyData.buttonNames[i], keyData.buttonTags[i]), keyData.keyCodes[i]);
				KeyboardTags.keyboardTags(keyData.buttonTags[i]);
				
			}
			
			allKeys.objectsForDefaultClass();
			
		}
		else
		{
			
			Debug.Log("No Keyboard data found");
			inputManager.DEFAULT_LAYOUT();
			
		}
		
	}

}


[Serializable]
class KeyboardDataSer
{
	
	//Tags on buttons, Keycode, Button String
	public List<string> keyCodes;
	public List<string> buttonTags;
	public List<string> buttonNames;
	
	public List<string> hoverHelperDictKey;
	public List<string> hoverHelperValue;
	
	public List<string> legendDictKey;
	public List<string> legendDictValue;
	
	public List<string> legendList;
	
}

