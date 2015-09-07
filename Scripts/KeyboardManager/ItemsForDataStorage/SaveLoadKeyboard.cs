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
	public KeyboardVisible keyboardVisible;

	public CanvasGroup askToSaveGroup;
	public bool hasSaved;

	public void SaveKeyboard()
	{
		
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/KeyboardInfo.dat");
		KeyboardDataSer keyData = new KeyboardDataSer();
		keyData.inputManagerList = new List<InputManager.INPUT_CLASS_FOR_DATA_STORAGE>();

		foreach(InputManager.INPUT_CLASS inputClass in InputManager.inputManagerList)
		{
			InputManager.INPUT_CLASS_FOR_DATA_STORAGE tempInputClass = 
				new InputManager.INPUT_CLASS_FOR_DATA_STORAGE(inputClass.Input, buttonSer.returnButtonSer(inputClass.Key),
											inputClass.Type, inputClass.Tag, inputClass.Name);

			keyData.inputManagerList.Add(tempInputClass);
		}

		bf.Serialize(file, keyData);
		file.Close();

		hasSaved = true;
		
	}

	public void LoadKeyboard()
	{

		Keyboard.resetKeyboard();
		AllKeys.removeLegend();

		if (File.Exists (Application.persistentDataPath + "/KeyboardInfo.dat")) 
		{

			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/KeyboardInfo.dat", FileMode.Open);
			KeyboardDataSer keyData = (KeyboardDataSer)bf.Deserialize(file);
			file.Close();

			InputManager.inputManagerList = new List<InputManager.INPUT_CLASS>();
			Inputs.inputDict = new Dictionary<string, Inputs>();
			AllKeys.legendList = new List<Button>();

			foreach(InputManager.INPUT_CLASS_FOR_DATA_STORAGE inputClass in keyData.inputManagerList)
			{
				
				InputManager.INPUT_CLASS tempInputClass = new InputManager.INPUT_CLASS(
					inputClass.Input, buttonSer.getButtonSer(inputClass.Key.buttonName, 
				    inputClass.Key.buttonTag), inputClass.Type, inputClass.Tag, inputClass.Name);

				InputManager.inputManagerList.Add(tempInputClass);
				
			}
			for(int i = 0; i < keyData.inputManagerList.Count; i++)
			{
				
				inputManager.setKey(InputManager.inputManagerList[i]);
				AllKeys.INITIAL_LIST_LEGEND(keyData.inputManagerList[i].Name, keyData.inputManagerList[i].Tag);
				
			}

			Keyboard.KeyboardTags.keyboardTagsAndTypes();
			
		}
		else
		{
			
			Debug.Log("No Keyboard data found");
			inputManager.CONFIGURE_LAYOUT();
			
		}
		
	}
	//TODO Make hasSaved change depending on if any input has been changed
	public void askToSave()
	{

		if(!hasSaved)
		{

			askToSaveGroup.alpha = 1;
			askToSaveGroup.interactable = true;
			askToSaveGroup.blocksRaycasts = true;

		}
		else
		{

			keyboardVisible.invisibleKeyboard();

		}

	}

}


[Serializable]
class KeyboardDataSer
{

	public List<InputManager.INPUT_CLASS_FOR_DATA_STORAGE> inputManagerList;
	
}

