using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {
	private int _health;
	public int maxHealth = 5;
	// Use this for initialization
	void Start () {
		_health = 5;
	}

	public void Hit(){
		_health -= 1;
		Debug.Log ("Health: " + _health);

		Messenger<int>.Broadcast (GameEvent.HEALTH_CHANGED,_health); /////new line --- new line
		//Messenger.Broadcast (_health); /////new line --- new line

		if (_health == 0) {
			//Debug.Break ();
			//Debug.Log("HEALTH IS 0");
			Messenger.Broadcast (GameEvent.PLAYER_DEAD);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FirstAid() { 
		if (_health < maxHealth){
			_health+=2;
			if(_health > maxHealth){
				_health = maxHealth;
			}

			Messenger<int>.Broadcast (GameEvent.HEALTH_CHANGED, _health);
		}
	}
}
