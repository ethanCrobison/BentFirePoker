using UnityEngine;
using System.Collections;

public class DroneScript : MonoBehaviour {
	public float speed = 2.0F;
	public float thresh = 5.0F;
	public GameObject thePlayer;

	void Update () {
		if (Vector3.Distance (thePlayer.transform.position, this.transform.position) > thresh) {
			Debug.Log ("Away");
		}
	}
}
