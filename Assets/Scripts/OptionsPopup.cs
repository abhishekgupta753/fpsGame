using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPopup : MonoBehaviour {
	[SerializeField] private Image crossHair;
	[SerializeField] private SettingsPopup settingsPopup;
	[SerializeField] private OptionsPopup optionsPopup;
	[SerializeField] private MusicInfo musicInfoPopup;

	public void Open(){
		// pause game & turn off crosshair
		Time.timeScale = 0;
		crossHair.gameObject.SetActive (false);
		//turn on popup
		this.gameObject.SetActive (true);
		//Activate Mouse
		Cursor.lockState = CursorLockMode.None;
		Messenger.Broadcast (GameEvent.GAME_TIME_CHANGED);
	}

	public void Close(){
		// turn off popup & turn on crosshair
		this.gameObject.SetActive (false);
		crossHair.gameObject.SetActive (true);
		// lock the mouse cursor to centre of view
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void OnSettingsButton(){
		this.gameObject.SetActive (false);
		settingsPopup.Open ();
	}

	public void OnExitGameButton(){
		Application.Quit();
	}

	public void OnReturnToGameButton(){
		// unpause game &close popup
		Time.timeScale = 1;
		Close();
		Messenger.Broadcast (GameEvent.GAME_TIME_CHANGED);

	}

	public void OnMusicInfoButton(){
		this.gameObject.SetActive (false);
		musicInfoPopup.Open ();
	}

	public bool IsActive() {
		return this.gameObject.activeSelf;
	}
}