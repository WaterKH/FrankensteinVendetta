//On FPC in FrankensteinChapter1
//On MainCamera in MainMenu
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

//Will be used in Game, but also used in SaveLoad class to take what stats are here and save/ load them
//Self explanatory class
[Serializable]
public class Player : Character {

	public float health;
	Vector3Serial vect3Ser = new Vector3Serial();
	QuaternionSerial quatSer = new QuaternionSerial();

	public Player()
	{
		base.setID(0);
		base.setName("unnamed");
		health = 100.0f;
		vect3Ser = vect3Ser.returnVector3Ser(Vector3.zero);
		quatSer = quatSer.returnQuaternionSer(new Quaternion(0,0,0,0));
		base.setSpeed(0);
	}

	public Player(int anID, string aName, float playerHealth, float aSpeed, Vector3 aPos, Quaternion aRot) : 
		base(aName, anID, aSpeed)
	{

		health = playerHealth;
		vect3Ser = vect3Ser.returnVector3Ser(aPos);
		quatSer = quatSer.returnQuaternionSer(aRot);
		
	}

	public float getHealth()
	{
		return health;
	}
	public Vector3 getPosition()
	{
		return vect3Ser.returnVector3();
	}
	public Quaternion getRotation()
	{
		return quatSer.returnQuaternion();
	}

	public void setHealth(float aHealth)
	{
		health = aHealth;
	}
	//position set to the Vector3Serial 
	public void setPosition(Vector3 aPos)
	{
		vect3Ser.setVector3Ser(aPos.x,aPos.y,aPos.z);
	}
	//rotation set to the QuaternionSerial
	public void setRotation(Quaternion aRot)
	{
		quatSer.setQuaternion(aRot.x,aRot.y,aRot.z,aRot.w);
	}

	//Sets the location through setPosition and setRotation
	public void setLocation(GameObject character)
	{
		//Sets the postion and rotation based on where the character is at
		setPosition (character.transform.position);
		setRotation (character.transform.rotation);
	}
}
