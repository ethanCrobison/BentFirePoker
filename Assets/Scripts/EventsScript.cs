using UnityEngine;
using System;

public class EventsScript : MonoBehaviour {

	public event Action EventNewMinion = delegate {};
	public event Action EventTreasureCollected = delegate {};
	public event Action EventDestroyedMinion = delegate {};
	public event Action EventPlayerHit = delegate {};
	public event Action EventPlayerDeath = delegate {};

	// variables for all of the managers
	private MinionManager MinionManager;
	private TreasureManager TM;

	void Awake() {
		MinionManager = GameObject.FindGameObjectWithTag("Player").GetComponent<MinionManager>();
		TM = GameObject.Find ("TreasureManager").GetComponent<TreasureManager> ();
	}

	public void NewMinion() {
		// TODO any validation?
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
}
