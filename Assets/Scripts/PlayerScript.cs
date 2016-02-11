using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour {

	private Rigidbody2D rigidbody;
	private Vector2 velocity;
	private float speed = 2.0F;


	// TODO make these into one function, hopefully
	public event Action SpawnMinion = delegate {};
	public event Action SpawnWard = delegate {};

	private bool MinionType = true;

	void Start() {
		rigidbody = this.GetComponent<Rigidbody2D> ();
	}

	void Update () {

		velocity = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")).normalized * speed;

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
		rigidbody.MovePosition (rigidbody.position + velocity * Time.fixedDeltaTime);
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
