using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour {

	public float horizontalSpeed = 2.0F;
	public float verticalSpeed = 2.0F;

	public event Action SpawnMinion = delegate {};

	void Update () {
		float h = horizontalSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
		float v = verticalSpeed * Time.deltaTime * Input.GetAxis("Vertical");
		transform.Translate (h, v, 0);

		if (Input.GetButtonDown ("Spawn")) {
			SpawnMinion.Invoke ();
		}
	}


}
