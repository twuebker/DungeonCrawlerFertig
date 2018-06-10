using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
	
	public Image Background;	
	private bool isPause = false;
	private Rect butRect;
	private float ctrlWidth = 160;
	private float ctrlHeight = 30;
	// Use this for initialization
	void Awake () {
		butRect = new Rect ((Screen.width - ctrlWidth)/2, 0, ctrlWidth, ctrlHeight);
		Background.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			ToggleTimeScale();
		}
	}

	void OnGUI () {
		if (isPause) {
			butRect.y = (Screen.height - ctrlHeight) / 2;

			if (GUI.Button (butRect, "Weiter")) {
				ToggleTimeScale ();
			}

			butRect.y += ctrlHeight + 20;
			if (GUI.Button (butRect, "Spiel Beenden")) {
				ToggleTimeScale ();
				SceneManager.LoadScene("StartMenu" , LoadSceneMode.Single);
			}


				
		}
	}

	
	void ToggleTimeScale () {
		if (!isPause) {
			Time.timeScale = 0;
			Background.enabled = true;
		} else {
			Time.timeScale = 1;
			Background.enabled = false;
		}
		isPause = !isPause;

	}
}
