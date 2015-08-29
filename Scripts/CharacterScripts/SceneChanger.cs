using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {

	void Update()
	{

		StartCoroutine(waitToChangeScene());

	}

	public IEnumerator waitToChangeScene()
	{

		yield return new WaitForSeconds(5f);
		Application.LoadLevel(2);

	}

}
