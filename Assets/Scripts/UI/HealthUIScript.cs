using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthUIScript : MonoBehaviour {

	private int health = 3;
	private EventsScript EventBus;

	void Start () {
		EventBus = GameObject.Find ("EventBus").GetComponent<EventsScript> ();
		EventBus.EventPlayerHit += DecHealth;
		UpdateText ();
	}

	private void UpdateText() {
		var textComponent = this.gameObject.GetComponent<Text> ();
		if (health > 0) {
			textComponent.text = string.Format ("Health: {0}", this.health);
		} else {
			textComponent.text = string.Format ("Dead");
			EventBus.PlayerDie ();
		}

	}

	private void DecHealth() {
		health--;
		UpdateText ();
	}
}
