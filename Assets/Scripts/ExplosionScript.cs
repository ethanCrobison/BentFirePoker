using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 0.65F);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
