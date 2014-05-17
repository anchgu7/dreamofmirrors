using UnityEngine;
using System.Collections;

public class FocusTargetLine : MonoBehaviour {

	public bool visible = false;
	Color color;
	public bool collide = false;
	public GameObject rotationRing;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (visible) 
		{
			color = renderer.material.color;
			if (color.a < 255)
				color.a = 255;
			renderer.material.color = color;
		}
		else
		{
			color = renderer.material.color;
			if (color.a > 0)
				color.a = 0;
			renderer.material.color = color;
		}


	}

	void OnCollisionEnter (Collision other)
	{
		Debug.Log ("Collide");
		//collide = true;
		//rotationRing.GetComponent<RotationRing> ().setTarget (other);
	}

	void OnCollisionExit (Collision other)
	{
		//collide = false;
		//rotationRing.GetComponent<RotationRing> ().clearTarget ();
	}
	
}
