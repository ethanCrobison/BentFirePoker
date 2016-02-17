using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour {

	private Rigidbody2D playerRigid;
	private Vector2 velocity;
	private float speed = 5.0F;

	//private float cooldown = 3.0F;


	public event Action SpawnMinion = delegate {};

	void Start() {
		playerRigid = this.GetComponent<Rigidbody2D> ();
	}

	void Update () {
		velocity = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")).normalized * speed;
		if (Input.GetButtonDown("Dodge")) {
			velocity *= 20;
		}

		if (Input.GetButtonDown ("Spawn")) {
			Spawn ();
		}
		if (Input.GetButtonDown ("Ability1")) {
			ChangeColor (Color.cyan);
		}
	}

	void FixedUpdate() {
		playerRigid.MovePosition (playerRigid.position + velocity * Time.fixedDeltaTime);
	}

	private void Spawn() {
		SpawnMinion.Invoke ();
	}

	private void ChangeColor (Color color) {
		this.GetComponent<SpriteRenderer> ().color = color;
	}
}
