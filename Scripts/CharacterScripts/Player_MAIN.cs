using UnityEngine;
using System.Collections;

public class Player_MAIN : MonoBehaviour {

	public static Player player = new Player();
	public GameObject startObject;
	public SaveLoad saveLoad;
/*
	void Awake()
	{
		if(startObject != null)
		{

			player.setPosition(startObject.transform.position);
			player.setRotation(startObject.transform.rotation);

		}
		Debug.Log(player.getName());
		if(player.getName() != "unnamed")
			saveLoad.Load(player.getName());

	}
	*/

}
