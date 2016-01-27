//On MainCamera in MainMenu
//On FPC in FrankensteinChapter1
using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour {

	//Script instances
	public Player_MAIN playerData;
	public CameraStats cameraData;
	public Vector3Serial playerVector3Ser = new Vector3Serial();
	public QuaternionSerial playerQuatSer = new QuaternionSerial();
	public Vector3Serial cameraVector3Ser = new Vector3Serial();
	public QuaternionSerial cameraQuatSer = new QuaternionSerial();
	public CreateNewUser createUser;
	public PageFlipping flipPage;
	public RenderTextureScript rendTexture;
	public SaveLoadKeyboard saveLoadKey;
	public OptionsMenu options;
	public LoadToPlayer loadToPlayer;

	//Used for making the save/ load paths
	public string userName;
	public bool loaded;

	//GameObjects
	public GameObject camObject;

	// Use this for initialization
	void Awake ()
	{
		playerVector3Ser.setVector3Ser (transform.position.x, transform.position.y, 
		                                transform.position.z);
		playerQuatSer.setQuaternionSer (transform.rotation.x, transform.rotation.y, 
		                                transform.rotation.z, transform.rotation.w);


	}
	
	public void Save()
	{

		//When saved, the playerData and CameraData set the location
		Player_MAIN.player.setLocation(gameObject);
		cameraData.setLocation ();
		BinaryFormatter bf = new BinaryFormatter ();
		//Creates a file with the userName with the Info.dat -- This makes different save files
		FileStream file = File.Create (Application.persistentDataPath + "/" + userName + "Info.dat");

		//Creates a class instance from the private class below
		PlayerData data = new PlayerData ();
		data.player = Player_MAIN.player;
		//Uses a Vector3Serial to serialize the data(Vector3 can't be serialized)
		data.playerPosition = new Vector3Serial(Player_MAIN.player.getPosition ().x, Player_MAIN.player.getPosition ().y, 
		                                        Player_MAIN.player.getPosition ().z);
		data.cameraPosition = new Vector3Serial (cameraData.getPosition ().x, cameraData.getPosition ().y, 
		                                         cameraData.getPosition ().z);
		//Uses a QuaternionSerial to serialize the data(Quaternion can't be serialized)
		data.playerRotation = new QuaternionSerial(Player_MAIN.player.getRotation ().x, Player_MAIN.player.getRotation ().y, 
		                                           Player_MAIN.player.getRotation ().z, Player_MAIN.player.getRotation ().w);
		data.cameraRotation = new QuaternionSerial (cameraData.getRotation ().x, cameraData.getRotation ().y, 
		                                            cameraData.getRotation ().z, cameraData.getRotation ().w);
		data.inventoryCamera = rendTexture.rendTextCameras;

		bf.Serialize (file, data);
		file.Close ();

	}
	public void Load()
	{
		Debug.Log("Loading User: " + userName);
		//If it does exist this will run
		if (File.Exists (Application.persistentDataPath + "/" + userName + "Info.dat")) {

			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/" + userName + "Info.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			Player_MAIN.player = data.player;
			//Returns a Vector3 from the serialized class in order to load the position that was serialized
			transform.position = data.playerPosition.returnVector3();
			camObject.transform.position = data.cameraPosition.returnVector3 ();
			//Returns a Quaternion from the serialized class in order to load the position that was serialized
			transform.rotation = data.playerRotation.returnQuaternion();
			camObject.transform.rotation = data.cameraRotation.returnQuaternion ();
			rendTexture.rendTextCameras = data.inventoryCamera;

			loaded = true;
			saveLoadKey.LoadKeyboard(userName);
			SaveUsers();
			LoadOptions();
		}
		else
			loaded = false;
	}

	//Delete function that erases the username+Info.dat for a user
	public void Delete()
	{

		if(File.Exists(Application.persistentDataPath + "/" + userName + "Info.dat"))
			File.Delete(Application.persistentDataPath + "/" + userName + "Info.dat");

	}

	//Deletes everything 
	public void DeleteAll()
	{
		if(File.Exists(Application.persistentDataPath + "/UsernameMenuInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/UsernameMenuInfo.dat", FileMode.Open);
			MenuData data = (MenuData)bf.Deserialize (file);
			file.Close ();
		
			foreach(User name in data.Users)
			{
				Debug.Log(name.getPlayerName() + " Deleted.");
				File.Delete(Application.persistentDataPath + "/" + name.getPlayerName() + "Info.dat");
			}
			File.Delete(Application.persistentDataPath + "/UsernameMenuInfo.dat");
			RestartLevel();
		}
	}

	public void RestartLevel()
	{
		Debug.Log("Restarting Level");
		Application.LoadLevel(Application.loadedLevel);
	}

	//Simply stores the data for the Users at the MainMenu
	public void SaveUsers()
	{

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/UsernameMenuInfo.dat");

		MenuData data = new MenuData();

		data.Users = createUser.listOfTypeUSERS;
		//data.userNames = createUser.listOfUsers;
		data.usernameNumb = createUser.usernameNumb;
		data.layer = createUser.layer;
		data.usernameTracker = createUser.userNumbTracker;
		data.tempLayer = createUser.tempLayer;

		bf.Serialize (file, data);
		file.Close ();

	}

	//Loads the data for the Users at the MainMenu
	public void LoadUsers()
	{

		if(File.Exists(Application.persistentDataPath + "/UsernameMenuInfo.dat"))
		{

			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/UsernameMenuInfo.dat", FileMode.Open);
			MenuData data = (MenuData)bf.Deserialize (file);
			file.Close ();

			createUser.listOfTypeUSERS = data.Users;
			//createUser.listOfUsers = data.userNames;
			createUser.usernameNumb = data.usernameNumb;
			createUser.layer = data.layer;
			createUser.userNumbTracker = data.usernameTracker;
			createUser.tempLayer = data.tempLayer;
	
			int tempPlacement = 0;
			for(int j = 0; j < data.usernameTracker; j++)
			{

				if(tempPlacement == 5)
					tempPlacement = 0;

				createUser.CreateUser(tempPlacement);
				createUser.NameUser(data.Users[j].getPlayerName());
				createUser.listOfUsers[j].GetComponent<CanvasGroup>().alpha = 1;
				createUser.currUser.name = data.Users[j].getPlayerName();

				tempPlacement++;
				
			}

			flipPage.De_ActivateUsers();
		}	

	}

	// Called from the Back button
	public void SaveOptions()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/" + userName + "Options.dat");
		OptionsData optionsData = new OptionsData();
		/****************************************************************
	 	* General
	 	*/ 
		optionsData.mouseSensitivity = options.mouseSens.value;
		optionsData.fieldOfView = options.fovValue.value;
		optionsData.subtitles = options.subtitlesOnOff.isOn;
		optionsData.mouseInversion = options.mouseInver.isOn;

		/****************************************************************
	 	* Audio
	 	*/ 
		optionsData.masterLevel = options.masterVol.value;
		optionsData.effectsLevel = options.effectVol.value;
		optionsData.voiceLevel = options.voiceVol.value;
		optionsData.musicLevel = options.musicVol.value;

		/****************************************************************
		* Graphics
	 	*/
		optionsData.resolution = options.currentResolution;
		optionsData.windowedOrFullscreen = options.windowFull.isOn;
		optionsData.brightness = options.brightness.value;
		optionsData.graphics = options.currentGraphics;

		/****************************************************************
	 	* Advanced
	 	*/ 
		optionsData.antialiasingMode = options.currentAA;
		optionsData.filteringMode = options.currentFiltering;

		bf.Serialize (file, optionsData);
		file.Close();
	}

	// Called when you click Play Game (TODO Is this the best place to call it? How do we load it for the user?)
	public void LoadOptions()
	{
		Debug.Log("Loading Options for User: " + userName);
		//If it does exist this will run
		if (File.Exists (Application.persistentDataPath + "/" + userName + "Options.dat")) {

			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/" + userName + "Options.dat", FileMode.Open);
			OptionsData optionsData = (OptionsData)bf.Deserialize (file);
			Debug.Log("Loading to player..");
			file.Close ();
			Debug.Log("Loading to player..");
			/****************************************************************
	 		* General
	 		*/ 
			options.mouseSens.value = optionsData.mouseSensitivity;
			options.fovValue.value = optionsData.fieldOfView;
			options.subtitlesOnOff.isOn = optionsData.subtitles;
			options.mouseInver.isOn = optionsData.mouseInversion;
			Debug.Log("Loading to player..");
			/****************************************************************
	 		* Audio
	 		*/ 
			options.masterVol.value = optionsData.masterLevel;
			options.effectVol.value = optionsData.effectsLevel;
			options.voiceVol.value = optionsData.voiceLevel;
			options.musicVol.value = optionsData.musicLevel;
			Debug.Log("Loading to player..");
			/****************************************************************
			* Graphics
	 		*/
			options.currentResolution = optionsData.resolution;
			options.windowFull.isOn = optionsData.windowedOrFullscreen;
			options.brightness.value = optionsData.brightness;
			options.currentGraphics = optionsData.graphics;
			Debug.Log("Loading to player..");
			/****************************************************************
	 		* Advanced
	 		*/ 
			options.currentAA = optionsData.antialiasingMode;
			options.currentFiltering = optionsData.filteringMode;

			Debug.Log("Loading to player..");
			loadToPlayer.loadOptionsToPlayer(optionsData);
		}
		else
			Debug.Log("Didn't load Options");
	}

}

[Serializable]
class PlayerData
{
	public Player player;
	public Vector3Serial playerPosition;
	public QuaternionSerial playerRotation;
	public Vector3Serial cameraPosition;
	public QuaternionSerial cameraRotation;
	public List<GameObject> listPages;
	public List<GameObject> listInventory;
	public List<GameObject> listInventoryObjects;
	public List<Camera> inventoryCamera;

}

[Serializable]
public class OptionsData
{
	/****************************************************************
	 * General
	 */ 
	public float mouseSensitivity;
	public float fieldOfView;
	public bool subtitles;
	public bool mouseInversion;

	/****************************************************************
	 * Audio
	 */ 
	public float masterLevel;
	public float effectsLevel;
	public float voiceLevel;
	public float musicLevel;

	/****************************************************************
	 * Graphics
	 */ 
	public int resolution; // We will store each resolution in an enum struct, the integer will represent resolution
	public int resX;
	public int resY;
	public bool windowedOrFullscreen;
	public float brightness;
	public int graphics; // We will store each graphic (low, med, high, supa high) in an enum struct, the integer 
						 // represents the graphic

	/****************************************************************
	 * Advanced
	 */ 
	public int antialiasingMode; // We will store each AA setting in an enum struct, the integer will represent AA.
	//TODO Add individual settings here...?
	public int filteringMode; // We will store each filtering in an enum struct, the integer will represent filtering
	//TODO Add each modifiable thing here... (Low, med, high, supa high)
	// Lighting
	// Shading
	// Textures
	// Models
	// Shadows
	// Water (?)
}

[Serializable]
class MenuData
{

	public List<User> Users;
	public List<string> userNames;
	public int usernameNumb;
	public int layer;
	public int usernameTracker;
	public bool tempLayer;

}