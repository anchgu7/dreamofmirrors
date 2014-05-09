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
		}
	}

	void OnParticleCollision(GameObject other) {
		life -= 1;
	}
}
