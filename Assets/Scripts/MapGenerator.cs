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
		PlaceWalls ();
		// TODO treasure placement
		PlaceTreasures ();
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
//		RandomFillMap();

//		for (int i = 0; i < 2; i ++) {
//			SmoothMap();
//		}
	}


	void RandomFillMap() {
		if (useRandomSeed) {
			seed = Time.time.ToString ();
		}

		System.Random pseudoRandom = new System.Random(seed.GetHashCode());

		for (int x = 0; x < width; x ++) {
			for (int y = 0; y < height; y ++) {
				if (x == 0 || x == width-1 || y == 0 || y == height -1) {
					map[x,y] = 1;
				}
				else {
					map[x,y] = (pseudoRandom.Next(0,100) < randomFillPercent)? 1: 0;
				}
			}
		}
	}

	void SmoothMap() {
		for (int x = 1; x < width - 1; x ++) {
			for (int y = 1; y < height - 1; y ++) {
				int neighbourWallTiles = GetSurroundingWallCount(x,y);

				if (neighbourWallTiles > 4)
					map[x,y] = 1;
				else if (neighbourWallTiles < 4)
					map[x,y] = 0;

			}
		}
	}

	int GetSurroundingWallCount(int gridX, int gridY) {
		int wallCount = 0;
		for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX ++) {
			for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY ++) {
				if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height) {
					if (neighbourX != gridX || neighbourY != gridY) {
						wallCount += map[neighbourX,neighbourY];
					}
				}
				else {
					wallCount ++;
				}
			}
		}

		return wallCount;
	}

	private void PlaceWalls () {
		// TODO use the "pill" method to instantiate fewer prefabs
		if (map != null) {
			for (int x = 0; x < width; x ++) {
				for (int y = 0; y < height; y ++) {
					if (map [x, y] == 1) {
						PlaceWall (x, y);
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
		trans.position = (new Vector3 (0.5F + x, 0.5F + y, 0));
		_WallsInUse.Enqueue (wall);
	}

	private void PlaceTreasures() {
		
	}
}

