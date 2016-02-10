using UnityEngine;
using System;

public class MinionScript : MonoBehaviour {
	public float speed = 2.0F;
	public float distanceThresh = 3.0F;

	// TODO make these into a dag
	private Vector3 targetPosition = Vector3.one;

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
		}
	}

	void FixedUpdate () {
		if (targetPosition.z == 0.0) {
			var trajectory = TrajectoryBetween (targetPosition, this.transform.position);
			this.transform.Translate (Time.deltaTime * speed * trajectory);
		} else {
			MinionBehavior ();
		}
	}

	private void FollowPlayer() {
	var distance = Vector2.Distance (this.transform.position, PlayerTrans.position);
		if (distance > distanceThresh) {
			var trajectory = TrajectoryBetween (PlayerTrans.position, this.transform.position);
			this.transform.Translate (Time.deltaTime * speed * trajectory);
		}
	}

	private Vector3 TrajectoryBetween(Vector3 goal, Vector3 pos) {
		Vector3 trajectory = (goal - pos).normalized * speed;
		return trajectory;
	}
}
