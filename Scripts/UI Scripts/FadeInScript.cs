using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeInScript : MonoBehaviour {

	public CanvasGroup beforeLogo;
	public CanvasGroup logo;
	public bool start = true;
	public bool startToFinish;
	public bool finish;

	// Update is called once per frame
	void Update () {

		if(start)
		{

			beforeLogo.alpha = Mathf.Lerp(beforeLogo.alpha, 1, Time.deltaTime);
			if(beforeLogo.alpha >= 0.8f)
			{

				logo.alpha = Mathf.Lerp(logo.alpha, 1, Time.deltaTime);
				if(logo.alpha >= 0.8f)
				{

					start = false;
					startToFinish = true;

				}

			}

		}
		else if(startToFinish)
		{

			startToFinish = false;
			StartCoroutine(fadeOut());

		}
		else if(finish)
		{

			beforeLogo.alpha = Mathf.Lerp(beforeLogo.alpha, 0, Time.deltaTime);
			if(beforeLogo.alpha <= 0.2f)
			{
				
				logo.alpha = Mathf.Lerp(logo.alpha, 0, Time.deltaTime);
				if(logo.alpha <= 0.02f)
				{

					finish = false;
					StartCoroutine(startLoadLevel());
					
				}
				
			}

		}

	}

	IEnumerator fadeOut()
	{

		yield return new WaitForSeconds(3f);
		finish = true;

	}

	IEnumerator startLoadLevel()
	{

		yield return new WaitForSeconds(2f);
		Application.LoadLevelAsync(1);

	}

}
