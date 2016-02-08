using UnityEngine;
using System.Collections;

public class MinionManager : MonoBehaviour {

	public GameObject MinionPrefab;
	public GameObject WardPrefab;

	private float minX = -4;
	private float maxX =  4;
	private float minY = -4;
	private float maxY =  4;

	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		PlayerScript ps = player.GetComponent<PlayerScript> ();
		ps.SpawnMinion += SpawnNewMinion;
		ps.SpawnWard += SpawnNewWard;
	}

	private void SpawnNewMinion() {
		
		GameObject minion = GameObject.Instantiate (MinionPrefab);
		var x = this.transform.position.x + Random.Range (minX, maxX);
		var y = this.transform.position.y + Random.Range (minY, maxY);
		minion.transform.position = new Vector2 (x, y);
	}

	private void SpawnNewWard () {
		GameObject minion = GameObject.Instantiate (WardPrefab);
		var x = this.transform.position.x + Random.Range (minX, maxX);
		var y = this.transform.position.y + Random.Range (minY, maxY);
		minion.transform.position = new Vector2 (x, y);
	}
}
