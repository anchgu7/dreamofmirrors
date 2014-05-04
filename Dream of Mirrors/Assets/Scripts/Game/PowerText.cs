using UnityEngine;
using System.Collections;

public class PowerText : MonoBehaviour {
	public void updateText(string text) {
		GetComponent<TextMesh>().text = text;
	}
}
