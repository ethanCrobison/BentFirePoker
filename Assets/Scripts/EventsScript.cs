using UnityEngine;
using System;

public class EventsScript : MonoBehaviour {

	public event Action EventNewMinion = delegate {};
	public event Action EventTreasureCollected = delegate {};
	public event Action EventDestroyedMinion = delegate {};
	public event Action EventPlayerHit = delegate {};
	public event Action EventPlayerDeath = delegate {};
	public event Action EventExitReached = delegate {};

	// variables for all of the managers
	private MinionManager MinionManager;
	private TreasureManager TM;

	void Start() {
		MinionManager = GameObject.FindGameObjectWithTag("Player").GetComponent<MinionManager>();
		TM = GameObject.Find ("TreasureManager").GetComponent<TreasureManager> ();
	}

	public void NewMinion() {
		if (MinionManager.Capacity() && TM.Capacity()) {
			this.EventNewMinion.Invoke ();
		}
	}

	public void MinionDestroyed() {
		this.EventDestroyedMinion.Invoke ();
	}

	public void TreasureCollected () {
		this.EventTreasureCollected.Invoke ();
	}

	public void PlayerHit () {
		this.EventPlayerHit.Invoke ();
	}

	public void PlayerDie () {
		this.EventPlayerDeath.Invoke ();
	}

	public void ExitReached() {
		this.EventExitReached.Invoke ();
	}
}
