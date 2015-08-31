using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Vector3Serial {
	
	public float x;
	public float y;
	public float z;

	public Vector3Serial()
	{

		x = 0;
		y = 0;
		z = 0;

	}

	public Vector3Serial(float aX, float aY, float aZ)
	{

		x = aX;
		y = aY;
		z = aZ;

	}

	//Returns a new Vector3 with the x y z
	public Vector3 returnVector3()
	{

		return new Vector3 (x, y, z);

	}
	//Returns a new Vector3Serial with the x y z
	public Vector3Serial returnVector3Ser()
	{

		return new Vector3Serial (x, y, z);

	}
	public Vector3Serial returnVector3Ser(Vector3 vector3)
	{

		return new Vector3Serial(vector3.x, vector3.y, vector3.z);

	}
	//Sets the values (Pretty much the constructor, except doesn't create a new instance)
	public void setVector3Ser(float aX, float aY, float aZ)
	{

			x = aX;
			y = aY;
			z = aZ;

	}
	//Allows setting the variable while returning the value (Used by PlayerStats's setLocation())
	public Vector3 setVector3(float aX, float aY, float aZ)
	{

		return new Vector3 (aX, aY, aZ);

	}

}
