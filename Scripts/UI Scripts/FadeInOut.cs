using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour {

	public CanvasGroup blackFader;
	public bool prelevel;
	public bool postlevel;

	
	void Awake()
	{
		
		blackFader.alpha = 1;
		
	}

	// Update is called once per frame
	void Update () {
	
		if(prelevel)
		{

			blackFader.alpha = Mathf.Lerp(blackFader.alpha, 0, Time.deltaTime);
			if(blackFader.alpha <= 0.15f)
			{

				blackFader.alpha = 0;
				prelevel = false;

			}

		}
		else if(postlevel)
		{

			blackFader.alpha = Mathf.Lerp(blackFader.alpha, 1, Time.deltaTime);
			if(blackFader.alpha >= 0.8f)
			{

				postlevel = false;
				Application.LoadLevel (2);

			}

		}

	}

}
