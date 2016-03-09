using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthUIScript : MonoBehaviour {

	private int health = 3;

	void Start () {
		var eventBus = GameObject.Find ("EventBus").GetComponent<EventsScript> ();
		eventBus.EventPlayerHit += DecHealth;
		UpdateText ();
	}

	private void UpdateText() {
		var textComponent = this.gameObject.GetComponent<Text> ();
		if (health > 0) {
			textComponent.text = string.Format ("Health: {0}", this.health);
		} else {
			textComponent.text = string.Format ("Dead");
		}

	}

	private void DecHealth() {
		health--;
		UpdateText ();
	}
}
