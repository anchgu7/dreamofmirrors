using UnityEngine;
using System.Collections;

public class FocusTargetLine : MonoBehaviour {

	bool visible = false;
	Color color;

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
}
