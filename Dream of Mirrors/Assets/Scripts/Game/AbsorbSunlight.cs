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
	public float maxPower = 150;
	
	// Object that shows how much power is left
	public PowerText text;
	
	
	// Time for power to go down
	public float decayTime;
	private float lastDecay;
	public float startTime;
	public float spawnTime;
	public int spawnCount = 0;
    public bool playSound;

	void Start(){
		startTime = Time.time;
	}

	void Awake() {
		text.updatePower(power, maxPower);
	}
	
	void Update() {
		if (!GameFields.paused) {
			if (Time.time > lastDecay + decayTime) {
				power -= powerDecay;
				lastDecay = Time.time;
				text.updatePower(power, maxPower);
			}
		
			if (power <= 0 && settle.isVisible()) {
				settle.selfDestruct();
            	string sound = "Audio/SFX/settlement_explosion";
            	playSFX(sound);
			} else if (startTime + spawnTime < Time.time && !(settle.hasCreatedNew()) && settle.isVisible()) {
				spawnCount++;
				settle.growSettlement(spawnCount);
				settle.GetComponentInChildren<SettlementOperations> ().createdNewSettlement = true;
            	string sound = "Audio/SFX/settlement_expansion";
           		playSFX(sound);
			}

       	 	if(power == maxPower && !playSound) {
            	string sound = "Audio/SFX/settlement_full_energy";
            	playSFX(sound);
            	playSound = true;
       	 	}
        	if(power < maxPower) {
            	playSound = false;
        	}
        }
	}
	
	void OnParticleCollision(GameObject other) {
		var particleSystem = other.GetComponent<ParticleSystem> ();
		if (power < maxPower && particleSystem.tag.Equals("FocusEmitter") ){
			power += powerGain;
			text.updatePower (power, maxPower);
	    }
		else if(power < maxPower && particleSystem.tag.Equals("SunRays")){
			power += (powerGain/4);
			text.updatePower (power, maxPower);
		}
	}

    void playSFX(string fileName)
    {
        GameObject SFX = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("Sound"));
        SFX.audio.clip = Resources.Load<AudioClip>(fileName);
        SFX.audio.loop = false;
        SFX.audio.Play();
    }
}
