using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public int playerDamage;
	private float moveTime = 0.5f;

	private Transform target;
	private float inverseMoveTime;

	private BoxCollider2D boxCollider;	// The BoxCollider2D component attached to this object
	private Rigidbody2D rb2D;			// The Rigidbody2D component attached to this object

	void Start () {
		playerDamage = 10;
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		inverseMoveTime = 1f / moveTime;

	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Player")) {
			Destroy (other.gameObject);
		}
	}

	void FixedUpdate () {
		if (target == null)
			return;
		
		MoveEnemy ();
	}

	public void MoveEnemy() {

		if ((transform.position - target.position).sqrMagnitude > Mathf.Epsilon) {
			Vector3 newPosition = Vector3.MoveTowards (transform.position, target.position, inverseMoveTime * Time.deltaTime);
			transform.position = newPosition;

		}

	}
}
