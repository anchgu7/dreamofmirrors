using UnityEngine;
using System.Collections;

public class LoseCondition : MonoBehaviour {

	void Update() {
		
		GameFields.gameTime += Time.deltaTime;
		
		GetComponent<TextMesh>().text = "Time Passed: " + (int) GameFields.gameTime;
	
		Object[] settlements = GameObject.FindGameObjectsWithTag ("Settlement");
		if(settlements.Length == 0) {
			Application.LoadLevel (Application.loadedLevel + 1);
		}
	}
	
	void OnLevelWasLoaded(int level) {
		GameFields.gameTime = 0.0f;
	}
}
