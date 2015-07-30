using UnityEngine;
using System.Collections;

//TODO Is this needed?
public class ItemFound : MonoBehaviour {

		public ItemsInInventory items;
		public CircuitFound item;
		public GameObject itemObject;
		Ray ray;
		RaycastHit hit;
		public GameObject Fuse;
		public int counter = 0;

	// Update is called once per frame
	void Update () {
				if (item.fuseFound && counter == 0) {
						items.Inventory.Add(Fuse);	
						counter = 1;
				}
		}
		
}
