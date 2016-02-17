using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {

	private GameObject playerObject;
	private RaycastHit2D hit;

	private static float ROTATE_ACCEL = 2 * Mathf.PI;

	void Start () {
		// store a reference to the player object
		playerObject = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		hit = Physics2D.Raycast (transform.GetChild(0).position, playerObject.transform.position - transform.GetChild(0).position);
		if (hit.collider != null) {
			if (hit.collider.gameObject.tag == "Player") {


				Debug.Log ("I see you!");
			}
		}
	}

	bool CanSeePlayer () {
		return false;
	}
}
