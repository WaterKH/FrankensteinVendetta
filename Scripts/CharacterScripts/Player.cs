//On FPC in FrankensteinChapter1
//On MainCamera in MainMenu
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//Will be used in Game, but also used in SaveLoad class to take what stats are here and save/ load them
//Self explanatory class
public class Player : Character {

	public float health;
	public Vector3 position;
	public Quaternion rotation;

	Vector3Serial vect3Ser = new Vector3Serial();
	QuaternionSerial quatSer = new QuaternionSerial();

	public Player()
	{

		base.setID(0);
		base.setName("unnamed");
		health = 0.0f;
		position = Vector3.zero;
		rotation = new Quaternion(0,0,0,0);

	}

	public Player(int anID, string aName, float playerHealth, Vector3 aPos, Quaternion aRot)
	{
		
		base.setID(anID);
		base.setName(aName);
		health = playerHealth;
		position = aPos;
		rotation = aRot;
		
	}

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


	//Sets the location through setPosition and setRotation
	public void setLocation(GameObject character)
	{
		//Sets the postion and rotation based on where the character is at
		setPosition (new Vector3Serial(character.transform.position.x, character.transform.position.y, 
		                               character.transform.position.z));
		setRotation (new QuaternionSerial(character.transform.rotation.x,character.transform.rotation.y,
		                                  character.transform.rotation.z,character.transform.rotation.w));
		
	}
			
}
