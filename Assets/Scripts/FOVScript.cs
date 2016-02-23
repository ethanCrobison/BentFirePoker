using UnityEngine;
using System.Collections;

public class FOVScript : MonoBehaviour
{

	private Transform target;
	private BoxCollider2D thisBoxCollider;

	// Use this for initialization
	void Start ()
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		thisBoxCollider = GetComponent<BoxCollider2D> ();
	}

	public bool canSeePlayer()
	{
		Vector2 currentLocation = transform.position;
		Vector2 playerLocation = target.position;

		thisBoxCollider.enabled = false;
		RaycastHit2D hit = Physics2D.Raycast (currentLocation, playerLocation - currentLocation);
		thisBoxCollider.enabled = true;

		return (hit.collider.gameObject.tag == "Player");
	}

	public float getDistance() {
		return Vector2.Distance (transform.position, target.position);
	}

	public Vector2 getNormalizedDisplacement() {
		Vector2 displacement = (target.position - transform.position);
		displacement.Normalize ();
		return displacement;
	}
		
}

