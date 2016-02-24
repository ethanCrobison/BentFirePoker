using UnityEngine;
using System.Collections.Generic;
using System;

public class MapGenerator : MonoBehaviour {

	public int width;
	public int height;

	public string seed;
	public bool useRandomSeed = true;

	public GameObject WallPrefab;
	public GameObject TreasurePrefab;

	private Queue<GameObject> _WallsInUse = new Queue<GameObject>();
	private Queue<GameObject> _WallsAvailable = new Queue<GameObject>();

	[Range(0,100)] public int randomFillPercent;

	int[,] map;

	void Start() {
		GenerateMap();
		PlaceTiles ();
	}

	void GenerateMap() {
		GameObject wall;
		while (_WallsInUse.Count > 0) {
			wall = _WallsInUse.Dequeue ();
			wall.SetActive (false);
			_WallsAvailable.Enqueue (wall);
		}

		var template = new Map(width, height);
		map = template.tiles;
		var player = GameObject.FindGameObjectWithTag ("Player");
		player.transform.position = new Vector3(template.GetPlayerX(), template.GetPlayerY(), 0F);
	}

	private void PlaceTiles () {
		if (map != null) {
			for (int x = 0; x < width; x ++) {
				for (int y = 0; y < height; y ++) {
					switch (map[x, y]) {
					case Map.Wall:
						PlaceWall (x, y);
						break;
					case Map.Treasure:
						PlaceTreasure (x, y);
						break;
//					default:
						
					}
				}
			}
		}
	}

	private void PlaceWall(int x, int y) {
		GameObject wall;
		if (_WallsAvailable.Count > 0) {
			wall = _WallsAvailable.Dequeue ();
			wall.SetActive (true);
		} else {
			wall = GameObject.Instantiate (WallPrefab);
			wall.transform.SetParent (this.transform);
		}
		var trans = wall.transform;
		trans.position = new Vector3 (0.5F + x, 0.5F + y, 0F);
		_WallsInUse.Enqueue (wall);
	}

	private void PlaceTreasure(int x, int y) {
		GameObject treasure = GameObject.Instantiate (TreasurePrefab);
		var trans = treasure.transform;
		trans.position = new Vector3 (0.5F + x, 0.5F + y, 0F);
	}
}

