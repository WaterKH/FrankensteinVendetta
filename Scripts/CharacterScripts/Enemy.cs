using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Enemy : Character {
	
	public Vector3 position;
	public Quaternion rotation;
	
	Vector3Serial vect3Ser = new Vector3Serial();
	QuaternionSerial quatSer = new QuaternionSerial();
	
	public Enemy()
	{
		
		base.setID(1);
		base.setName("unnamed");
		position = Vector3.zero;
		rotation = new Quaternion(0,0,0,0);
		
	}
	
	public Enemy(int anID, string aName, Vector3 aPos, Quaternion aRot)
	{
		
		base.setID(anID);
		base.setName(aName);
		position = aPos;
		rotation = aRot;
		
	}

	public Vector3 getPosition()
	{
		
		return position;
		
	}
	public Quaternion getRotation()
	{
		
		return rotation;
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
