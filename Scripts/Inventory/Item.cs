using UnityEngine;
using System.Collections;

public class Item {

	public float weight;
	public int size;
	public string name;

	public Item()
	{
		weight = 0.0f;
		size = 0;
		name = "NULL";
	}

	public Item(float aWeight, int aSize, string aName)
	{
		this.setWeight(weight);
		this.setSize(aSize);
		this.setName(aName);
	}

	public void setWeight(float aWeight)
	{
		weight = aWeight;
	}
	public void setSize(int aSize)
	{
		size = aSize;
	}
	public void setName(string aName)
	{
		name = aName;
	}

	public float getWeight()
	{
		return weight;
	}
	public int getSize()
	{
		return size;
	}
	public string getName()
	{
		return name;
	}
}
