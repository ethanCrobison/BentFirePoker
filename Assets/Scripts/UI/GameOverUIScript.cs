using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverUIScript : MonoBehaviour {

	void Start () {
		var eventBus = GameObject.Find ("EventBus").GetComponent<EventsScript> ();
		eventBus.EventPlayerDeath += PlayerDeath;
		eventBus.EventExitReached += YouWin;
	}

	private void PlayerDeath() {
		Text textComponent = this.gameObject.GetComponent<Text> ();
		textComponent.text = string.Format ("Game Over");
	}

	private void YouWin() {
		Text textComponent = this.gameObject.GetComponent<Text> ();
		textComponent.text = string.Format ("You have escaped!");
		var player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScript>();
		player.STATE = PlayerScript.State.DEAD; // lol KLUDGE
	}
}
