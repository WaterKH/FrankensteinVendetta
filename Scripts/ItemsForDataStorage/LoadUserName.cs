using UnityEngine;
using System.Collections;

public class LoadUserName : MonoBehaviour {

	public CreateNewUser createUser;

	void Awake()
	{

		createUser = GameObject.Find("ScriptHolder").GetComponent<CreateNewUser>();

	}

	public void UserNameLoad()
	{

		createUser.clickedUsername(gameObject);

	}

}
