using UnityEngine;
using System.Collections;
using System;

public class MineScript : MonoBehaviour {

	// use an enum to represent the mine's state
	private enum STATE {
		IDLE,
		PRIMED,
		DEAD
	}
	private STATE s;
	private DateTime primeTime;

	// Use this for initialization
	void Start () {
		s = STATE.IDLE;
	}
	
	// Update is called once per frame
	void Update () {
		
		TimeSpan ts = DateTime.Now - primeTime;
		if (ts.Seconds > 1 && s == STATE.PRIMED) {
			Debug.Log ("bang");
			s = STATE.DEAD;
		}
	
	}

	void OnTriggerEnter2D (Collider2D c) {
		if (s == STATE.DEAD)
			return;
		
		this.GetComponent<SpriteRenderer> ().color = Color.red;

		if (s == STATE.IDLE) {
			primeTime = DateTime.Now;
		}
		s = STATE.PRIMED;
	}

	void OnTriggerStay2D (Collider2D c) {
		Debug.Log ("stay");
	}

	void OnTriggerExit2D (Collider2D c) {
		if (s == STATE.DEAD)
			return;
		
		this.GetComponent<SpriteRenderer> ().color = Color.green;

		s = STATE.IDLE;
	}
}
