using UnityEngine;
using System.Collections;

public class LoseCondition : MonoBehaviour {

	public GameObject timer, settlement;

	private int year, day, hour;

	void Update() {
		if (!GameFields.paused) {
			GameFields.gameTime += Time.deltaTime;
			
			year = (int) GameFields.gameTime;
			day = year % 365;
			year /= 365;
			
			hour = day % 60;
			day /= 60;
			
			hour /= 3;
		
			timer.GetComponent<TextMesh>().text = "Time Passed:\n" + year + " year(s)\n" + day + " day(s)\n" + hour + " hour(s)";
	
			Object[] settlements = GameObject.FindGameObjectsWithTag ("Settlement");
			if(settlements.Length == 0) {
				Application.LoadLevel (Application.loadedLevel + 1);
			}
		
			settlement.GetComponent<TextMesh>().text = "Settlements\nRemaining:\n" + settlements.Length;
		}
	}
	
	void OnLevelWasLoaded(int level) {
		GameFields.gameTime = 0.0f;
	}
}
