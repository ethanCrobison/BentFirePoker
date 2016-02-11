using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour {

	public float horizontalSpeed = 2.0F;
	public float verticalSpeed = 2.0F;

	// TODO make these into one function, hopefully
	public event Action SpawnMinion = delegate {};
	public event Action SpawnWard = delegate {};

	private bool MinionType = true;

	void Update () {
		if (Input.GetButtonDown ("Spawn")) {
			Spawn ();
		}
		if (Input.GetButtonDown ("Ability1")) {
			ChangeColor (Color.cyan);
		} else if (Input.GetButtonDown ("Ability2")) {
			ChangeColor (Color.green);
		}
	}

	void FixedUpdate() {
		float h = horizontalSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
		float v = verticalSpeed * Time.deltaTime * Input.GetAxis("Vertical");
		transform.Translate (h, v, 0);
	}

	private void Spawn() {
		if (MinionType) {
			SpawnMinion.Invoke ();
		} else {
			SpawnWard.Invoke ();
		}
	}

	private void ChangeColor (Color color) {
		this.GetComponent<SpriteRenderer> ().color = color;
	}
}
