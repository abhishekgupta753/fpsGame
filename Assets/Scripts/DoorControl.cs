using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour {
	private bool doorIsOpen;
	// Use this for initialization
	void Start () {
		doorIsOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Operate(){
		if (doorIsOpen) {
			iTween.MoveTo (this.gameObject, new Vector3 (5.4864f, -0.78367f, -19.88f), 5);
		} else {
			iTween.MoveTo (this.gameObject, new Vector3 (5.4864f, -0.78367f, -12.72f), 5);
		}
		doorIsOpen = !doorIsOpen;
	}
}
