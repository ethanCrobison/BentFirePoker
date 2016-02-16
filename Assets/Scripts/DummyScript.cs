using UnityEngine;
using System.Collections;

public class DummyScript : MonoBehaviour {

	public int hp;

	// Use this for initialization
	void Start () {
		hp = 500;
	}
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0) {
			Destroy (gameObject);
		}
	}
}
