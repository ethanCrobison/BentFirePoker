using UnityEngine;
using System.Collections;

public class MinionScript : MonoBehaviour {
	public float speed = 2.0F;
	public float distanceThresh = 3.0F;

	private GameObject ThePlayer;
	private Transform PlayerTrans;

	void Awake() {
//		ThePlayer = GameObject.FindGameObjectWithTag ("Player");
		PlayerTrans = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update () {
		var distance = Vector2.Distance (this.transform.position, PlayerTrans.position);
		if (distance > distanceThresh) {
			followPlayer ();
		}
	}

	void followPlayer() {
		Vector3 trajectory = PlayerTrans.position - this.transform.position;
		this.transform.Translate (Time.deltaTime * speed * trajectory);
	}
}
