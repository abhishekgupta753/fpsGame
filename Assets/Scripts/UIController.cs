using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	private int score;
	[SerializeField] private Text scoreValue;
	[SerializeField] private Image healthBar;
	[SerializeField] private OptionsPopup optionsPopup;
	[SerializeField] private SettingsPopup settingsPopup;
	private int _score;
	private int _health;
	[SerializeField] private Text healthValue;
	[SerializeField] private GameOverScreen gameOverScreen;



	// Use this for initialization
	void Start () {
		// init score
		score = 0;
		scoreValue.text = score.ToString ();
		healthBar.fillAmount = 1;
		healthBar.color = Color.green;
		// close options pop-up on start of game
		optionsPopup.Close ();
		settingsPopup.Close ();
		gameOverScreen.Close ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("escape") && 
			!optionsPopup.IsActive() &&
			!settingsPopup.IsActive () &&
			!gameOverScreen.IsActive()) {
			optionsPopup.Open ();
		}
	}


	void Awake() {
		Messenger.AddListener (GameEvent.ENEMY_DEAD, OnEnemyDead);
	//	Messenger<int>.AddListener (GameEvent.PLAYER_HIT, OnPlayerHit);
		Messenger<int>.AddListener (GameEvent.HEALTH_CHANGED, OnHealthChanged);
		Messenger.AddListener (GameEvent.PLAYER_DEAD, OnPlayerDead);
	}

	private void OnHealthChanged(int _health){
		this._health = _health;
		//healthValue.text = _health.ToString ();

		healthBar.fillAmount = _health / (float)5;
		Debug.Log(healthBar.fillAmount);
		if (healthBar.fillAmount < 0.40)
			healthBar.color = Color.red;
		else if (healthBar.fillAmount < 0.80)
			healthBar.color = Color.yellow;

		else if (healthBar.fillAmount <= 1)
			healthBar.color = Color.green;
	}

	private void OnEnemyDead() {
		_score += 1;
		scoreValue.text = _score.ToString ();
	}

	void OnDestroy() {
		//Messenger<int>.RemoveListener (GameEvent.PLAYER_HIT, OnPlayerHit);
		Messenger.RemoveListener (GameEvent.ENEMY_DEAD, OnEnemyDead);
		Messenger<int>.RemoveListener (GameEvent.HEALTH_CHANGED, OnHealthChanged);
		Messenger.RemoveListener (GameEvent.PLAYER_DEAD, OnPlayerDead);
	}

	//private void OnPlayerHit(int _health) {
		//this._health = _health;
		//healthValue.text = _health.ToString ();

		//healthBar.fillAmount = _health / (float)5;
		//Debug.Log(healthBar.fillAmount);
		//if (healthBar.fillAmount < 0.40)
			//healthBar.color = Color.red;
		//else if (healthBar.fillAmount < 0.80)
			//healthBar.color = Color.yellow;
	
	//}

	private void OnPlayerDead() {
		gameOverScreen.Open ();
	}
}
