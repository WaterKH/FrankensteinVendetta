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
	public SaveLoad saveLoad;

	public CanvasGroup askToSaveGroup;
	static CanvasGroup askToSaveGroup_STATIC;
	public static bool hasSaved;
	string userName;

	void Awake()
	{

		askToSaveGroup_STATIC = askToSaveGroup;

	}

	public void SaveKeyboard()
	{
		Debug.Log("Saving..");
		BinaryFormatter bf = new BinaryFormatter();
		Debug.Log(userName);
		FileStream file = File.Create(Application.persistentDataPath + "/" + userName + "KeyboardInfo.dat");
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
		Debug.Log("Save Successful!");
		
	}

	public void LoadKeyboard(string aUserName)
	{

		userName = aUserName;
		Keyboard.resetKeyboard();
		AllKeys.removeLegend();
		Debug.Log("Loading Keyboard for " + aUserName);
		if (File.Exists (Application.persistentDataPath + "/" + aUserName + "KeyboardInfo.dat")) 
		{

			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/" + aUserName + "KeyboardInfo.dat", FileMode.Open);
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
			Debug.Log("Keyboard data found for: " + aUserName);
			
		}
		else
		{

			InputManager.inputManagerList = inputManager.inputManagerList_FROM_INSPECTOR;
			Debug.Log("No Keyboard data found - Using Inspector setup");
			inputManager.CONFIGURE_LAYOUT();
			SaveKeyboard();
			
		}
		
	}
	//TODO Make hasSaved change depending on if any input has been changed
	public void askToSaveCall()
	{

		askToSave();

	}

	private static void askToSave()
	{

		if(!hasSaved)
		{

			askToSaveGroup_STATIC.alpha = 1;
			askToSaveGroup_STATIC.interactable = true;
			askToSaveGroup_STATIC.blocksRaycasts = true;

		}
		else
		{

			KeyboardVisible.invisibleKeyboard();

		}

	}

	public void dontAskToSaveCall()
	{

		dontAskToSave();

	}

	private static void dontAskToSave()
	{
		
		if(!hasSaved)
		{
			
			askToSaveGroup_STATIC.alpha = 0;
			askToSaveGroup_STATIC.interactable = false;
			askToSaveGroup_STATIC.blocksRaycasts = false;
			
		}

	}

}


[Serializable]
class KeyboardDataSer
{

	public List<InputManager.INPUT_CLASS_FOR_DATA_STORAGE> inputManagerList;
	
}

