using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject _enemyPrefab;
	[SerializeField] private GameObject _IguanaPrefab;
	private GameObject _enemy;
	private GameObject _Iguana;
	private GameObject[] enemies; 
	private GameObject[] Iguanas;
	public int numEnemies = 4;
	public int numIguanas = 4;
	public int i;
	public int j;
	private float enemySpeed = 3.0f;

	private GameObject _enemy1;
	private GameObject[] enemies1;
	public int numEnemies1 = 4;
	public int k;



	//update is called once per frame

	// Use this for initialization
	void Start () {
		enemies = new GameObject[numEnemies];  //////////////////////////////////////
		enemies1 = new GameObject[numEnemies1];
		Iguanas = new GameObject[numIguanas];
		//Iguanas [0]= _Iguana;
		//Iguanas [1]= _Iguana;
		//Iguanas [2]= _Iguana;
		//Iguanas [3]= _Iguana;
		for ( j=0 ; j<4 ; j++ ) {                            ////   i = numEnemies ; i < 4 ; i++ 
			if (Iguanas[j] == null) {
				_Iguana = Instantiate (_IguanaPrefab) as GameObject;
				_Iguana.transform.position = new Vector3 (5, 0, 5);
				float angle = Random.Range (0, 360);
				_Iguana.transform.Rotate (0, angle, 0);
				Iguanas [j] = _Iguana;
			}
			;
		}
	}

	void Awake() {
		Messenger<float>.AddListener (GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	private void OnSpeedChanged(float speed) {
		enemySpeed = speed;
	}
	
	// Update is called once per frame
	void Update () {
		for ( i=0 ; i<4 ; i++ ) {                            ////   i = numEnemies ; i < 4 ; i++ 
			if (enemies[i]==null) {
				_enemy = Instantiate (_enemyPrefab) as GameObject;
				_enemy.transform.position = new Vector3 (0, 0, 5);
				float angle = Random.Range (0, 360);
				_enemy.transform.Rotate (0, angle, 0);
				enemies [i] = _enemy;
			}
			;
		}


		for ( k=0 ; k<4 ; k++ ) {                            ////   i = numEnemies ; i < 4 ; i++ 
			if (enemies1[k]==null) {
				_enemy1 = Instantiate (_enemyPrefab) as GameObject;
				_enemy1.transform.position = new Vector3 (0, 9, 5);
				float angle = Random.Range (0, 360);
				_enemy1.transform.Rotate (0, angle, 0);
				enemies1 [k] = _enemy1;
			}
			;
		}


		
		
	}
}
