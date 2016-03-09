using UnityEngine;
using System.Collections;

public class TreasureManager : MonoBehaviour {

	private int TreasureCount = 10;
	private EventsScript EventBus;

	// Use this for initialization
	void Start () {
		EventBus = GameObject.Find ("EventBus").GetComponent<EventsScript> ();
		EventBus.EventTreasureCollected += IncTreasure;
		EventBus.EventNewMinion += DecTreasure;
	}
	
	private void IncTreasure() {
		TreasureCount++;
	}

	private void DecTreasure() {
		TreasureCount--;
	}

	public bool Capacity() {
		return this.TreasureCount > 0;
	}
}
