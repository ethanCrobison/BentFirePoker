using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour {

	public enum State {
		IDLE,
		WALKING,
		DODGING,
		INVOKING,
		CASTING,
		DEAD
	};
	public State STATE;

	private static float walkingSpeed = 5.0F;

	private static float dodgingSpeed = walkingSpeed * 20.0F;
	private static double dodgeCooldown = 5000;	// milliseconds
	private DateTime lastDodge;

	// from MinionManager
	private EventsScript EventBus;


	void Awake() {
		EventBus = GameObject.Find ("EventBus").GetComponent<EventsScript> ();
		EventBus.EventPlayerHit += Die;
	}


	void Start () {
		SpawnMinion ();
		STATE = State.IDLE;
		lastDodge = DateTime.Now;
	}


	void Update () {
		if (STATE == State.DEAD) {
			return;
		}
			

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
			SpawnMinion ();
		}

	}
		
	void FixedUpdate() {

		Vector2 velocity;

		// UPDATE PLAYER APPEARANCE BASED ON MOVEMENT STATE
		switch (STATE) {

		case State.IDLE:
			return;

		case State.DEAD:
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

	private void SpawnMinion() {
		EventBus.NewMinion ();
	}

	private void Die() {
		this.STATE = State.DEAD;

	}

}
