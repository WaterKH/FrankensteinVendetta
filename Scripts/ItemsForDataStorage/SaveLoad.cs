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
	public Player playerData = new Player();
	public CameraStats cameraData;
	public Vector3Serial playerVector3Ser = new Vector3Serial();
	public QuaternionSerial playerQuatSer = new QuaternionSerial();
	public Vector3Serial cameraVector3Ser = new Vector3Serial();
	public QuaternionSerial cameraQuatSer = new QuaternionSerial();
	public CreateNewUser createUser;
	public PageFlipping flipPage;
	public RenderTextureScript rendTexture;
	public SaveLoadKeyboard saveLoadKey;

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
		playerData.setLocation (gameObject.transform.parent.gameObject);
		cameraData.setLocation ();
		BinaryFormatter bf = new BinaryFormatter ();
		//Creates a file with the userName with the Info.dat -- This makes different save files
		FileStream file = File.Create (Application.persistentDataPath + "/" + userName + "Info.dat");

		//Creates a class instance from the private class below
		PlayerData data = new PlayerData ();
		data.health = playerData.getHealth();
		//Uses a Vector3Serial to serialize the data(Vector3 can't be serialized)
		data.playerPosition = new Vector3Serial(playerData.getPosition ().x, playerData.getPosition ().y, 
		                                        playerData.getPosition ().z);
		data.cameraPosition = new Vector3Serial (cameraData.getPosition ().x, cameraData.getPosition ().y, 
		                                         cameraData.getPosition ().z);
		//Uses a QuaternionSerial to serialize the data(Quaternion can't be serialized)
		data.playerRotation = new QuaternionSerial(playerData.getRotation ().x, playerData.getRotation ().y, 
		                                           playerData.getRotation ().z, playerData.getRotation ().w);
		data.cameraRotation = new QuaternionSerial (cameraData.getRotation ().x, cameraData.getRotation ().y, 
		                                            cameraData.getRotation ().z, cameraData.getRotation ().w);
		data.inventoryCamera = rendTexture.rendTextCameras;
		data.userName = userName;

		bf.Serialize (file, data);
		file.Close ();

	}
	public void Load()
	{
		//If it does exist this will run
		if (File.Exists (Application.persistentDataPath + "/" + userName + "Info.dat")) {

			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/" + userName + "Info.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			playerData.health = data.health;
			//Returns a Vector3 from the serialized class in order to load the position that was serialized
			transform.position = data.playerPosition.returnVector3();
			camObject.transform.position = data.cameraPosition.returnVector3 ();
			//Returns a Quaternion from the serialized class in order to load the position that was serialized
			transform.rotation = data.playerRotation.returnQuaternion();
			camObject.transform.rotation = data.cameraRotation.returnQuaternion ();
			rendTexture.rendTextCameras = data.inventoryCamera;
			userName = data.userName;

			loaded = true;
			saveLoadKey.LoadKeyboard();
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

	//Simply stores the data for the Users at the MainMenu
	public void SaveUsers()
	{

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/UsernameMenuInfo.dat");

		MenuData data = new MenuData();

		data.Users = createUser.userNamesMenu;
		data.userNames = createUser.usernames;
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

			createUser.userNamesMenu = data.Users;
			createUser.usernames = data.userNames;
			createUser.usernameNumb = data.usernameNumb;
			createUser.layer = data.layer;
			createUser.userNumbTracker = data.usernameTracker;
			createUser.tempLayer = data.tempLayer;
	
			for(int j = 0; j < data.usernameTracker; j++)
			{
				
				createUser.CreateUser(j);
				createUser.NameUser(data.Users[j].getPlayerName());
				createUser.listOfUsers[j].GetComponent<CanvasGroup>().alpha = 1;
				createUser.currUser.name = data.Users[j].getPlayerName();
				
			}

			flipPage.De_ActivateUsers();
		}	

	}

}

[Serializable]
class PlayerData
{
	public float health;
	public Vector3Serial playerPosition;
	public QuaternionSerial playerRotation;
	public Vector3Serial cameraPosition;
	public QuaternionSerial cameraRotation;
	public List<GameObject> listPages;
	public List<GameObject> listInventory;
	public List<GameObject> listInventoryObjects;
	public List<Camera> inventoryCamera;
	public string userName;

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