using UnityEngine;
using System.Collections;

public class MagnifierControl : MonoBehaviour {

	
	public float rotationSpeed;
	
	private bool rotatingObject = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pz.z = 0;
		RaycastHit2D hit = Physics2D.Raycast(pz, Vector2.zero);
		if(rotatingObject) {
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, (180/Mathf.PI) * Mathf.Atan2((pz.y - transform.position.y), (pz.x - transform.position.x)));
		}
		
		// Checks for mouseclick while over object
		if (Input.GetMouseButtonDown (0)) {
			if(hit.collider != null) {
				rotatingObject = true;
			}
		} else if (Input.GetMouseButtonUp (0)){
			rotatingObject = false;
		}
	}

	void OnParticleCollision(GameObject other)
	{
		var collisionEvents = new ParticleSystem.CollisionEvent[16];
		var particleSystem = other.GetComponent<ParticleSystem> ();

		// adjust array length
		var safeLength = particleSystem.safeCollisionEventSize;
		if (collisionEvents.Length < safeLength) {
			collisionEvents = new ParticleSystem.CollisionEvent[safeLength];
		}

		// get collision events for the gameObject that the script is attached to
		var numCollisionEvents = particleSystem.GetCollisionEvents(gameObject, collisionEvents);

		GetComponentInChildren<ParticleSystem> ().Emit (numCollisionEvents);
	}
}
