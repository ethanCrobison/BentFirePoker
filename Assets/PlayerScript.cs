using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float horizontalSpeed = 2.0F;
	public float verticalSpeed = 2.0F;

	void Update () {
		float h = horizontalSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
		float v = verticalSpeed * Time.deltaTime * Input.GetAxis("Vertical");
		transform.Translate (h, v, 0);
		//Debug.Log (transform.position);
	}
}
