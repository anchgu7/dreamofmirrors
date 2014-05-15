using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	//public int lifeStartingValue;
	public int life;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (life <= 0) {
			Destroy(gameObject);
            GameObject destroySound = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("Sound"));
            destroySound.audio.clip = Resources.Load<AudioClip>("Audio/SFX/asteroid_explosion");
            destroySound.audio.loop = false;
            destroySound.audio.Play();
		}
	}

	void OnParticleCollision(GameObject other) {
		life -= 10;
	}
}
