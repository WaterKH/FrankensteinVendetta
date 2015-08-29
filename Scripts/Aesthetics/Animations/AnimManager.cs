using UnityEngine;
using System.Collections;

public class AnimManager : MonoBehaviour {

	public static void playAnim(GameObject animHolder, bool loop, string state)
	{

		if(loop)
		{

			animHolder.GetComponent<Animation>().clip.wrapMode = WrapMode.Loop;
			animHolder.GetComponent<Animation>().Play (state);
		}
		else
		{
			animHolder.GetComponent<Animation>().clip.wrapMode = WrapMode.Once;
			animHolder.GetComponent<Animation>().Stop(state);

		}

	}

	public static void stopAnim(GameObject animHolder, string state)
	{

		animHolder.GetComponent<Animation>().Stop(state);

	}

}
