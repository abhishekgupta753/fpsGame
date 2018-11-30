using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour {
	[SerializeField] private Slider difficultySlider;
	[SerializeField] private OptionsPopup optionsPopup;
	[SerializeField] private Text speedValue; 
	// Use this for initialization
	void Start () {
		difficultySlider.value = PlayerPrefs.GetInt ("enemySpeed", 1);
		speedValue.text = ((int)difficultySlider.value).ToString();
		//numEnemiesValue.text = (int)difficultySlider.value;
		difficultySlider.value = PlayerPrefs.GetInt ("enemySpeed", 1);
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

	public void OnOKButton(){
		Close ();
		optionsPopup.gameObject.SetActive (true);
		PlayerPrefs.SetInt ("enemySpeed", (int)difficultySlider.value);
		Messenger<float>.Broadcast (GameEvent.SPEED_CHANGED, difficultySlider.value);

	}

	public void OnCancelButton(){
		Close ();
		optionsPopup.gameObject.SetActive (true);
	}

	//public void OnDifficultyValue(float numEnemies){
		//numEnemiesValue.text = numEnemies.ToString ();
	//}

	public void OnSpeedValue( float speed){
		speedValue.text = speed.ToString();
	}

	public bool IsActive() {
		return this.gameObject.activeSelf;
	}

}
