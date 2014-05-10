using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	void OnGUI() {
		if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 50, 100, 50), "Back")) {
			Application.LoadLevel (0);
		}
	}
}
