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
	private static float bulletSpeed = 4.0F;

	private DateTime lastAttack;

	public GameObject bullet;

	void Start () {
		STATE = State.IDLE;
		fov = GetComponent<FOVScript> ();
		lastAttack = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () {
		bool canSee = fov.canSeePlayer ();

		// Unobstructed raycast between enemy and player
		if (canSee) {
			float distance = fov.getDistance ();
			double timeSinceLastAttack = DateTime.Now.Subtract (lastAttack).TotalMilliseconds;

			if (distance < attackRange && timeSinceLastAttack >= attackCooldown) {
				STATE = State.ATTACKING;			// within attack range
			} else {
				STATE = State.APPROACHING;			// not within attack range
			}
		} else {
			STATE = State.IDLE;						// unaware of player
		}

	}

	void FixedUpdate () {

		switch (STATE) {

		case State.IDLE:							// IDLE: do nothing
			return;

		case State.ATTACKING:						// ATTACKING: create a bullet
			bullet = (GameObject)UnityEngine.Object.Instantiate (bullet);
			bullet.transform.position = transform.position;
			bullet.GetComponent<BulletScript> ().velocity = fov.getNormalizedDisplacement () * bulletSpeed;
			break;

		case State.APPROACHING:						// APPROACHING: move towards enemy
			Vector2 velocity = fov.getNormalizedDisplacement() * walkingSpeed;
			transform.Translate (velocity * Time.fixedDeltaTime);
			break;

		default:
			break;

		}
	}
}
