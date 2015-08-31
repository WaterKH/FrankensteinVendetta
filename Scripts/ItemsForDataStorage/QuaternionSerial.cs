using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

[Serializable]
public class QuaternionSerial
{

	public float x;
	public float y;
	public float z;
	public float w;

	public QuaternionSerial()
	{

		x = 0;
		y = 0;
		z = 0;
		w = 0;

	}

	public QuaternionSerial(float aX, float aY, float aZ, float aW)
	{

		x = aX;
		y = aY;
		z = aZ;
		w = aW;

	}
	//Returns a new Quaternion with x y z w
	public Quaternion returnQuaternion()
	{

		return new Quaternion (x, y, z, w);

	}
	//Returns a new QuaternionSerial with x y z w
	public QuaternionSerial returnQuaternionSer()
	{

		return new QuaternionSerial (x, y, z, w);

	}
	public QuaternionSerial returnQuaternionSer(Quaternion quater)
	{

		return new QuaternionSerial(quater.x, quater.y, quater.z, quater.w);

	}
	//Sets the values (Pretty much the constructor, except doesn't create a new instance)
	public  void setQuaternionSer(float aX, float aY, float aZ, float aW)
	{

		x = aX;
		y = aY;
		z = aZ;
		w = aW;

	}
	//Allows setting the variable while returning the value (Used by PlayerStats's setLocation())
	public Quaternion setQuaternion(float aX, float aY, float aZ, float aW)
	{

		return new Quaternion (aX, aY, aZ, aW);

	}

}
