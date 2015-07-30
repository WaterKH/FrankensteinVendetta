//On FPC in FrankensteinChapter1
//On MainCamera in MainMenu
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//Will be used in Game, but also used in SaveLoad class to take what stats are here and save/ load them
//Self explanatory class
public class PlayerStats : MonoBehaviour {

	public float health;
	public Vector3 position;
	public Quaternion rotation;
	public List<GameObject> listPages;
	public List<GameObject> listInventory;
	public List<GameObject> listInventoryObjects;
	public Vector3Serial vect3Ser = new Vector3Serial();
	public QuaternionSerial quatSer = new QuaternionSerial();

	public float getHealth()
	{

			return health;

	}
	public Vector3 getPosition()
	{

			return position;

	}
	public Quaternion getRotation()
	{

			return rotation;
	}
	public List<GameObject> getListPages()
	{

			return listPages;

	}
	public List<GameObject> getListInventory()
	{

			return listInventory;

	}

	public List<GameObject> getListInventoryObjects()
	{

		return listInventoryObjects;

	}

	public void setHealth(float aHealth)
	{

		health = aHealth;

	}
	//position set to the Vector3Serial 
	public void setPosition(Vector3Serial aPos)
	{

		position = vect3Ser.setVector3(aPos.x,aPos.y,aPos.z);

	}
	//rotation set to the QuaternionSerial
	public void setRotation(QuaternionSerial aRot)
	{

		rotation = quatSer.setQuaternion(aRot.x,aRot.y,aRot.z,aRot.w);

	}
	public void setListPages(List<GameObject> aList)
	{
		listPages.Clear ();
		foreach(GameObject listObject in aList)
			listPages.Add(listObject);

	}
	public void setListInventory(List<GameObject> aList)
	{

		listInventory.Clear ();
		foreach (GameObject listObject in aList)
			listInventory.Add (listObject);

	}
	public void setListInventoryObjects(List<GameObject> aList)
	{
		
		listInventoryObjects.Clear ();
		foreach (GameObject listObject in aList)
			listInventoryObjects.Add (listObject);
		
	}


	//Sets the location through setPosition and setRotation
	public void setLocation()
	{
		//Sets the postion and rotation based on where the character is at
		setPosition (new Vector3Serial(transform.position.x, transform.position.y, transform.position.z));
		setRotation (new QuaternionSerial(transform.rotation.x,transform.rotation.y,transform.rotation.z,transform.rotation.w));
		
	}
			
}
