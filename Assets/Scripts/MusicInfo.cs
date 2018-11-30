using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInfo : MonoBehaviour {
	[SerializeField] private OptionsPopup optionsPopup;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Open(){
		//open settings popup
		this.gameObject.SetActive(true);
	}


	public void Close(){
		this.gameObject.SetActive(false);
	}


    public void OnOkButton(){
	Close ();
	optionsPopup.gameObject.SetActive (true);
	}
}
