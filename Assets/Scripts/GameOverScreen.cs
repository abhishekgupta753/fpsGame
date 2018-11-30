using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {
	[SerializeField] private Image crossHair;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Open(){
		// pause game and turn off crosshair
		Time.timeScale = 0;
		crossHair.gameObject.SetActive (false);
		//turn on popup
		this.gameObject.SetActive(true);
		//broadcast event
		Messenger.Broadcast(GameEvent.GAME_TIME_CHANGED);
		//activate mouse
		Cursor.lockState = CursorLockMode.None;
	}

	public void Close(){
		this.gameObject.SetActive (false);
	}

	public bool IsActive(){
		return this.gameObject.activeSelf;
	}

	public void OnExitGameButton(){
		Application.Quit();
	}

	public void OnStartAgainButton(){
		// reload same scene
 		SceneManager.LoadScene(0);
		Time.timeScale = 1;
		Messenger.Broadcast(GameEvent.GAME_TIME_CHANGED);
		}
	}

