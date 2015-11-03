//On ScriptHolder
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//This Script makes the transition between English and German text
public class mainMenu : MonoBehaviour {

	public bool buttonPlay;
	public bool buttonOption;
	public bool buttonExit;
	public bool buttonUser;

	public Text playGerman;
	public Text playEnglish;
	public Text optionGerman;
	public Text optionEnglish;
	public Text exitGerman;
	public Text exitEnglish;
	public Text userGerman;
	public Text userEnglish;

	public MoveToMainMenu moveToMain;
	public NewPlayerClick newPlayerClick;
	public mainMenu menuScript;

	public FadeInOut menuFade;
	public Stack<char> playEnglishStack = new Stack<char>();
	public Stack<char> playGermanStack = new Stack<char>();

	void Awake()
	{
		Time.timeScale = 1;
	}

	// Update is called once per frame
	void Update () 
	{
		/* THIS CAUSES ERRORS...
		if(buttonPlay)
		{
			if(playGerman.text.Length > 0)
				playGermanStack.Push (playGerman.text[0]);
			if(playGerman.text.Length >= 1)
				playGerman.text = playGerman.text.Substring(1);
			if(playEnglishStack.Count > 0)
				playEnglish.text += playEnglishStack.Pop();
		}
		else
		{
			if(playEnglish.text.Length > 0)
				playEnglishStack.Push(playEnglish.text[0]);
			if(playEnglish.text.Length >= 1)
				playEnglish.text = playEnglish.text.Substring(1);
			if(playGermanStack.Count > 0)
				playGerman.text += playGermanStack.Pop();
		}*/

		if (buttonPlay) 
		{
			if (playGerman.text.Equals ("Neus Spiel")) {
				playGerman.text = "Neus Spie";
				playEnglish.text = "P";
			} else if (playGerman.text.Equals ("Neus Spie")) {
				playGerman.text = "Neus Spi";
				playEnglish.text = "Pl";
			} else if (playGerman.text.Equals ("Neus Spi")) {
				playGerman.text = "Neus Sp";
				playEnglish.text = "Pla";
			} else if (playGerman.text.Equals ("Neus Sp")) {
				playGerman.text = "Neus S";
				playEnglish.text = "Play";
			} else if (playGerman.text.Equals ("Neus S")) {
				playGerman.text = "Neus ";
				playEnglish.text = "Play ";
			} else if (playGerman.text.Equals ("Neus ")) {
				playGerman.text = "Neus";
				playEnglish.text = "Play G";
			} else if (playGerman.text.Equals ("Neus")) {
				playGerman.text = "Neu";
				playEnglish.text = "Play Ga";
			} else if (playGerman.text.Equals ("Neu")) {
				playGerman.text = "Ne";
				playEnglish.text = "Play Gam";
			} else if (playGerman.text.Equals ("Ne")) {
				playGerman.text = "N";
				playEnglish.text = "Play Game";
			} else if (playGerman.text.Equals ("N")) {
				playGerman.text = "";
			}
						
		} else {

			if (playEnglish.text.Equals ("Play Game")) {
				playGerman.text = "N";
				playEnglish.text = "Play Gam";
			} else if (playEnglish.text.Equals ("Play Gam")) {
				playGerman.text = "Ne";
				playEnglish.text = "Play Ga";
			} else if (playEnglish.text.Equals ("Play Ga")) {
				playGerman.text = "Neu";
				playEnglish.text = "Play G";
			} else if (playEnglish.text.Equals ("Play G")) {
				playGerman.text = "Neus";
				playEnglish.text = "Play ";
			} else if (playEnglish.text.Equals ("Play ")) {
				playGerman.text = "Neus ";
				playEnglish.text = "Play";
			} else if (playEnglish.text.Equals ("Play")) {
				playEnglish.text = "Neus S";
				playEnglish.text = "Pla";
			} else if (playEnglish.text.Equals ("Pla")) {
				playGerman.text = "Neus Sp";
				playEnglish.text = "Pl";
			} else if (playEnglish.text.Equals ("Pl")) {
				playGerman.text = "Neus Spi";
				playEnglish.text = "P";
			} else if (playEnglish.text.Equals ("P")) {
				playGerman.text = "Neus Spie";
				playEnglish.text = "";
			} else if (playEnglish.text.Equals ("")) {
				playGerman.text = "Neus Spiel";
			}

		}

		if (buttonOption) {

			if (optionGerman.text.Equals ("Optiones")) {
				optionGerman.text = "Optione";
				optionEnglish.text = "O";
			}
			else if (optionGerman.text.Equals ("Optione")) {
				optionGerman.text = "Option";
				optionEnglish.text = "Op";
			}
			else if (optionGerman.text.Equals ("Option")) {
				optionGerman.text = "Optio";
				optionEnglish.text = "Opt";
			}
			else if (optionGerman.text.Equals ("Optio")) {
				optionGerman.text = "Opti";
				optionEnglish.text = "Opti";
			}
			else if (optionGerman.text.Equals ("Opti")) {
				optionGerman.text = "Opt";
				optionEnglish.text = "Optio";
			}
			else if (optionGerman.text.Equals ("Opt")) {
				optionGerman.text = "Op";
				optionEnglish.text = "Option";
			}
			else if (optionGerman.text.Equals ("Op")) {
				optionGerman.text = "O";
				optionEnglish.text = "Options";
			}
			else if (optionGerman.text.Equals ("O")) {
				optionGerman.text = "";

			}

		} 
		else 
		{

			if (optionEnglish.text.Equals ("Options")) {
				optionGerman.text = "O";
				optionEnglish.text = "Option";
			} else if (optionEnglish.text.Equals ("Option")) {
				optionGerman.text = "Op";
				optionEnglish.text = "Optio";
			} else if (optionEnglish.text.Equals ("Optio")) {
				optionGerman.text = "Opt";
				optionEnglish.text = "Opti";
			} else if (optionEnglish.text.Equals ("Opti")) {
				optionGerman.text = "Opti";
				optionEnglish.text = "Opt";
			} else if (optionEnglish.text.Equals ("Opt")) {
				optionGerman.text = "Optio";
				optionEnglish.text = "Op";
			} else if (optionEnglish.text.Equals ("Op")) {
				optionEnglish.text = "Option";
				optionEnglish.text = "O";
			} else if (optionEnglish.text.Equals ("O")) {
				optionGerman.text = "Optione";
				optionEnglish.text = "";
			} else if (optionEnglish.text.Equals ("")) {
				optionGerman.text = "Optiones";
				
			}
		}

		if (buttonExit) {

			if (exitGerman.text.Equals ("Ausgang")) {
				exitGerman.text = "Ausgan";
				exitEnglish.text = "";
			} else if (exitGerman.text.Equals ("Ausgan")) {
				exitGerman.text = "Ausga";
				exitEnglish.text = "E";
			} else if (exitGerman.text.Equals ("Ausga")) {
				exitGerman.text = "Aus";
				exitEnglish.text = "Ex";
			} else if (exitGerman.text.Equals ("Aus")) {
				exitGerman.text = "Au";
				exitEnglish.text = "Exi";
			} else if (exitGerman.text.Equals ("Au")) {
				exitGerman.text = "";
				exitEnglish.text = "Exit";
			}

		} else {

			if (exitEnglish.text.Equals ("Exit")) {
				exitGerman.text = "A";
				exitEnglish.text = "Exi";
			} else if (exitEnglish.text.Equals ("Exi")) {
				exitGerman.text = "Aus";
				exitEnglish.text = "Ex";
			} else if (exitEnglish.text.Equals ("Ex")) {
				exitGerman.text = "Ausga";
				exitEnglish.text = "E";
			} else if (exitEnglish.text.Equals ("E")) {
				exitGerman.text = "Ausgan";
				exitEnglish.text = "";
			} else if (exitEnglish.text.Equals ("")) {
				exitGerman.text = "Ausgang";

			}  

		}

		if(buttonUser)
		{
			if(userGerman.text.Equals("Erneut Benutzer"))
			{
				userGerman.text = "Erneut Benutze";
				userEnglish.text = "R";
			}
			else if(userGerman.text.Equals("Erneut Benutze"))
			{
				userGerman.text = "Erneut Benutz";
				userEnglish.text = "Re";
			}
			else if(userGerman.text.Equals("Erneut Benutz"))
			{
				userGerman.text = "Erneut Benut";
				userEnglish.text = "Res";
			}
			else if(userGerman.text.Equals("Erneut Benut"))
			{
				userGerman.text = "Erneut Benu";
				userEnglish.text = "Rese";
			}
			else if(userGerman.text.Equals("Erneut Benu"))
			{
				userGerman.text = "Erneut Ben";
				userEnglish.text = "Resel";
			}
			else if(userGerman.text.Equals("Erneut Ben"))
			{
				userGerman.text = "Erneut Be";
				userEnglish.text = "Resele";
			}
			else if(userGerman.text.Equals("Erneut Be"))
			{
				userGerman.text = "Erneut ";
				userEnglish.text = "Reselec";
			}
			else if(userGerman.text.Equals("Erneut "))
			{
				userGerman.text = "Erneut";
				userEnglish.text = "Reselect";
			}
			else if(userGerman.text.Equals("Erneut"))
			{
				userGerman.text = "Erneu";
				userEnglish.text = "Reselect U";
			}
			else if(userGerman.text.Equals("Erneu"))
			{
				userGerman.text = "Erne";
				userEnglish.text = "Reselect Us";
			}
			else if(userGerman.text.Equals("Erne"))
			{
				userGerman.text = "Ern";
				userEnglish.text = "Reselect Use";
			}
			else if(userGerman.text.Equals("Ern"))
			{
				userGerman.text = "Er";
				userEnglish.text = "Reselect User";
			}
			else if(userGerman.text.Equals("Er"))
			{
				userGerman.text = "E";
			}
			else
			{
				userGerman.text = "";
			}

		}
		else
		{

			if(userEnglish.text.Equals("Reselect User"))
			{
				userGerman.text = "E";
				userEnglish.text = "Reselect Use";
			}
			else if(userEnglish.text.Equals("Reselect Use"))
			{
				userGerman.text = "Er";
				userEnglish.text = "Reselect Us";
			}
			else if(userEnglish.text.Equals("Reselect Us"))
			{
				userGerman.text = "Ern";
				userEnglish.text = "Reselect U";
			}
			else if(userEnglish.text.Equals("Reselect U"))
			{
				userGerman.text = "Erne";
				userEnglish.text = "Reselect ";
			}
			else if(userEnglish.text.Equals("Reselect "))
			{
				userGerman.text = "Erneu";
				userEnglish.text = "Reselect";
			}
			else if(userEnglish.text.Equals("Reselect"))
			{
				userGerman.text = "Erneut";
				userEnglish.text = "Reselec";
			}
			else if(userEnglish.text.Equals("Reselec"))
			{
				userGerman.text = "Erneut B";
				userEnglish.text = "Resele";
			}
			else if(userEnglish.text.Equals("Resele"))
			{
				userGerman.text = "Erneut Be";
				userEnglish.text = "Resel";
			}
			else if(userEnglish.text.Equals("Resel"))
			{
				userGerman.text = "Erneut Ben";
				userEnglish.text = "Rese";
			}
			else if(userEnglish.text.Equals("Rese"))
			{
				userGerman.text = "Erneut Benu";
				userEnglish.text = "Res";
			}
			else if(userEnglish.text.Equals("Res"))
			{
				userGerman.text = "Erneut Benut";
				userEnglish.text = "Re";
			}
			else if(userEnglish.text.Equals("Re"))
			{
				userGerman.text = "Erneut Benutz";
				userEnglish.text = "R";
			}
			else if(userEnglish.text.Equals("R"))
			{
				userGerman.text = "Erneut Benutze";
				userEnglish.text = "";
			}
			else
			{
				userGerman.text = "Erneut Benutzer";
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