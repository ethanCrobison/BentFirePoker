using UnityEngine;
using System.Collections;

public abstract class MovingObject : MonoBehaviour {

	public float moveTime = 0.1f;		// Time it takes to move, in seconds
//	public LayerMask blockingLayer;		// Layer on which collision will be checked

	private BoxCollider2D boxCollider;	// The BoxCollider2D component attached to this object
	private Rigidbody2D rb2D;			// The Rigidbody2D component attached to this object
	private float inverseMoveTime;		// Use to make movement more efficient

	// Protected virtual functions can be overwritten by inheriting classes
	protected virtual void Start () {
		boxCollider = GetComponent<BoxCollider2D> ();
		rb2D = GetComponent<Rigidbody2D> ();
		inverseMoveTime = 1f / moveTime;
	}

	// Returns true if able to move and false if not
	protected bool Move(int xDir, int yDir, out RaycastHit2D hit) {
		Vector2 start = transform.position;
		Vector2 end = start + new Vector2 (xDir, yDir);

		// Disable so we don't hit our own boxCollider
		boxCollider.enabled = false;

		// Call a line from start to end to check for collision
		hit = Physics2D.Linecast (start, end);

		// Re-enable boxCollider after Linecast
		boxCollider.enabled = true;

		// If nothing was hit, move
		if (hit.transform == null) {
			StartCoroutine (SmoothMovement (end));
			return true;
		}

		// Otherwise, return false; Move unsuccessful
		return false;
	}

	// Co-routine for moving units around
	protected IEnumerator SmoothMovement (Vector3 end) {
		// Calculate remaining distance to move based on square magnitude
		// We use square magnitude because it's cheaper
		float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

		// Epsilon is very small
		while (sqrRemainingDistance > float.Epsilon) {
			// Find a new position proportionately closer to the end, based on moveTime
			Vector3 newPosition = Vector3.MoveTowards (rb2D.position, end, inverseMoveTime * Time.deltaTime);

			// Move rigidbody
			rb2D.MovePosition (newPosition);

			// Calculate new sqrRemainingDistance
			sqrRemainingDistance = (transform.position - end).sqrMagnitude;

			yield return null;
		}
	}


	protected virtual void AttemptMove<T> (int xDir, int yDir)
		where T : Component {

		RaycastHit2D hit;
		bool canMove = Move (xDir, yDir, out hit);

		if (hit.transform == null) {
			return;
		}

		T hitComponent = hit.transform.GetComponent<T>();

		if (!canMove && hitComponent != null) {
			OnCantMove (hitComponent);
		}

	}

	protected abstract void OnCantMove<T> (T component)
		where T : Component;
}
