using UnityEngine;
using System.Collections;

public class ObjectiveSystem : MonoBehaviour {

	public Objective currentObjective;

	public void createObjective(string aName, string aContents)
	{
		currentObjective = new Objective(aName, aContents);
	}
	
	void Update()
	{

	}
}
