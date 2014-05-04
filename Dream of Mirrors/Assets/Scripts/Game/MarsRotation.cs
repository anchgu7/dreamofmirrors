using UnityEngine;
using System.Collections;

public class MarsRotation : MonoBehaviour {

	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		rigidbody2D.angularVelocity = -rotationSpeed;
	}
}
