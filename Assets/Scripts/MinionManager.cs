using UnityEngine;
using System.Collections.Generic;
using System;

public class MinionManager : MonoBehaviour {

	public GameObject MinionPrefab;
	public GameObject WardPrefab;

	public event Action NewMinion = delegate {};

	private float minX = -4;
	private float maxX =  4;
	private float minY = -4;
	private float maxY =  4;

	private int minionCount;
	private int maxMinions = 5;

//	private Queue<GameObject> _Minions = new Queue<GameObject>();

	void Start () {
		minionCount = 0;
		var player = GameObject.FindGameObjectWithTag("Player");
		var ps = player.GetComponent<PlayerScript> ();
		ps.SpawnMinion += SpawnNewMinion;
		SpawnNewMinion ();
	}

	private void SpawnNewMinion() {
		if (minionCount < maxMinions) {
			NewMinion.Invoke ();

			GameObject minion = GameObject.Instantiate (MinionPrefab);
			minion.transform.position = NewSpawnPoint ();
			minionCount++;
		}
	}
	private Vector2 NewSpawnPoint () {
		var x = this.transform.position.x + UnityEngine.Random.Range (minX, maxX);
		var y = this.transform.position.y + UnityEngine.Random.Range (minY, maxY);
		return new Vector2 (x, y);
	}		
}
