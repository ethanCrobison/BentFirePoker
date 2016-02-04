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
			ability1 ();
		} else if (Input.GetButtonDown ("Ability2")) {
			ability2 ();
		} else if (Input.GetButtonDown ("Ability3")) {
		 	ability3 ();
		}
	}

	void FixedUpdate() {
		float h = horizontalSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
		float v = verticalSpeed * Time.deltaTime * Input.GetAxis("Vertical");
		transform.Translate (h, v, 0);
	}

	void ability1 () {
		changeColor (Color.cyan);
	}
	void ability2 () {
		changeColor (Color.green);
	}
	void ability3 () {
		changeColor (Color.magenta);
	}

	void changeColor (Color color) {
		this.GetComponent<SpriteRenderer> ().color = color;
	}

}
