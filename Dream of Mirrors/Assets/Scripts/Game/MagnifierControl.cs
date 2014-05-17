using UnityEngine;
using System.Collections;

public class MagnifierControl : MonoBehaviour {

	
	public float rotationSpeed;
	
	private bool rotatingObject = false;
	public bool moveObject = false;

	private Color color;

	private Ray ray;
	private RaycastHit hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameFields.paused) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if( Physics.Raycast( ray, out hit )) {
				if (hit.collider.gameObject == gameObject) {
					var childMove = gameObject.transform.FindChild("MoveFocus");
					color.a = 255;
					childMove.renderer.material.color = color;
					//Debug.Log("hoverer");
				
					Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					pz.z = -2;
					transform.rotation = Quaternion.Euler(0.0f, 0.0f, (180/Mathf.PI) * Mathf.Atan2((pz.y - transform.position.y), (pz.x - transform.position.x)) + 90);
				}
			}

			if (moveObject) {
				Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				pz.z = -2;
				transform.position = pz; //Quaternion.Euler(pz.x, pz.y, pz.z);
			}
		}
	}

	void OnParticleCollision(GameObject other)
	{
		if (other.CompareTag("SunRays"))
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
}
