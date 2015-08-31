//On Journal in FrankensteinChapter1
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Causes the Journal 
public class JournalAppear : MonoBehaviour
{

	//Script instances
	public ResumeButton resumeButton;
	public PauseMenu pauseMenu;

	public CanvasGroup journalCover;
	public CanvasGroup pagesBackground;

	public GameObject buttonsPause;

	float elapsedTime;
	public float journalTime;
	public bool hovering;

	//Is called when cursor enters "Journal Entries" button
	//CALLED on JournalEntries 
	public void JournalEnter ()
	{

		hovering = true;
		elapsedTime = 0;
	
	}

	//Is called when cursor exits "Journal Entries" button
	//CALLED on JournalEntries 
	public void JournalExit ()
	{

		hovering = false;
		elapsedTime = 0;

	}

	//Is called when cursor clicks "Journal Entries" button
	//CALLED on BackButton 
	public void JournalBackButtonPressed()
	{

		journalTime = 0;
		pauseMenu.journalKey = false;

	}

	void Update ()
	{

		//If the journalTime is over 1, reset it to 1
		if (journalTime > 1)
			journalTime = 1;

		if (hovering) {
			elapsedTime += .1f;
			//Lerps the journalCover to visible
			FVAPI.lerpAlphaChannel(journalCover, 1, elapsedTime);
			//journalCover.alpha = Mathf.Lerp (journalCover.alpha, 1, elapsedTime);

		} else if (!hovering) {

			if (journalCover.alpha <= 0)
				elapsedTime = 0;
			else
			{

				elapsedTime += .1f;
				//Lerps the journalCover to invisible
				FVAPI.lerpAlphaChannel(journalCover, 0, elapsedTime);
				//journalCover.alpha = Mathf.Lerp (journalCover.alpha, 0, elapsedTime);
			}
		}

		//If the journalKey is true, set by clickedJournal() method in PauseMenu class
		if(pauseMenu.journalKey)
		{
			//Set hovering to false so that the cover will disappear
			hovering = false;
			//This seems redundant...
			journalTime += .05f;
			FVAPI.lerpAlphaChannel(journalCover, 0, journalTime);
			//journalCover.alpha = Mathf.Lerp(journalCover.alpha, 0, journalTime);

			//if the hovering variable from ResumeButton class is true, lerp the pages to invisible
			if(resumeButton.hovering)
				FVAPI.lerpAlphaChannel(pagesBackground, 0, resumeButton.elapsedTime);
				//pagesBackground.alpha = Mathf.Lerp(pagesBackground.alpha, 0, resumeButton.elapsedTime);
			//Else lerp the pages to visible
			else
				FVAPI.lerpAlphaChannel(pagesBackground, 1, journalTime);
				//pagesBackground.alpha = Mathf.Lerp(pagesBackground.alpha, 1, journalTime);

		}
		//If the journalKey is false, and the pages is not invisible
		else if(!pauseMenu.journalKey && pagesBackground.alpha > 0)
		{

			FVAPI.lerpAlphaChannel(pagesBackground, 0, journalTime);
			//pagesBackground.alpha = Mathf.Lerp(pagesBackground.alpha, 0, journalTime);
			journalTime += .1f;
		
		}

	}

}
