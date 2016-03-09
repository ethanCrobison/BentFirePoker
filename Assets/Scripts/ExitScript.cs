using UnityEngine;
using System.Collections;

public class ExitScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			var eventBus = GameObject.Find ("EventBus").GetComponent<EventsScript> ();
			eventBus.ExitReached ();
		}
	}
}
