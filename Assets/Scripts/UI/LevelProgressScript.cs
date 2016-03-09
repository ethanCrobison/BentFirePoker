using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelProgressScript : MonoBehaviour {

	private int Level = 1;

	// Use this for initialization
	void Start () {
		var eventBus = GameObject.Find ("EventBus").GetComponent<EventsScript> ();
		eventBus.EventExitReached += IncLevel;
		UpdateText ();
	}
	
	private void IncLevel() {
		this.Level++;
		UpdateText ();
	}

	private void UpdateText () {
		var textComponent = this.gameObject.GetComponent<Text> ();
		textComponent.text = string.Format ("Level: {0}", this.Level);
	}
}
