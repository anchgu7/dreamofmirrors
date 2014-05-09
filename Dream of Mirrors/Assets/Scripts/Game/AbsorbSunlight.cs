using UnityEngine;
using System.Collections;

public class AbsorbSunlight : MonoBehaviour {
	
	// Associated settlement
	public SettlementOperations settle;
	
	// How much power each sunlight particle gives
	public float powerGain;
	
	// Power that this settlement has
	public float power;
	public float powerDecay;
	
	// Object that shows how much power is left
	public PowerText text;
	
	// Time for power to go down
	public float decayTime;
	private float lastDecay;

	
	void Awake() {
		text.updateText(power.ToString());
	}
	
	void Update() {
		if (Time.time > lastDecay + decayTime) {
			power -= powerDecay;
			lastDecay = Time.time;
			text.updateText(power.ToString());
		}
		
		if (power <= 0) {
			settle.selfDestruct();
		}
		else if (power >= 100 && !settle.hasCreatedNew()) {
			power -= 50;
			settle.growSettlement();
			settle.GetComponentInChildren<SettlementOperations> ().createdNewSettlement = true;
		}
	}
	
	void OnParticleCollision(GameObject other) {
		power += powerGain;
		text.updateText(power.ToString());
	}
}
