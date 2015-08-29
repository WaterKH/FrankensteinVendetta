//On ResumeGame in FrankensteinChapter1
using UnityEngine;
using System.Collections;

//Causes the menu to fade out and in depending on if the User is hovering over the ResumeButton
public class ResumeButton : MonoBehaviour {

	//Script instances
	public PauseMenu pauseMenu;
	public JournalAppear journalAppear;

	//Instance Variables
	public CanvasGroup pageNotes;
	public CanvasGroup resumeGroup;
	public float elapsedTime;
	public bool hovering;

	//CALLED on ResumeGame under the EventTrigger
	public void ResumeEnter ()
	{

		hovering = true;
		elapsedTime = 0;

	}

	//CALLED on ResumeGame under the EventTrigger
	public void ResumeExit ()
	{

		hovering = false;
		journalAppear.journalTime = 0;
		elapsedTime = 0;

	}

	void Update()
	{

		//Made true in ResumeEnter()
		if(hovering)
		{

			elapsedTime += .05f;
			//Lerps the alpha channel to invisible
			resumeGroup.alpha = Mathf.Lerp(resumeGroup.alpha, 0, elapsedTime);
			//Made true in PauseMenu class under the clickedJournal() method
			if(pauseMenu.journalKey)
				//Lerps the Pages to invisible
				pageNotes.alpha = Mathf.Lerp(pageNotes.alpha, 0, elapsedTime);

		}
		//Made false in ResumeExit()
		else if(!hovering && resumeGroup.alpha > 0)
		{
			
			elapsedTime += .05f;
			//Lerps the menu back to visible
			resumeGroup.alpha = Mathf.Lerp(resumeGroup.alpha, 1, elapsedTime);

		}

	}

}
