using UnityEngine;
using System.Collections;

public class ChestScript : MonoBehaviour {

	public Sprite openedChest;

	private enum State
	{
		CLOSED,
		OPENED
	};
	private State STATE;

	// Use this for initialization
	void Start () {
		STATE = State.CLOSED;
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	void OnCollisionEnter2D (Collision2D collider) {
		if (STATE == State.OPENED) {
			return;
		}

		if (collider.gameObject.tag == "Player") {
			STATE = State.OPENED;
			this.GetComponent<SpriteRenderer> ().sprite = openedChest;
			this.GetComponent<AudioSource> ().Play ();
		}
	}
}
