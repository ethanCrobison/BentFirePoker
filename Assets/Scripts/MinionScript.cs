using UnityEngine;
using System.Collections;

public class MinionScript : MonoBehaviour {
	public float speed = 2.0F;
	public float distanceThresh = 3.0F;

	private GameObject ThePlayer;
	private Transform PlayerTrans;
	// TODO make this into a function?
	private bool behavior = true;

	void Awake() {
//		ThePlayer = GameObject.FindGameObjectWithTag ("Player");
		PlayerTrans = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void FixedUpdate () {
		// TODO make this into a single function call (too kludgey right now)
		if (behavior) {
			var distance = Vector2.Distance (this.transform.position, PlayerTrans.position);
			if (distance > distanceThresh) {
				FollowPlayer ();
			}
		} else {
			WatchNearby ();
		}
	}

	private void FollowPlayer() {
		Vector3 trajectory = PlayerTrans.position - this.transform.position;
		this.transform.Translate (Time.deltaTime * speed * trajectory);
	}

	private void WatchNearby() {
		
	}
}
