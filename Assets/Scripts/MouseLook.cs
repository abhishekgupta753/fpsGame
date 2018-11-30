using UnityEngine;
using System.Collections;
public class MouseLook : MonoBehaviour{
	//enum to set values by name instead of number.
	//makes code more readable!
	public float sensitivityHorz=9.0f;
	public float sensitivityVert=9.0f;
	public float minVert=-45.0f;
	public float maxVert=45.0f;
	private float _rotationX=0.0f;
	private bool gamePaused;

	public enum RotationAxes{
		MouseXAndY=0,
		MouseX=1,
		MouseY=2
		}
	//public class - scope variable so it shows up in Inspector
	public RotationAxes axes = RotationAxes.MouseXAndY;


	void Start(){
		gamePaused = false;
	}

	//Update is called once per frame
	void Update(){
		if(!gamePaused){
		if(axes==RotationAxes.MouseX){
			//horizontal rotation here
			transform.Rotate(0,Input.GetAxis("Mouse X")*sensitivityHorz,0);
		}
		else if(axes==RotationAxes.MouseY){
			_rotationX-=Input.GetAxis("Mouse Y")*sensitivityVert;
			_rotationX=Mathf.Clamp(_rotationX, minVert, maxVert);
			transform.localEulerAngles=new Vector3(_rotationX, 0, 0);
			//vertical rotation here

		}else{
            //both horizontal and vertical rotation here
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp (_rotationX, minVert, maxVert);
			float delta = Input.GetAxis("Mouse X") * sensitivityHorz; 
			float rotationY = transform.localEulerAngles.y + delta;
			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
		}


	    }
	}

	void Awake (){
		Messenger.AddListener(GameEvent.GAME_TIME_CHANGED, OnGameTimeChanged);
	}

	private void OnGameTimeChanged(){
		gamePaused = !gamePaused;
	}


	void OnDestroy(){
		Messenger.RemoveListener (GameEvent.GAME_TIME_CHANGED, OnGameTimeChanged);
	}
}