using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	private bool paused = false;

	public ParticleSystem sun;
	private GameObject[] emitters;
	
	public GameObject background;
	
	public float widthOffset = 75, heightOffset = 50;
	public float width = 150, height = 75;
	public Texture2D buttonSprite;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			if (paused) unPause ();
			else pause ();
		}
	}
	
	public void unPause() {
		sun.Play ();
		foreach (GameObject part in emitters)
			part.particleSystem.Play();
		background.renderer.enabled = false;
		paused = false;
		GameFields.paused = false;
	}
	
	public void pause() {
		sun.Pause ();
		emitters = GameObject.FindGameObjectsWithTag("FocusEmitter");
		foreach (GameObject part in emitters)
			part.particleSystem.Pause();
		background.renderer.enabled = true;
		paused = true;
		GameFields.paused = true;
	}
	
	void OnGUI() {
		if (GameFields.paused) {
			if (GUI.Button (new Rect (Screen.width / 2 - widthOffset, Screen.height / 2 + heightOffset, width, height), buttonSprite)) {
				playButtonSound();
				unPause ();
			}
		}
	}
	
	void playButtonSound()
	{
		GameObject buttonSound = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("Sound"));
		buttonSound.audio.clip = Resources.Load<AudioClip>("Audio/SFX/menu_button");
		buttonSound.audio.loop = false;
		buttonSound.audio.Play();
	}
}
