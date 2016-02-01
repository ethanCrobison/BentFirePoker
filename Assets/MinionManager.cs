using UnityEngine;
using System.Collections;

public class MinionManager : MonoBehaviour {

	public GameObject Prefab;

	private float minX = -4;
	private float maxX =  4;
	private float minY = -4;
	private float maxY =  4;

	void Update () {
		if (Input.GetButtonDown("Spawn")) {
			Debug.Log("Spawning minion.");
			SpawnNewMinion ();
		}
	}

	private void SpawnNewMinion() {
		GameObject minion = GameObject.Instantiate (Prefab);
		minion.transform.localPosition = new Vector2 (
			Random.Range (minX, maxX),
			Random.Range (minY, maxY));

		minion.transform.parent = this.transform;
	}

}
