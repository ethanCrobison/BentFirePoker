using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour {

	public float horizontalSpeed = 2.0F;
	public float verticalSpeed = 2.0F;

	public event Action SpawnMinion = delegate {};

	void Update () {
		if (Input.GetButtonDown ("Spawn")) {
			SpawnMinion.Invoke ();
		}
		if (Input.GetButtonDown ("Ability1")) {
			Ability1 ();
		} else if (Input.GetButtonDown ("Ability2")) {
			Ability2 ();
		} else if (Input.GetButtonDown ("Ability3")) {
		 	Ability3 ();
		}
	}

	void FixedUpdate() {
		float h = horizontalSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
		float v = verticalSpeed * Time.deltaTime * Input.GetAxis("Vertical");
		transform.Translate (h, v, 0);
	}

	private void Ability1 () {
		changeColor (Color.cyan);
	}
	private void Ability2 () {
		changeColor (Color.green);
	}
	private void Ability3 () {
		changeColor (Color.magenta);
	}

	private void changeColor (Color color) {
		this.GetComponent<SpriteRenderer> ().color = color;
	}
}
