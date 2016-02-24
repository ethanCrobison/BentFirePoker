using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MinionUIScript : MonoBehaviour {

	private int _OrdinaryMinionCount = 0;

	void Start () {
		var eventBus = GameObject.Find ("EventBus").GetComponent<EventsScript>();
		eventBus.EventNewMinion += OnMinionSpawn;
		UpdateMinionCount ();
	}

	private void OnMinionSpawn() {
		_OrdinaryMinionCount += 1;
		UpdateMinionCount ();
	}

	private void UpdateMinionCount () {
		GameObject minionTextObject = this.gameObject;
		Text textComponent = minionTextObject.GetComponent<Text> ();
		textComponent.text = string.Format ("Minions: {0}", _OrdinaryMinionCount);
	}

}
