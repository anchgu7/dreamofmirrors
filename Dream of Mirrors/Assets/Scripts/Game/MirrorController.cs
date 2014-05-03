using UnityEngine;
using System.Collections;

public class MirrorController : MonoBehaviour {

	public float rotationSpeed;
	
	private bool rotatingObject = false;
	
	// Update is called once per frame
	void Update () {
		Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pz.z = 0;
		RaycastHit2D hit = Physics2D.Raycast(pz, Vector2.zero);
		if(rotatingObject) {
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, 57 * Mathf.Atan2((pz.y - transform.position.y), (pz.x - transform.position.x)));
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
}
