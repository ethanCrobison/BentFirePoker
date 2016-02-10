using UnityEngine;
using System;

public class MinionScript : MonoBehaviour {
	public float speed = 2.0F;
	public float distanceThresh = 3.0F;

	private GameObject ThePlayer;
	private Transform PlayerTrans;
	private Action MinionBehavior;

	void Awake() {
		PlayerTrans = GameObject.FindGameObjectWithTag ("Player").transform;
		MinionBehavior = FollowPlayer;
	}

	void FixedUpdate () {
		MinionBehavior ();
	}

	private void FollowPlayer() {
	var distance = Vector2.Distance (this.transform.position, PlayerTrans.position);
		if (distance > distanceThresh) {
			Vector3 trajectory = PlayerTrans.position - this.transform.position;
			this.transform.Translate (Time.deltaTime * speed * trajectory);
		}
	}

	private void WatchNearby() {
		
	}
}
