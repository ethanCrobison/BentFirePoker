using UnityEngine;
using System.Collections;

public class ChestScript : MonoBehaviour {

	public Sprite openedChest;
	public GameObject spinningCoin;

	private enum State
	{
		CLOSED,
		OPENED
	};
	private State STATE;

	private EventsScript EventBus;

	void Start () {
		STATE = State.CLOSED;
		EventBus = GameObject.Find ("EventBus").GetComponent<EventsScript> ();
	}


	void OnCollisionEnter2D (Collision2D collider) {
		if (STATE == State.OPENED) {
			return;
		}

		if (collider.gameObject.tag == "Player" || collider.gameObject.tag == "Minion") {
			EventBus.TreasureCollected ();
			STATE = State.OPENED;
			this.GetComponent<SpriteRenderer> ().sprite = openedChest;
			this.GetComponents<AudioSource> ()[0].Play ();
			this.GetComponents<AudioSource> ()[1].Play ();

//			GameObject.Instantiate (spinningCoin);

//			spinningCoin.transform.position = gameObject.transform.position;
		}
	}
}
