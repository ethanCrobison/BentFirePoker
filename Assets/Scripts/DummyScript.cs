using UnityEngine;
using System.Collections;

public class DummyScript : MonoBehaviour {

	private int hp;

	void Awake() {
		this.hp = 100;
	}

	void Update () {
		if (hp <= 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D () {
		Debug.Log ("hi");
		hp -= 100;
	}
}
