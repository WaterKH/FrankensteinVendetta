using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
	}

	public void LoadLevel()
	{
		Application.LoadLevel("TestScene");

	}

	public void Quit()
	{

		Application.Quit();

	}

}
