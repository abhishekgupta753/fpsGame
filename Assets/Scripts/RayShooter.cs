using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RayShooter : MonoBehaviour {
	private Camera _camera;
	private bool gamePaused =false;
	//public int aimSize = 16;

	// Use this for initialization
	void Start () {
		_camera = GetComponent<Camera> ();

		//hidethemousecursor
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
	}




	// Update is called once per frame
	void Update ()
	{
		if (!gamePaused){
		if (Input.GetMouseButtonDown (0)) {
			Vector3 point = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
			Ray ray = _camera.ScreenPointToRay (point);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = 
					hitObject.GetComponent<ReactiveTarget> ();
				//is this object our Enemy?
				if (target != null) {
					target.ReactToHit ();
				} else {
					// visually indicate where there was a hit
					StartCoroutine (SphereIndicator (hit.point));
				}
			}
		}
	}
	}



	private IEnumerator SphereIndicator(Vector3 hitPosition){
		GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.transform.localScale = new Vector3 (0.05f, 0.05f, 0.05f);
		sphere.transform.position = hitPosition;
		yield return new WaitForSeconds (1);
		Destroy (sphere);
	}

	//void OnGUI() {
	//	GUIStyle style = new GUIStyle();
		//style.fontSize = aimSize;
		////find the centre of the camera view and adjust for asterisk 
		//float posX = _camera.pixelWidth / 2 - aimSize / 4;
		//float posY = _camera.pixelHeight / 2 - aimSize / 2;
		//GUI.Label (new Rect (posX, posY, aimSize, aimSize), "*", style);
	//}


	void Awake(){
		Messenger.AddListener(GameEvent.GAME_TIME_CHANGED,OnGameTimeChanged);
	}

	void OnGameTimeChanged(){
				gamePaused=!gamePaused;
	}

	void OnDestroy(){
		Messenger.RemoveListener(GameEvent.GAME_TIME_CHANGED,OnGameTimeChanged);
			}
}
