using UnityEngine;
using System.Collections;

public class PowerText : MonoBehaviour {
	public void updatePower(float power, float max) {
		transform.localScale = new Vector3(power/max, power/max, 1);
	}
}
