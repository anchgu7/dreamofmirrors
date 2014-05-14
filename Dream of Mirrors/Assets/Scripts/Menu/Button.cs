using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	
	public int level;
	public float widthOffset = 50, heightOffset = 50;
	public float width = 100, height = 50;
	public string text;
	
	void OnGUI() {
		if (GUI.Button (new Rect (Screen.width / 2 - widthOffset, Screen.height / 2 + heightOffset, width, height), text)) {
			CameraFade.StartAlphaFade( Color.black, false, 2f, 0.0f, loadLevelOnComplete);
		}
	}
	
	void loadLevelOnComplete() {
		Application.LoadLevel (level);
	}
}