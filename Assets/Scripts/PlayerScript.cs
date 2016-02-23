using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour {

	private enum State {
		IDLE,
		WALKING,
		DODGING,
		INVOKING,
		CASTING,
		DEAD
	};
	private State STATE;

	private static float walkingSpeed = 5.0F;

	private static float dodgingSpeed = walkingSpeed * 20.0F;
	private static double dodgeCooldown = 5000;	// milliseconds
	private DateTime lastDodge;

	// from MinionManager
	public event Action SpawnMinion = delegate {};

	void Start () {
		STATE = State.IDLE;
		lastDodge = DateTime.Now;
	}

	void Update () {

		// CHECK MOVEMENT STATE
		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
			
			if (Input.GetButtonDown ("Dodge")) {				// Dodge button pressed

				double timeSinceLastDodge = DateTime.Now.Subtract (lastDodge).TotalMilliseconds;
				if (timeSinceLastDodge >= dodgeCooldown) {		// Cooldown period has expired
					
					STATE = State.DODGING;						// Update dodge status
					lastDodge = DateTime.Now;
				} else {
					STATE = State.WALKING;
				}
			} else {
				STATE = State.WALKING;							// Otherwise, you're just walking normally
			}
		} else {
			STATE = State.IDLE;									// You're not actually doing anything
		}

		// CHECK SPAWN MINION STATE - Which is independent of movement state
		if (Input.GetButtonDown ("Spawn")) {
			SpawnMinion.Invoke ();
		}

	}

	void FixedUpdate() {

		Vector2 velocity;

		// UPDATE PLAYER APPEARANCE BASED ON MOVEMENT STATE
		switch (STATE) {

		case State.IDLE:
			return;

		case State.WALKING:
			velocity = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")).normalized * walkingSpeed;
			break;

		case State.DODGING:
			velocity = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")).normalized * dodgingSpeed;
			break;

		default:
			return;
		}

		transform.Translate (velocity * Time.fixedDeltaTime);
	}

	public double GetTimeSinceLastDodge() {
		return DateTime.Now.Subtract (lastDodge).TotalMilliseconds;
	}

//	private void ChangeColor (Color color) {
//		this.GetComponent<SpriteRenderer> ().color = color;
//	}
	
}
