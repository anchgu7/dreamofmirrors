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
	public float startTime;

	void Start(){
		startTime = Time.time;
	}

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
		else if (startTime + 120 < Time.time && !(settle.hasCreatedNew())) {
			//power -= 50;
			settle.growSettlement();
			settle.GetComponentInChildren<SettlementOperations> ().createdNewSettlement = true;
		}
	}
	
	void OnParticleCollision(GameObject other) {

		if (power < 150) {
			power += powerGain;
			//if(power > 100){
			//	power = 100;
			//}
			text.updateText (power.ToString ());
	    }
		//Destroy (other);

		var collisionEvents = new ParticleSystem.CollisionEvent[16];
		var particleSystem = other.GetComponent<ParticleSystem> ();
		
		// adjust array length
		var safeLength = particleSystem.safeCollisionEventSize;
		if (collisionEvents.Length < safeLength) {
			collisionEvents = new ParticleSystem.CollisionEvent[safeLength];
		}
		
		// get collision events for the gameObject that the script is attached to
		var numCollisionEvents = particleSystem.GetCollisionEvents(gameObject, collisionEvents);

		for (int i = 0; i < numCollisionEvents; i++) {
			//Particle temp = collisionEvents[i] as Particle;
			//Destroy(temp);
		}

	}
}
