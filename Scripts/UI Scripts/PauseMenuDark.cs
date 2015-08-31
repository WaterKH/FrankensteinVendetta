using UnityEngine;
using System.Collections;

//TODO Is this still in use?
public class PauseMenuDark : MonoBehaviour {

	public float alphaFadeValue = 0.4f;
	public Texture blackTexture;


	void OnGUI(){


		GUI.color = new Color(alphaFadeValue, alphaFadeValue, alphaFadeValue, alphaFadeValue);
		GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height ), blackTexture );

	}
}
