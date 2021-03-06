﻿using UnityEngine;
using System.Collections.Generic;

public class Map {
	private static int MINROOMSIZE = 8;
	private static int MAXROOMSIZE = 12;
	private static int MAXROOMCOUNT = 40;

	public const int Wall = 1;
	public const int Treasure = 2;
	public const int Enemy = 3;
	public const int Zombie = 4;
	public const int Exit = 5;

	private int width, height;
	public int[,] tiles { get; private set;}
	private Queue<Room> rooms = new Queue<Room> ();

	private int lastX, lastY;
	private System.Random pseudorandom = new System.Random (System.DateTime.Now.GetHashCode());

	private int ExitInd;

	public Map(int width, int height){
		this.width = width;
		this.height = height;

		tiles = new int[width, height];
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				tiles [x, y] = Wall;
			}
		}
		this.ExitInd = pseudorandom.Next (2, 7);
		RandomFill();
		PlaceEmpties ();
	}

	private void RandomFill() {
		for (int i = 0; i < MAXROOMCOUNT; i++) {
			var x = pseudorandom.Next (1, width);
			var y = pseudorandom.Next (1, height);

			var w = pseudorandom.Next (MINROOMSIZE, MAXROOMSIZE);
			if ((x + w) > width) {
				w = width - x;
			}

			var h = pseudorandom.Next (MINROOMSIZE, MAXROOMSIZE);
			if ((y + h) > height) {
				h = height - y;
			}
				
			var newRoom = new Room (x, y, w, h);
			if (RoomValidP (newRoom)) {
				AddRoom (newRoom);
			}
		}
	}
		
	private bool RoomValidP(Room newRoom){
		bool valid = true;
		if (((newRoom.x2 - newRoom.x1) < MINROOMSIZE) || ((newRoom.y2 - newRoom.y1) < MINROOMSIZE)) {
			valid = false;
		} else {
			foreach (Room goodRoom in rooms) {
				if (newRoom.intersect (goodRoom)) {
					valid = false;
				}
			}
		}
		return valid;
	}

	private void AddRoom(Room newRoom) {
		CreateRoom (newRoom);
		var roomCount = rooms.Count;
		if (roomCount > 0) {
			AddTunnel (newRoom);
		}
		lastX = newRoom.GetCenterX ();
		lastY = newRoom.GetCenterY ();
		if (roomCount > 0) {
			tiles [lastX - 1, lastY] = Map.Treasure;

			bool coin = Random.Range (0.0F, 1.0F) > 0.75F;
			if (coin) {
				tiles [lastX + 1, lastY] = Map.Enemy;
			} else {
				tiles [lastX + 1, lastY] = Map.Zombie;
			}
			if (this.ExitInd == 0) {
				tiles [lastX + 2, lastY + 2] = Map.Exit;
				this.ExitInd--;
			} else {
				this.ExitInd--;
			}
		}
		rooms.Enqueue (newRoom);
	}

	private void CreateRoom(Room room) {
		for (int x = room.x1; x < room.x2 - 1; x++) {
			for (int y = room.y1; y < room.y2 - 1; y++) {
				tiles [x, y] = 0;
			}
		}
	}

	private void AddTunnel(Room newRoom) {
		var newX = newRoom.GetCenterX ();
		var newY = newRoom.GetCenterY ();
		if (pseudorandom.Next(0, 1) == 1) {
			// horizontal, then vertical
			CreateHorizontalTunnel(lastX, newX, lastY);
			CreateVerticalTunnel (lastY, newY, newX);
		} else {
			CreateHorizontalTunnel(lastX, newX, newY);
			CreateVerticalTunnel (lastY, newY, lastX);
		}
	}

	private void CreateHorizontalTunnel(int x1, int x2, int y){
		int start = Mathf.Min (x1, x2);
		int end = Mathf.Max (x1, x2);
		for (int x = start; x < end; x++) {
			tiles [x, y] = 0;
		}
	}

	private void CreateVerticalTunnel(int y1, int y2, int x){
		int start = Mathf.Min (y1, y2);
		int end = Mathf.Max (y1, y2);
		for (int y = start; y < end; y++) {
			tiles [x, y] = 0;
		}
	}

	private void PlaceEmpties() {
		for (int x = 1; x < width - 1; x++) {
			for (int y = 1; y < height - 1; y++) {
				if (NeighborCount (x, y) > 7) {
					tiles [x, y] = -1;
				}
			}
		}
	}

	private int NeighborCount(int gridx, int gridy) {		
		int count = 0;
		for (int x = gridx - 1; x <= gridx + 1; x++) {
			for (int y = gridy - 1; y <= gridy + 1; y++) {
				if (x != gridx || y != gridy) {
					if (tiles [x, y] == 1 || tiles [x, y] == -1 ) {
						count++;
					}
				}
			}
		}
		return count;
	}

	public int GetPlayerX(){ return rooms.Peek ().GetCenterX (); }
	public int GetPlayerY(){ return rooms.Peek ().GetCenterY (); }
}


public class Room {
	public int x1, y1, x2, y2;

	public Room(int x, int y, int w, int h) {
		x1 = x;
		y1 = y;
		x2 = x + w;
		y2 = y + h;
	}

	public int GetCenterX(){
		return (x1 + x2) / 2;
	}
	public int GetCenterY() {
		return (y1 + y2) / 2;
	}

	public bool intersect(Room other){
		// ... this is probably the best way
		return (((this.x1 <= other.x1 && this.x2 >= other.x1) ||
		(other.x1 <= this.x1 && other.x2 >= this.x1))
		&&
		((this.y1 <= other.y1 && this.y2 >= other.y1) ||
		(other.y1 <= this.y1 && other.y2 >= this.y1)));
	}

}
