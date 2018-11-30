using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceTrigger : MonoBehaviour {
	[SerializeField] private GameObject device;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other){
		DoorControl door = device.GetComponent<DoorControl> ();
		if (door != null ){
			door.Operate ();
		}
	}

	void OnTriggerExit ( Collider other ){
		DoorControl door = device.GetComponent<DoorControl> ();
		if (door != null ){
			door.Operate();
		}
	}
}
