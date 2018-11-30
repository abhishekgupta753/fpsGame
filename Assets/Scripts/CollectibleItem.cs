using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 3, 0);
	}


	void OnTriggerEnter(Collider other ){
		//Debug.Log ("Trigger called");
		PlayerCharacter player = other.GetComponent<PlayerCharacter> ();
		if (player != null) {
			//apply first-aid and remove the item
			player.FirstAid();
			Destroy(this.gameObject);
		}
	}
}
