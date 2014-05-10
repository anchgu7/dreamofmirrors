using UnityEngine;
using System.Collections;

public class LoseCondition : MonoBehaviour {
	void Update() {
		Object[] settlements = GameObject.FindGameObjectsWithTag ("Settlement");
		if(settlements.Length == 0) {
			Application.LoadLevel (Application.loadedLevel + 1);
		}
	}
}
