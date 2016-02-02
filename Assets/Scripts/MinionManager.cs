using UnityEngine;
using System.Collections;

public class MinionManager : MonoBehaviour {

	public GameObject Prefab;

	private float minX = -4;
	private float maxX =  4;
	private float minY = -4;
	private float maxY =  4;

	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		PlayerScript ps = player.GetComponent<PlayerScript> ();
		ps.SpawnMinion += SpawnNewMinion;
	}

	private void SpawnNewMinion() {
		GameObject minion = GameObject.Instantiate (Prefab);
		var x = this.transform.position.x + Random.Range (minX, maxX);
		var y = this.transform.position.y + Random.Range (minY, maxY);
		minion.transform.position = new Vector2 (x, y);
	}

}
