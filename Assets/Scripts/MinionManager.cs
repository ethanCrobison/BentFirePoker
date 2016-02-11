using UnityEngine;
using System;

public class MinionManager : MonoBehaviour {

	public GameObject MinionPrefab;
	public GameObject WardPrefab;

	private float minX = -4;
	private float maxX =  4;
	private float minY = -4;
	private float maxY =  4;

	void Start () {
		PlayerScript ps = this.GetComponent<PlayerScript>();
		ps.SpawnMinion += SpawnNewMinion;
		ps.SpawnWard += SpawnNewWard;
	}

	private void SpawnNewMinion() {
		GameObject minion = GameObject.Instantiate (MinionPrefab);
		minion.transform.position = NewSpawnPoint ();
	}

	private void SpawnNewWard () {
		GameObject minion = GameObject.Instantiate (WardPrefab);
		minion.transform.position = NewSpawnPoint ();
	}
	private Vector2 NewSpawnPoint () {
		var x = this.transform.position.x + UnityEngine.Random.Range (minX, maxX);
		var y = this.transform.position.y + UnityEngine.Random.Range (minY, maxY);
		return new Vector2 (x, y);
	}		
}
