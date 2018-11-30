using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyStates {alive,dead};

public class WanderingAI : MonoBehaviour {
	public float enemySpeed = 3.0f;
	public float obstacleRange = 5.0f;
	private EnemyStates _state;
	[SerializeField] private GameObject _laserbeamPrefab;
	private GameObject _laserbeam;

	// Use this for initialization
	void Start () {
		_state = EnemyStates.alive;
	}
	
	// Update is called once per frame
	void Update () {
		//Move Enemy and generate Ray
		if (_state == EnemyStates.alive) {  // newline 
			transform.Translate (0, 0, enemySpeed * Time.deltaTime);
			Ray ray = new Ray (transform.position, transform.forward);

			//Spherecast and determine if Enemy needs to turn
			RaycastHit hit;

			if (Physics.SphereCast (ray, 0.75f, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				if(hitObject.GetComponent<PlayerCharacter>()){
					//Sphere cast hit player, fire laser!!
					if (_laserbeam == null) {
						_laserbeam = Instantiate (_laserbeamPrefab) as GameObject;
						_laserbeam.transform.position =
								transform.TransformPoint (0, 1.5f, 1.5f);
						_laserbeam.transform.rotation = transform.rotation;
					}
				}

				else if (hit.distance < obstacleRange) {
					float turnAngle = Random.Range (-110, 110);
					transform.Rotate (0, turnAngle, 0);
				}
			}
		}
	}
	public void ChangeState(EnemyStates state){
		_state = state;
	}

	void Awake (){
		Messenger<float>.AddListener (GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	private void OnSpeedChanged (float speed) {
		enemySpeed = speed;
	}

	void OnDestroy(){
		Messenger<float>.RemoveListener (GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

}
