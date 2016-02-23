using UnityEngine;
using System.Collections;
using System;

public class SpitterScript : MonoBehaviour {

	private enum State {
		IDLE,
		APPROACHING,
		ATTACKING,
		DEAD
	}
	private State STATE;

	private FOVScript fov;

	private static float walkingSpeed = 4.0F;

	private static float attackRange = 1.5F;
	private static float attackCooldown = 1000F;
	private DateTime lastAttack;

	void Start () {
		STATE = State.IDLE;
		fov = GetComponent<FOVScript> ();
		lastAttack = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () {
		bool canSee = fov.canSeePlayer ();

		if (canSee) {
			float distance = fov.getDistance ();
			double timeSinceLastAttack = DateTime.Now.Subtract (lastAttack).TotalMilliseconds;

			if (distance < attackRange && timeSinceLastAttack >= attackCooldown) {
				STATE = State.ATTACKING;
			} else {
				STATE = State.APPROACHING;
			}

		} else {
			STATE = State.IDLE;
		}

	}

	void FixedUpdate () {

		switch (STATE) {

		case State.IDLE:
			return;

		case State.ATTACKING:
			Debug.Log ("attacking");
			break;

		case State.APPROACHING:
			Vector2 velocity = fov.getNormalizedDisplacement() * walkingSpeed;
			transform.Translate (velocity * Time.fixedDeltaTime);
			break;

		default:
			break;

		}
	}
}
