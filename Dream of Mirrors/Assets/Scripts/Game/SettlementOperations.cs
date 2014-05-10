using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SettlementOperations : MonoBehaviour {
	
	public GameObject Settlement;
	public GameObject Mars;
	public GameObject Empty;
	public bool createdNewSettlement;

	public void selfDestruct() {
		Destroy(gameObject);
	}

	public void growSettlement(){
		GameObject settlementInstance;

		Transform test = transform.Find("EmptyPosition1");
		settlementInstance = Instantiate (Settlement, test.position, test.rotation) as GameObject;
		settlementInstance.transform.parent = Mars.transform;
		settlementInstance.GetComponentInChildren<AbsorbSunlight>().power = 90;
		settlementInstance.GetComponentInChildren<SettlementOperations> ().createdNewSettlement = true;


		//GameObject test1 = GameObject.Find("Reflector");

		//ImplementedInActionScriptAttribute = test1.GetComponent (AbsorbSunlight);
	}

	public bool hasCreatedNew(){
		return createdNewSettlement;
	}
}
