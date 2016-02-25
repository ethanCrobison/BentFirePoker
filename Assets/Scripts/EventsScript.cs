using UnityEngine;
using System;

public class EventsScript : MonoBehaviour {

	public event Action EventNewMinion = delegate {};
	public event Action EventTreasureCollected = delegate {};
	public event Action EventDestroyedMinion = delegate {};

	// variables for all of the managers
	private MinionManager MinionManager;

	void Awake() {
		MinionManager = GameObject.FindGameObjectWithTag("Player").GetComponent<MinionManager>();
	}

	public void NewMinion() {
		// TODO any validation?
		if (MinionManager.minionCount < 5) {
			this.EventNewMinion.Invoke ();
		}
	}

	public void MinionDestroyed() {
		this.EventDestroyedMinion.Invoke ();
	}

	public void TreasureCollected () {
		this.EventTreasureCollected.Invoke ();
	}

}
