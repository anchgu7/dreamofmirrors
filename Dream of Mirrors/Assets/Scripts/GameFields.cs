using UnityEngine;
using System.Collections;

public class GameFields : MonoBehaviour {

	private static GameFields instance = null;
	public static GameFields Instance { get { return instance; } }
	
	public static double gameTime;
		
	void Awake() {
		instance = this;
	}
}
