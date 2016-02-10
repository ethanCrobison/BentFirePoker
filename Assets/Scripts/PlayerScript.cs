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
			if (MinionType) {
				SpawnMinion.Invoke ();
			} else {
				SpawnWard.Invoke ();
			}
		}
		if (Input.GetButtonDown ("Ability1")) {
			MinionType = false;
			ChangeColor (Color.cyan);
		} else if (Input.GetButtonDown ("Ability2")) {
			MinionType = true;
			ChangeColor (Color.green);
		}
	}

	void FixedUpdate() {
		float h = horizontalSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
		float v = verticalSpeed * Time.deltaTime * Input.GetAxis("Vertical");
		transform.Translate (h, v, 0);
	}
		
	private void ChangeColor (Color color) {
		this.GetComponent<SpriteRenderer> ().color = color;
	}
}
