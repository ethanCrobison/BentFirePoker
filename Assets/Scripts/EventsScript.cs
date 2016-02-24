using UnityEngine;
using System;

public class EventsScript : MonoBehaviour {

	public event Action EventNewMinion = delegate {};
	public event Action EventTreasureCollected = delegate {};

	public void NewMinion() {
		// TODO any validation?
		this.EventNewMinion.Invoke ();
	}

	public void TreasureCollected () {
		this.EventTreasureCollected.Invoke ();
	}

}
