using UnityEngine;
using System.Collections;

public class CameraStats : MonoBehaviour {

		public Vector3 position;
		public Quaternion rotation;
		public Vector3Serial vect3Ser = new Vector3Serial();
		public QuaternionSerial quatSer = new QuaternionSerial();

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
		public void setLocation()
		{
				//Sets the postion and rotation based on where the character is at
				setPosition (new Vector3Serial(transform.position.x, transform.position.y, transform.position.z));
				setRotation (new QuaternionSerial(transform.rotation.x,transform.rotation.y,transform.rotation.z,transform.rotation.w));

		}
}
