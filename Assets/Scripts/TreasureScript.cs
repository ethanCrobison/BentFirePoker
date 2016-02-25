using UnityEngine;
using System.Collections;

public class TreasureScript : MonoBehaviour {

	public int value { get; private set;}
	private EventsScript EventBus;

	void Awake() {
		value = 10;
		EventBus = GameObject.Find ("EventBus").GetComponent<EventsScript> ();
	}
	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			EventBus.TreasureCollected ();
			Destroy (this.gameObject);
		}
	}
}