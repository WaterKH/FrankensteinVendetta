using UnityEngine;
using System.Collections;

public class Objective {

	public string name;
	public string contents;

	public Objective()
	{
		name = "NULL";
		contents = "NULL";
	}

	public Objective(string aName, string aContent)
	{
		this.setName(aName);
		this.setContents(aContent);
	}

	public void setName(string aName)
	{
		name = aName;
	}
	public void setContents(string aContent)
	{
		contents = aContent;
	}

	public string getName()
	{
		return name;
	}
	public string getContents()
	{
		return contents;
	}
}
