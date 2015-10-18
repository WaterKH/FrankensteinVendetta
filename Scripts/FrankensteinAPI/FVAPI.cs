using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FVAPI {

	
	public static string getTextString(GameObject anObject)
	{

		return anObject.GetComponent<Text>().text;

	}

	public static GameObject getMainCharacter()
	{

		return GameObject.Find("FPC");

	}

	public static GameObject[] getAllCharacters()
	{

		return GameObject.FindGameObjectsWithTag("Character");

	}

	public static int getCharacterID(GameObject anObject)
	{

		//If ID == 0, character is not an enemy
		//Else if ID == 1, character is an enemy
		//Else if ID == 2, character is an FPC
		//Else if ID == -1, character does not exist
		return anObject.GetComponent<Character>().getID();

	}

	public static string getCharacterName(GameObject anObject)
	{

		return anObject.GetComponent<Character>().getName();

	}

	public static void playAudioTrack(GameObject anObject, bool loop)
	{

		SoundManager.playSound(anObject, loop);

	}

	public static void stopAudioTrack(GameObject anObject)
	{

		SoundManager.stopSound(anObject);

	}

	public static void playAnimation(GameObject anObject, bool loop, string state)
	{

		AnimManager.playAnim(anObject, loop, state);

	}

	public static void stopAnimation(GameObject anObject, string state)
	{

		AnimManager.stopAnim(anObject, state);

	}

	public static void playerTakeDamage(float damage)
	{

		Player_MAIN.player.setHealth(Player_MAIN.player.getHealth()-damage);

	}

	public static void playerRecieveHealth(float health)
	{

		Player_MAIN.player.setHealth(Player_MAIN.player.getHealth()+health);

	}

	public static void respawnCharacter(GameObject startingObject, GameObject character)
	{

		character.transform.position = startingObject.transform.position;

	}

	public static Vector3 createVector3(GameObject vector3Object)
	{

		return new Vector3(vector3Object.transform.position.x, vector3Object.transform.position.y, 
		                   vector3Object.transform.position.z);

	}

	public static Vector3 createVector3Additive(GameObject vector3Object, float x, float y, float z)
	{

		return new Vector3(vector3Object.transform.position.x + x, vector3Object.transform.position.y + y,
		                   vector3Object.transform.position.z + z);

	}

	public static Quaternion createQuaternion(GameObject quatObject)
	{

		return new Quaternion(quatObject.transform.rotation.x, quatObject.transform.rotation.y,
		                      quatObject.transform.rotation.z, quatObject.transform.rotation.w);

	}

	public static Quaternion createQuaternionAdditive(GameObject quatObject, float x, float y, float z, float w)
	{
		
		return new Quaternion(quatObject.transform.rotation.x + x, quatObject.transform.rotation.y + y,
		                      quatObject.transform.rotation.z + z, quatObject.transform.rotation.w + w);
		
	}

	public static void lerpAlphaChannel(CanvasGroup alphaGroup, float lerpTo)
	{

		alphaGroup.alpha = Mathf.Lerp(alphaGroup.alpha, lerpTo, Time.deltaTime);

	}

	public static void lerpAlphaChannel(CanvasGroup alphaGroup, float lerpTo, float time)
	{
		
		alphaGroup.alpha = Mathf.Lerp(alphaGroup.alpha, lerpTo, time);

	}

	public static void lerpAlphaChannelTimeMultiplied(CanvasGroup alphaGroup, float lerpTo, float rateOfTime)
	{

		alphaGroup.alpha = Mathf.Lerp(alphaGroup.alpha, lerpTo, Time.deltaTime * rateOfTime);
		
	}

	public static void lerpVector3(Vector3 initialVector, Vector3 moveToVector)
	{

		initialVector = Vector3.Lerp(initialVector, moveToVector, Time.deltaTime);
		
	}
	
	public static void lerpVector3(Vector3 initialVector, Vector3 moveToVector, float time)
	{
		
		initialVector = Vector3.Lerp(initialVector, moveToVector, time);
		
	}

	public static void lerpVector3TimeMultiplied(Transform initialVector, Transform moveToVector, float rateOfTime)
	{
		
		initialVector.position = Vector3.Lerp(initialVector.position, moveToVector.position, 
		                                      Time.deltaTime * rateOfTime);
		
	}

	public static void lerpQuaternion(Quaternion initialQuaternion, Quaternion moveToQuaternion)
	{
		
		initialQuaternion = Quaternion.Lerp(initialQuaternion, moveToQuaternion, Time.deltaTime);
		
	}
	
	public static void lerpQuaternion(Quaternion initialQuaternion, Quaternion moveToQuaternion, float time)
	{
		
		initialQuaternion = Quaternion.Lerp(initialQuaternion, moveToQuaternion, time);
		
	}
	
	public static void lerpQuaternionTimeMultiplied(Quaternion initialQuaternion, Quaternion moveToQuaternion, 
	                                                float rateOfTime)
	{
		
		initialQuaternion = Quaternion.Lerp(initialQuaternion, moveToQuaternion, Time.deltaTime * rateOfTime);
		
	}

	public static void lerpVectorAndQuaternion(Transform initialTrans, Transform moveToTrans)
	{

		initialTrans.position = Vector3.Lerp(initialTrans.position, moveToTrans.position, Time.deltaTime);
		initialTrans.rotation = Quaternion.Lerp(initialTrans.rotation, moveToTrans.rotation, Time.deltaTime);

	}

	public static void lerpVectorAndQuaternion(Transform initialTrans, Transform moveToTrans, float time)
	{
		
		initialTrans.position = Vector3.Lerp(initialTrans.position, moveToTrans.position, time);
		initialTrans.rotation = Quaternion.Lerp(initialTrans.rotation, moveToTrans.rotation, time);
		
	}

	public static void lerpVectorAndQuaternionTimeMultiplied(Transform initialTrans, Transform moveToTrans, 
	                                                         float rateOfTime)
	{
		
		initialTrans.position = Vector3.Lerp(initialTrans.position, moveToTrans.position, 
		                                     Time.deltaTime * rateOfTime);
		initialTrans.rotation = Quaternion.Slerp(initialTrans.rotation, moveToTrans.rotation, 
		                                        Time.deltaTime * rateOfTime);
		
	}

	public static bool playerClicked(int distance, GameObject camera, string tagToHit)
	{

		Ray ray;
		RaycastHit hit;

		if(camera.GetComponent<Camera>().enabled == true)
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		else
			return false;
		
		if (InputManager.GetKeyDown("action") || InputManager.GetKeyDown("actionSecondary")) 
		{       
			if (Physics.Raycast (ray, out hit, distance))
			{
				if (hit.collider.gameObject.tag == tagToHit)
					return true;
			}
			return false;
		}
		return false;
	}

}
