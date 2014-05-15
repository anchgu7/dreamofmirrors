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

	public void growSettlement(int spawnCount){
		GameObject settlementInstance;

		Transform test = transform.Find("EmptyPosition1");
		settlementInstance = Instantiate (Settlement, test.position, test.rotation) as GameObject;
		settlementInstance.transform.parent = Mars.transform;
		settlementInstance.GetComponentInChildren<AbsorbSunlight>().power = 90;
		if (spawnCount > 1) {
			settlementInstance.GetComponentInChildren<SettlementOperations> ().createdNewSettlement = true;
		}
		else{
			settlementInstance.GetComponentInChildren<AbsorbSunlight>().spawnCount = spawnCount;
			settlementInstance.GetComponentInChildren<SettlementOperations> ().createdNewSettlement = false;

		}

	}

	public bool hasCreatedNew(){
		return createdNewSettlement;
	}
}
