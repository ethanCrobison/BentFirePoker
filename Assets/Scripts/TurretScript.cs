using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {

	private static float RotationSpeed = 2 * Mathf.PI;

	private GameObject playerObject;
	private GameObject body;
	private GameObject barrel;

	private RaycastHit2D sight;
	private RaycastHit2D hit;

	private LineRenderer lr;

	void Start () {
		// store a reference to the player object
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		body = GameObject.Find ("Body").gameObject;
		barrel = GameObject.Find ("Turret").gameObject;
		
		lr = this.gameObject.AddComponent<LineRenderer> ();
		lr.material = new Material (Shader.Find ("Particles/Additive"));
		lr.SetColors (Color.red, Color.red);
		lr.SetWidth (0.1F, 0.1F);
		lr.SetVertexCount (2);
		lr.SetPosition (0, body.transform.position);

	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	void FixedUpdate() {
		// LoS from turret to player
		sight = Physics2D.Raycast (body.transform.position, playerObject.transform.position - body.transform.position);

		// LoS from turret to barrel
		hit = Physics2D.Raycast (body.transform.position, barrel.transform.position - body.transform.position);
		Debug.Log (hit.ToString());

		lr.SetPosition (1, hit.collider.transform.position);

		if (sight.collider != null) {
			if (sight.collider.gameObject.tag == "Player") {
//				// the position of the gun body
//				Vector2 bodyPos = transform.GetChild (0).position;
//				// the position of the barrel body
//				Vector2 barrelPos = transform.GetChild (0).transform.GetChild (0).position;
//				// the vector from the body to the player
//				Vector2 bodyToPlayer = (Vector2) playerObject.transform.position - bodyPos;
//				// the vector from the gun body to the barrel body
//				Vector2 bodyToBarrel = barrelPos - bodyPos;

//				Vector3 _direction = (playerObject.transform.position - transform.position).normalized;
//				Quaternion _lookRotation = Quaternion.LookRotation (_direction);
//				transform.rotation = Quaternion.Slerp (transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);


//				if (hit.collider != null

			}
		}
	}

	bool CanSeePlayer () {
		return false;
	}
}
