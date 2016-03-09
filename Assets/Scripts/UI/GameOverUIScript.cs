using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverUIScript : MonoBehaviour {

	void Start () {
		var eventBus = GameObject.Find ("EventBus").GetComponent<EventsScript> ();
		eventBus.EventPlayerHit += PlayerDeath;
	}

	private void PlayerDeath() {
		Text textComponent = this.gameObject.GetComponent<Text> ();
		textComponent.text = string.Format ("Game Over");
	}
}
