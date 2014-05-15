using UnityEngine;
using System.Collections;

public class TimeToDate : MonoBehaviour {

	private int year, day, hour;

	// Use this for initialization
	void Start () {
		year = (int) GameFields.gameTime;
		day = year % 365;
		year /= 365;
		
		hour = day % 120;
		day /= 120;
		
		hour /= 5;
		
		GetComponent<TextMesh>().text = year + " Years, " + day + " Days, and " + hour + " Hours";
	}
}
