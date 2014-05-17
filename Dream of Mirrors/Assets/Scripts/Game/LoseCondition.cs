using UnityEngine;
using System.Collections;

public class LoseCondition : MonoBehaviour {

	public GameObject timer, settlement;

	void Update() {
		if (!GameFields.paused) {
			GameFields.gameTime += Time.deltaTime;
		
			timer.GetComponent<TextMesh>().text = "You have lasted:\n" + (int) (GameFields.gameTime / 3) + " hours";
	
			Object[] settlements = GameObject.FindGameObjectsWithTag ("Settlement");
			if(settlements.Length == 0) {
				Application.LoadLevel (Application.loadedLevel + 1);
			}
		
			settlement.GetComponent<TextMesh>().text = "Settlements:\n" + settlements.Length;
		}
	}
	
	void OnLevelWasLoaded(int level) {
		GameFields.gameTime = 0.0f;
	}
}
