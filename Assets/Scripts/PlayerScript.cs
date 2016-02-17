using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour {

	private Vector2 velocity;
	private float speed = 5.0F;

	private float dodgeCooldown = 0F;
	private enum PlayState{Walking, Dodging, Invoking, Casting};
	private PlayState PlayerState;

	public event Action SpawnMinion = delegate {};

	void Start () {
		PlayerState = PlayState.Walking;
	}

	void Update () {
		
		switch (PlayerState) {
		case PlayState.Walking:
			velocity = new Vector3 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0).normalized * speed;
			if (Input.GetButtonDown ("Dodge") && dodgeCooldown <= 0F) {
				velocity *= 20;
				PlayerState = PlayState.Dodging;
				dodgeCooldown = 3F;
			} else if (dodgeCooldown > 0F) {
				dodgeCooldown -= Time.deltaTime;
			}
			break;
		case PlayState.Dodging:
			velocity = new Vector3 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0).normalized * speed * 20;
			break;
		default:
			break;
		}

		if (Input.GetButtonDown ("Spawn")) {
			Spawn ();
		}
		if (Input.GetButtonDown ("Ability1")) {
			ChangeColor (Color.cyan);
		}
	}

	void FixedUpdate() {
		this.transform.Translate (velocity * Time.fixedDeltaTime);
		if (PlayerState == PlayState.Dodging) {
			PlayerState = PlayState.Walking;
		}
	}

	private void Spawn() {
		SpawnMinion.Invoke ();
	}

	private void ChangeColor (Color color) {
		this.GetComponent<SpriteRenderer> ().color = color;
	}

	public float ReportCooldown () {
		return this.dodgeCooldown;
	}
}
