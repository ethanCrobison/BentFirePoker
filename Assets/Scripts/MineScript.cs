using UnityEngine;
using System.Collections;

public class MineScript : MonoBehaviour {

	public Animation explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D c) {
		Debug.Log ("wow");
		this.GetComponent<SpriteRenderer> ().color = Color.red;
	}

	void OnTriggerStay2D (Collider2D c) {
		Debug.Log ("wow");
	}

	void OnTriggerExit2D (Collider2D c) {
		Debug.Log ("wow");
		this.GetComponent<SpriteRenderer> ().color = Color.green;
	}
}
