using UnityEngine;
using System.Collections;
//IS THIS CLASS NEEDED?
public class CircuitFound : MonoBehaviour {

	Animator anim;
	RaycastHit hit;
	Ray ray;
	//Camera camObj;
	//LayerMask layerMask;
	//Light lightItem;
	public bool fuseFound;

	public RenderTextureScript rendTexture;

	//TODO Rewrite this code
	//TODO IS THIS NEEDED??
	void Awake () {

		anim = GetComponent<Animator> ();
		//camObj = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
		//layerMask = GameObject.Find ("Fuse-2").layer;
		//lightItem = GameObject.Find ("LightForItem").GetComponent<Light> ();
		fuseFound = false;
	}

	void OnMouseDown () 
	{

		gameObject.layer = LayerMask.NameToLayer ("3DGUI");
		anim.SetTrigger ("CircuitFound");
		fuseFound = true;
		rendTexture.CreateRendTexture(gameObject);

		
	}
}
