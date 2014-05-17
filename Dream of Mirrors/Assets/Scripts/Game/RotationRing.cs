using UnityEngine;
using System.Collections;

public class RotationRing : MonoBehaviour {

	public float rotationSpeed;
	
	private bool rotatingObject = false;
	public bool hoverOn = false;

	private Color color;

	private Ray ray;
	private RaycastHit hit;
	private float targetX;
	private float targetY;
	private bool hasTarget = false;

	// Use this for initialization
	void Start () {
		color = renderer.material.color;
		color.a = 0;
		renderer.material.color = color;
		hasTarget = false;
	}
	
	// Update is called once per frame
	void Update () {

		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if( Physics.Raycast( ray, out hit )) 
		{
			if (hit.collider.gameObject == gameObject)
			{
				hoverOn = true;
				Color color = renderer.material.color;
				color.a = 255;
				renderer.material.color = color;
				GetComponentInChildren<FocusTargetLine>().visible = true;

				Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				pz.z = -2;
				transform.rotation = Quaternion.Euler(0.0f, 0.0f, (180/Mathf.PI) * Mathf.Atan2((pz.y - transform.position.y), (pz.x - transform.position.x)) + 90);
			}
		}


		if (Input.GetMouseButtonDown (0)) 
		{
			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//RaycastHit hit;
			if( Physics.Raycast( ray, out hit )) 
			{
					if (hit.collider.gameObject == gameObject){
						rotatingObject = true;
						//Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
						//pz.z = -2;
						//transform.rotation = Quaternion.Euler(0.0f, 0.0f, (180/Mathf.PI) * Mathf.Atan2((pz.y - transform.position.y), (pz.x - transform.position.x)) + 90);
					//transform.LookAt( hit.transform );
					//Debug.Log("helllo");
					}
			}
		}

		if (Input.GetMouseButtonUp(0) && rotatingObject)
		{
			rotatingObject = false;
			//var childMove = gameObject.transform.FindChild("MoveFocus");
			//childMove.GetComponent<MoveFocus>().visible = false;

		}

		if (rotatingObject) 
		{
			Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			pz.z = -2;
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, (180/Mathf.PI) * Mathf.Atan2((pz.y - transform.position.y), (pz.x - transform.position.x)) + 90);
			var parentTransform = transform.parent.GetComponent<Transform>();
			parentTransform.rotation = Quaternion.Euler(0.0f, 0.0f, (180/Mathf.PI) * Mathf.Atan2((pz.y - transform.position.y), (pz.x - transform.position.x)) + 90);

			if (renderer.material.color.a != 0)
			{
				Color color = renderer.material.color;
				color.a = 255;
				renderer.material.color = color;
			}
			GetComponentInChildren<FocusTargetLine>().visible = true;
		}

		if (hasTarget) {
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, (180/Mathf.PI) * Mathf.Atan2((targetY - transform.position.y), (targetX - transform.position.x)) + 90);
			var parentTransform = transform.parent.GetComponent<Transform>();
			parentTransform.rotation = Quaternion.Euler(0.0f, 0.0f, (180/Mathf.PI) * Mathf.Atan2((targetY - transform.position.y), (targetX - transform.position.x)) + 90);
		}

		if (hoverOn) 
		{
			//var childMove = gameObject.transform.FindChild("MoveFocus");
			//transform.GetComponentInChildren<MoveFocus>().visible = true;
		}

		if (!hoverOn && !rotatingObject)
		{
			color.a = 0;
			renderer.material.color = color;
			GetComponentInChildren<FocusTargetLine>().visible = false;
		}

		hoverOn = false;

	}

	/*public void setTarget(Collision target){
		hasTarget = true;
		targetX = target.transform.position.x;
		targetY = target.transform.position.y;
	
	}

	public void clearTarget(){
		hasTarget = false;
	}*/
}
