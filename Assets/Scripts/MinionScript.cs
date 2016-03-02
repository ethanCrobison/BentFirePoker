using UnityEngine;
using System;

public class MinionScript : MonoBehaviour {
	public float speed = 2.0F;
	public float distanceThresh = 3.0F;

	private Vector3 targetPosition;
	private bool hasTarget = false;

	private GameObject ThePlayer;
	private Transform PlayerTrans;
	private Action MinionBehavior;

	void Awake() {
		PlayerTrans = GameObject.FindGameObjectWithTag ("Player").transform;
		MinionBehavior = FollowPlayer;
	}

	void Update() {
		// TODO move this to the minion manager (instead of every single minion lol)
		if (Input.GetMouseButtonDown (0)) {
			targetPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			targetPosition.z = 0.0f;
			hasTarget = true;
		}
	}

	void FixedUpdate () {
		if (hasTarget) {
			GoToTargetPos ();	
		} else {
			MinionBehavior ();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Enemy")) {
			Die ();
			Destroy (other.gameObject);

		}
	}

	public void Die() {
		// TODO bad practice but final demo is today
		EventsScript eventBus = GameObject.Find ("EventBus").GetComponent<EventsScript> ();
		eventBus.MinionDestroyed ();
		Destroy (this.gameObject);
	}

	private void FollowPlayer() {
		var distance = Vector2.Distance (this.transform.position, PlayerTrans.position);
		if (distance > distanceThresh) {
			var trajectory = TrajectoryBetween (PlayerTrans.position, this.transform.position);
			this.transform.Translate (Time.deltaTime * speed * trajectory);
		}
	}

	private void GoToTargetPos() {
		var trajectory = TrajectoryBetween (targetPosition, this.transform.position);
		this.transform.Translate (Time.deltaTime * speed * trajectory);

		if (Vector2.Distance (this.transform.position, targetPosition) < 0.1f) {
			hasTarget = false;
		}
	}

	private Vector3 TrajectoryBetween(Vector3 goal, Vector3 pos) {
		return (goal - pos).normalized * speed;
	}
}
