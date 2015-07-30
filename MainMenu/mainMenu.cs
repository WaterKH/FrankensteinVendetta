//On ScriptHolder
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//This Script makes the transition between English and German text
public class mainMenu : MonoBehaviour {

	public bool buttonPlay;
	public bool buttonOption;
	public bool buttonExit;
	public bool buttonUser;
	public Text textToRemove;
	public Text textToReplace;
	public Text textToRemoveOption;
	public Text textToReplaceOption;
	public Text textToRemoveExit;
	public Text textToReplaceExit;
	public Text textToRemoveUser;
	public Text textToReplaceUser;

	public MoveToMainMenu moveToMain;
	public NewPlayerClick newPlayerClick;
	public mainMenu menuScript;

	public FadeInOut menuFade;

	void Awake()
	{

		Time.timeScale = 1;

	}

	// Update is called once per frame
	void Update () {

		if (buttonPlay) {

			if (textToRemove.text.Equals ("Neus Spiel")) {
				textToRemove.text = "Neus Spie";
				textToReplace.text = "P";
			} else if (textToRemove.text.Equals ("Neus Spie")) {
				textToRemove.text = "Neus Spi";
				textToReplace.text = "Pl";
			} else if (textToRemove.text.Equals ("Neus Spi")) {
				textToRemove.text = "Neus Sp";
				textToReplace.text = "Pla";
			} else if (textToRemove.text.Equals ("Neus Sp")) {
				textToRemove.text = "Neus S";
				textToReplace.text = "Play";
			} else if (textToRemove.text.Equals ("Neus S")) {
				textToRemove.text = "Neus ";
				textToReplace.text = "Play ";
			} else if (textToRemove.text.Equals ("Neus ")) {
				textToRemove.text = "Neus";
				textToReplace.text = "Play G";
			} else if (textToRemove.text.Equals ("Neus")) {
				textToRemove.text = "Neu";
				textToReplace.text = "Play Ga";
			} else if (textToRemove.text.Equals ("Neu")) {
				textToRemove.text = "Ne";
				textToReplace.text = "Play Gam";
			} else if (textToRemove.text.Equals ("Ne")) {
				textToRemove.text = "N";
				textToReplace.text = "Play Game";
			} else if (textToRemove.text.Equals ("N")) {
				textToRemove.text = "";
			}
						
		} else {

			if (textToReplace.text.Equals ("Play Game")) {
				textToRemove.text = "N";
				textToReplace.text = "Play Gam";
			} else if (textToReplace.text.Equals ("Play Gam")) {
				textToRemove.text = "Ne";
				textToReplace.text = "Play Ga";
			} else if (textToReplace.text.Equals ("Play Ga")) {
				textToRemove.text = "Neu";
				textToReplace.text = "Play G";
			} else if (textToReplace.text.Equals ("Play G")) {
				textToRemove.text = "Neus";
				textToReplace.text = "Play ";
			} else if (textToReplace.text.Equals ("Play ")) {
				textToRemove.text = "Neus ";
				textToReplace.text = "Play";
			} else if (textToReplace.text.Equals ("Play")) {
				textToReplace.text = "Neus S";
				textToReplace.text = "Pla";
			} else if (textToReplace.text.Equals ("Pla")) {
				textToRemove.text = "Neus Sp";
				textToReplace.text = "Pl";
			} else if (textToReplace.text.Equals ("Pl")) {
				textToRemove.text = "Neus Spi";
				textToReplace.text = "P";
			} else if (textToReplace.text.Equals ("P")) {
				textToRemove.text = "Neus Spie";
				textToReplace.text = "";
			} else if (textToReplace.text.Equals ("")) {
				textToRemove.text = "Neus Spiel";
			}

		}
		if (buttonOption) {

			if (textToRemoveOption.text.Equals ("Optiones")) {
				textToRemoveOption.text = "Optione";
				textToReplaceOption.text = "O";
			}
			else if (textToRemoveOption.text.Equals ("Optione")) {
				textToRemoveOption.text = "Option";
				textToReplaceOption.text = "Op";
			}
			else if (textToRemoveOption.text.Equals ("Option")) {
				textToRemoveOption.text = "Optio";
				textToReplaceOption.text = "Opt";
			}
			else if (textToRemoveOption.text.Equals ("Optio")) {
				textToRemoveOption.text = "Opti";
				textToReplaceOption.text = "Opti";
			}
			else if (textToRemoveOption.text.Equals ("Opti")) {
				textToRemoveOption.text = "Opt";
				textToReplaceOption.text = "Optio";
			}
			else if (textToRemoveOption.text.Equals ("Opt")) {
				textToRemoveOption.text = "Op";
				textToReplaceOption.text = "Option";
			}
			else if (textToRemoveOption.text.Equals ("Op")) {
				textToRemoveOption.text = "O";
				textToReplaceOption.text = "Options";
			}
			else if (textToRemoveOption.text.Equals ("O")) {
				textToRemoveOption.text = "";

			}

		} 
		else 
		{

			if (textToReplaceOption.text.Equals ("Options")) {
				textToRemoveOption.text = "O";
				textToReplaceOption.text = "Option";
			} else if (textToReplaceOption.text.Equals ("Option")) {
				textToRemoveOption.text = "Op";
				textToReplaceOption.text = "Optio";
			} else if (textToReplaceOption.text.Equals ("Optio")) {
				textToRemoveOption.text = "Opt";
				textToReplaceOption.text = "Opti";
			} else if (textToReplaceOption.text.Equals ("Opti")) {
				textToRemoveOption.text = "Opti";
				textToReplaceOption.text = "Opt";
			} else if (textToReplaceOption.text.Equals ("Opt")) {
				textToRemoveOption.text = "Optio";
				textToReplaceOption.text = "Op";
			} else if (textToReplaceOption.text.Equals ("Op")) {
				textToReplaceOption.text = "Option";
				textToReplaceOption.text = "O";
			} else if (textToReplaceOption.text.Equals ("O")) {
				textToRemoveOption.text = "Optione";
				textToReplaceOption.text = "";
			} else if (textToReplaceOption.text.Equals ("")) {
				textToRemoveOption.text = "Optiones";
				
			}
		}

		if (buttonExit) {

			if (textToRemoveExit.text.Equals ("Ausgang")) {
				textToRemoveExit.text = "Ausgan";
				textToReplaceExit.text = "";
			} else if (textToRemoveExit.text.Equals ("Ausgan")) {
				textToRemoveExit.text = "Ausga";
				textToReplaceExit.text = "E";
			} else if (textToRemoveExit.text.Equals ("Ausga")) {
				textToRemoveExit.text = "Aus";
				textToReplaceExit.text = "Ex";
			} else if (textToRemoveExit.text.Equals ("Aus")) {
				textToRemoveExit.text = "Au";
				textToReplaceExit.text = "Exi";
			} else if (textToRemoveExit.text.Equals ("Au")) {
				textToRemoveExit.text = "";
				textToReplaceExit.text = "Exit";
			}

		} else {

			if (textToReplaceExit.text.Equals ("Exit")) {
				textToRemoveExit.text = "A";
				textToReplaceExit.text = "Exi";
			} else if (textToReplaceExit.text.Equals ("Exi")) {
				textToRemoveExit.text = "Aus";
				textToReplaceExit.text = "Ex";
			} else if (textToReplaceExit.text.Equals ("Ex")) {
				textToRemoveExit.text = "Ausga";
				textToReplaceExit.text = "E";
			} else if (textToReplaceExit.text.Equals ("E")) {
				textToRemoveExit.text = "Ausgan";
				textToReplaceExit.text = "";
			} else if (textToReplaceExit.text.Equals ("")) {
				textToRemoveExit.text = "Ausgang";

			}  

		}

		if(buttonUser)
		{
			if(textToRemoveUser.text.Equals("Erneut Benutzer"))
			{
				textToRemoveUser.text = "Erneut Benutze";
				textToReplaceUser.text = "R";
			}
			else if(textToRemoveUser.text.Equals("Erneut Benutze"))
			{
				textToRemoveUser.text = "Erneut Benutz";
				textToReplaceUser.text = "Re";
			}
			else if(textToRemoveUser.text.Equals("Erneut Benutz"))
			{
				textToRemoveUser.text = "Erneut Benut";
				textToReplaceUser.text = "Res";
			}
			else if(textToRemoveUser.text.Equals("Erneut Benut"))
			{
				textToRemoveUser.text = "Erneut Benu";
				textToReplaceUser.text = "Rese";
			}
			else if(textToRemoveUser.text.Equals("Erneut Benu"))
			{
				textToRemoveUser.text = "Erneut Ben";
				textToReplaceUser.text = "Resel";
			}
			else if(textToRemoveUser.text.Equals("Erneut Ben"))
			{
				textToRemoveUser.text = "Erneut Be";
				textToReplaceUser.text = "Resele";
			}
			else if(textToRemoveUser.text.Equals("Erneut Be"))
			{
				textToRemoveUser.text = "Erneut ";
				textToReplaceUser.text = "Reselec";
			}
			else if(textToRemoveUser.text.Equals("Erneut "))
			{
				textToRemoveUser.text = "Erneut";
				textToReplaceUser.text = "Reselect";
			}
			else if(textToRemoveUser.text.Equals("Erneut"))
			{
				textToRemoveUser.text = "Erneu";
				textToReplaceUser.text = "Reselect U";
			}
			else if(textToRemoveUser.text.Equals("Erneu"))
			{
				textToRemoveUser.text = "Erne";
				textToReplaceUser.text = "Reselect Us";
			}
			else if(textToRemoveUser.text.Equals("Erne"))
			{
				textToRemoveUser.text = "Ern";
				textToReplaceUser.text = "Reselect Use";
			}
			else if(textToRemoveUser.text.Equals("Ern"))
			{
				textToRemoveUser.text = "Er";
				textToReplaceUser.text = "Reselect User";
			}
			else if(textToRemoveUser.text.Equals("Er"))
			{
				textToRemoveUser.text = "E";
			}
			else
			{
				textToRemoveUser.text = "";
			}

		}
		else
		{

			if(textToReplaceUser.text.Equals("Reselect User"))
			{
				textToRemoveUser.text = "E";
				textToReplaceUser.text = "Reselect Use";
			}
			else if(textToReplaceUser.text.Equals("Reselect Use"))
			{
				textToRemoveUser.text = "Er";
				textToReplaceUser.text = "Reselect Us";
			}
			else if(textToReplaceUser.text.Equals("Reselect Us"))
			{
				textToRemoveUser.text = "Ern";
				textToReplaceUser.text = "Reselect U";
			}
			else if(textToReplaceUser.text.Equals("Reselect U"))
			{
				textToRemoveUser.text = "Erne";
				textToReplaceUser.text = "Reselect ";
			}
			else if(textToReplaceUser.text.Equals("Reselect "))
			{
				textToRemoveUser.text = "Erneu";
				textToReplaceUser.text = "Reselect";
			}
			else if(textToReplaceUser.text.Equals("Reselect"))
			{
				textToRemoveUser.text = "Erneut";
				textToReplaceUser.text = "Reselec";
			}
			else if(textToReplaceUser.text.Equals("Reselec"))
			{
				textToRemoveUser.text = "Erneut B";
				textToReplaceUser.text = "Resele";
			}
			else if(textToReplaceUser.text.Equals("Resele"))
			{
				textToRemoveUser.text = "Erneut Be";
				textToReplaceUser.text = "Resel";
			}
			else if(textToReplaceUser.text.Equals("Resel"))
			{
				textToRemoveUser.text = "Erneut Ben";
				textToReplaceUser.text = "Rese";
			}
			else if(textToReplaceUser.text.Equals("Rese"))
			{
				textToRemoveUser.text = "Erneut Benu";
				textToReplaceUser.text = "Res";
			}
			else if(textToReplaceUser.text.Equals("Res"))
			{
				textToRemoveUser.text = "Erneut Benut";
				textToReplaceUser.text = "Re";
			}
			else if(textToReplaceUser.text.Equals("Re"))
			{
				textToRemoveUser.text = "Erneut Benutz";
				textToReplaceUser.text = "R";
			}
			else if(textToReplaceUser.text.Equals("R"))
			{
				textToRemoveUser.text = "Erneut Benutze";
				textToReplaceUser.text = "";
			}
			else
			{
				
				textToRemoveUser.text = "Erneut Benutzer";
				
			}

		}
	
	}

	public void playClick()
	{

		menuFade.postlevel = true;

	}

	public void exitClick()
	{

		Application.Quit ();

	}

	public void backToUser()
	{

		moveToMain.moveTo = false;
		moveToMain.moveBack = true;
		moveToMain.elapsedTime = 0;
		moveToMain.timeToMoveToMain = 0;
		newPlayerClick.pointerDown = false;
		newPlayerClick.goingToMenu = false;


	}
				
	public void playHoverEnter ()
	{
				
		buttonPlay = true;	

	}

	public void playHoverExit ()
	{
				
		buttonPlay = false;

	}
	

	public void optionsHoverEnter ()
	{

		buttonOption = true;	

	}

	public void optionsHoverExit ()
	{

		buttonOption = false;

	}

	public void exitHoverEnter ()
	{

		buttonExit = true;	

	}

	public void exitHoverExit ()
	{

		buttonExit = false;

	}

	public void backToUserEnter()
	{

		buttonUser = true;

	}

	public void backToUserExit()
	{

		buttonUser = false;

	}

}