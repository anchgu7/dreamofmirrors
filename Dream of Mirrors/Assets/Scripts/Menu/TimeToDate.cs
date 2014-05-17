using UnityEngine;
using System.Collections;

public class TimeToDate : MonoBehaviour {

	private int year, day, hour;

	// Use this for initialization
	void Start () {
		year = (int) GameFields.gameTime;
		day = year % 365;
		year /= 365;
		
		hour = day % 60;
		day /= 60;
		
		hour /= 3;
		
		GetComponent<TextMesh>().text = year + " Years, " + day + " Days, and " + hour + " Hours";
	}
}
