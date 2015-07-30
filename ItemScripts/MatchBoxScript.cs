//On FPC in FrankensteinChapter1
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Keeps track of how many matches the User has, also activates the light
//TODO Fix the glitch that happens when you only have 1 match left
public class MatchBoxScript : MonoBehaviour {

	public int match = 0;
	GameObject matchBoxGO;
	public GameObject matchStickGO;
	public int timeLeft = 30;
	public bool counting;
	public Text addedMatch;
	bool isActivated = false;
	public CanvasGroup matchTextAlpha;
	bool hasRan;

	RenderTextureScript rendTexture;

	void Awake()
	{

		rendTexture = GameObject.Find("FPC").GetComponent<RenderTextureScript>();

	}

	void Update ()
	{

		if (Input.GetMouseButton (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 100)) {
				if (hit.collider.tag == "matchBox") {
					matchBoxGO = hit.collider.gameObject;
					matchBoxGO.GetComponent<MeshRenderer> ().enabled = false;
					matchBoxGO.GetComponent<Collider> ().enabled = false;
					match += 10;
					timeLeft = 30;
					isActivated = true;
					if(!hasRan)
					{

						matchBoxGO.transform.rotation = new Quaternion(matchBoxGO.transform.rotation.x+90,
						                                               matchBoxGO.transform.rotation.y,
						                                               matchBoxGO.transform.rotation.z,
						                                               matchBoxGO.transform.rotation.w);
						rendTexture.CreateRendTexture(matchBoxGO);
						hasRan = true;

					}

				}
			}
		}

		if (isActivated) 
		{

			matchTextAlpha.alpha = Mathf.Lerp (matchTextAlpha.alpha, 1, Time.deltaTime);
			if (matchTextAlpha.alpha >= 1) {
			
				matchTextAlpha.alpha = Mathf.Lerp(matchTextAlpha.alpha, 0, Time.deltaTime);
				if(matchTextAlpha.alpha <= 0)
					isActivated = false;

			}
		}
	}
}
