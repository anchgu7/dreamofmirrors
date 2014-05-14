using UnityEngine;
using System.Collections;

public class MoveFocus : MonoBehaviour {

	private bool rotatingObject = false;
	
	private Color color;

	public bool visible = false;
	public bool highlight = false;

	private Ray ray;
	private RaycastHit hit;
	private bool moveObjectnow = false;

	// Use this for initialization
	void Start () {
		//renderer.material.color = new Color (255, 255, 255,255);
	}
	
	// Update is called once per frame
	void Update () {
		//visible = transform.parent.GetComponent<RotationRing> ().hoverOn;
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if( Physics.Raycast( ray, out hit )) 
		{
			var rotationRing = transform.Find("RotationRing");

			if (hit.collider.gameObject == gameObject)
			{
				//color = new Color (255,0,0,255);
				//renderer.material.color = color;
				highlight = true;

				if (Input.GetMouseButtonDown(0))
				{
					moveObjectnow = true;
					transform.parent.GetComponent<MagnifierControl>().moveObject = moveObjectnow;
				}
				if (moveObjectnow && Input.GetMouseButtonUp(0))
				{
					moveObjectnow = false;
					transform.parent.GetComponent<MagnifierControl>().moveObject = moveObjectnow;
				}
				
				//Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				//pz.z = -2;
				//transform.rotation = Quaternion.Euler(0.0f, 0.0f, (180/Mathf.PI) * Mathf.Atan2((pz.y - transform.position.y), (pz.x - transform.position.x)) + 90);
			}
			else
			{
				highlight = false;
				//color = new Color (255,255,255,255);
				//renderer.material.color = color;
			}
		}

		/*if (visible)// && !highlight) 
		{
			color = new Color (255, 255, 255, 255);
			renderer.material.color = color;
		}
		else if (highlight)
		{
			color = new Color (255,0,0,255);
			renderer.material.color = color;
		}
		else
		{
			color = new Color (0,0,0,0);
			renderer.material.color = color;
		}*/
		if (highlight)
		{
			color = new Color (255, 0, 0, 255);
			renderer.material.color = color;
		}
		else
		{
			color = new Color (255,255,255,255);
			renderer.material.color = color;
		}
	}
}
