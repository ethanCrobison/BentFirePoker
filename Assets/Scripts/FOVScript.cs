using UnityEngine;
using System.Collections;

public class FOVScript : MonoBehaviour
{

	private Transform target;
	private Collider2D thisCollider;

	// Use this for initialization
	void Start ()
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		if (GetComponent<CircleCollider2D> ()) {
			thisCollider = GetComponent<CircleCollider2D> ();
		} else if (GetComponent<BoxCollider2D> ()) {
			thisCollider = GetComponent<BoxCollider2D> ();
		}
	}

	public bool canSeePlayer(float sightRange, int mask)
	{
		Vector2 currentLocation = transform.position;
		Vector2 playerLocation = target.position;

		thisCollider.enabled = false;
		RaycastHit2D hit = Physics2D.Raycast (currentLocation, playerLocation - currentLocation, sightRange, mask);
		thisCollider.enabled = true;

		if (hit.collider == null) {
			return false;
		}

		return (hit.collider.gameObject.tag == "Player");
	}

	public float getDistance() {
		return Vector2.Distance (transform.position, target.position);
	}

	public Vector3 getNormalizedDisplacement() {
		Vector3 displacement = (target.position - transform.position);
		displacement.Normalize ();
		return displacement;
	}
		
}

