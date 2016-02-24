using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public Vector2 velocity;

	// Use this for initialization
	void Start () {
		velocity = new Vector2 (0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		transform.Translate (velocity * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.tag == "Enemy") {
			return;
		}

		if (other.tag == "Player") {
			GameObject player = other.gameObject;
			player.GetComponent<PlayerScript> ().STATE = PlayerScript.State.DEAD;
		}

		Destroy (gameObject);
	}
}
