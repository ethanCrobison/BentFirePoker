using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public static float bulletSpeed = 5.0F;
	public Vector3 direction;

	void FixedUpdate() {
		transform.Translate (direction * bulletSpeed * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.tag == "Player") {
			GameObject player = other.gameObject;
			player.GetComponent<PlayerScript> ().STATE = PlayerScript.State.DEAD;
		}

		Debug.Log (other.tag);

		Destroy (gameObject);
	}
}
