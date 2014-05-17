using UnityEngine;
using System.Collections;

public class MarsRotation : MonoBehaviour {

	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		rigidbody2D.angularVelocity = -rotationSpeed;
	}
	
	void Update() {
		if (!GameFields.paused && rigidbody2D.angularVelocity > -rotationSpeed) {
			rigidbody2D.angularVelocity = -rotationSpeed;
		} else {
			rigidbody2D.angularVelocity = 0.0f;
		}
	}
}
