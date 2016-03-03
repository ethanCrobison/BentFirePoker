using UnityEngine;
using System.Collections;

public class FOVScript : MonoBehaviour
{

	private Transform target;
	private CircleCollider2D thisCircleCollider;

	// Use this for initialization
	void Start ()
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		thisCircleCollider = GetComponent<CircleCollider2D> ();
	}

	public bool canSeePlayer(float sightRange, int mask)
	{
		Vector2 currentLocation = transform.position;
		Vector2 playerLocation = target.position;

		thisCircleCollider.enabled = false;

		RaycastHit2D hit = Physics2D.Raycast (currentLocation, playerLocation - currentLocation, sightRange, mask);

		thisCircleCollider.enabled = true;

		if (hit == null) {
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

