using UnityEngine;
using System.Collections;

public class DeleteAll : MonoBehaviour {

	public float periodHeld = 0.0f;
	public SaveLoad saveLoad;

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey(KeyCode.Backspace))
		{
			periodHeld += Time.deltaTime;
			if(periodHeld > 3.0f)
			{
				saveLoad.DeleteAll();
			}
		}
		else
		{
			periodHeld = 0.0f;
		}
	}
}
