using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	
	public int level;
	public float widthOffset = 75, heightOffset = 50;
	public float width = 150, height = 75;
	public string text;
	public Texture2D buttonSprite;
	
	void OnGUI() {
		if (buttonSprite == null) {
			if (GUI.Button (new Rect (Screen.width / 2 - widthOffset, Screen.height / 2 + heightOffset, width, height), text)) {
				CameraFade.StartAlphaFade( Color.black, false, 2f, 0.0f, loadLevelOnComplete);
			}
		} else {
			if (GUI.Button (new Rect (Screen.width / 2 - widthOffset, Screen.height / 2 + heightOffset, width, height), buttonSprite)) {
				CameraFade.StartAlphaFade( Color.black, false, 2f, 0.0f, loadLevelOnComplete);
			}
		}
		
	}
	
	void loadLevelOnComplete() {
		Application.LoadLevel (level);
	}
}