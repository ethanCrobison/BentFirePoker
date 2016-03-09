using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public static float bulletSpeed = 5.0F;
	public static float lifeTime = 1.0F;		// life span in seconds
	public Vector3 direction;

	void FixedUpdate() {
		
//		lifeTime -= Time.fixedDeltaTime;
//		if (lifeTime <= 0) {
//			Destroy (this.gameObject);
//		}

		transform.Translate (direction * bulletSpeed * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.tag == "Player") {
			var EventBus = GameObject.Find("EventBus").GetComponent<EventsScript>();
			EventBus.PlayerHit ();
		} else if (other.tag == "Minion") {
			other.GetComponent<MinionScript> ().Die ();
		}

		Destroy (this.gameObject);
	}
}
