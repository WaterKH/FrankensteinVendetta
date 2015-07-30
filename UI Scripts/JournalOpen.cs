//TODO Does this do anything?
using UnityEngine;
using System.Collections;

public class JournalOpen : MonoBehaviour {

		public GameObject journal;

		void OnMouseDown(){

				journal.GetComponent<Animation>().Play();
		}
}
