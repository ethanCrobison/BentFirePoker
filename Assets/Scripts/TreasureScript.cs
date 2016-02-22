using UnityEngine;
using System.Collections;

public class TreasureScript : MonoBehaviour {

	private TreasureUIScript TUS;

	void Awake() {
		TUS = GameObject.Find ("TreasureUI").GetComponent<TreasureUIScript> ();
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			TUS.IncrementTreasure ();
			Destroy (this.gameObject);
		}
	}
}
