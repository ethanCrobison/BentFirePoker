using UnityEngine;
using System.Collections;

public class TreasureScript : MonoBehaviour {

	private TreasureUIScript TUS;

	void Awake() {
		TUS = GameObject.Find ("TreasureUI").GetComponent<TreasureUIScript> ();
	}

	void OnTriggerEnter2D () {
		TUS.IncrementTreasure ();
	}
}
