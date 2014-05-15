using UnityEngine;
using System.Collections;

public class LoseCondition : MonoBehaviour {

	private double levelStarted;

	void Update() {
		
		GameFields.gameTime += Time.deltaTime;
	
		Object[] settlements = GameObject.FindGameObjectsWithTag ("Settlement");
		if(settlements.Length == 0) {
			Application.LoadLevel (Application.loadedLevel + 1);
		}
	}
	
	void OnLevelWasLoaded(int level) {
		GameFields.gameTime = 0.0f;
	}
}
