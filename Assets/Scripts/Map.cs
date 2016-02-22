using UnityEngine;
using System.Collections.Generic;

public class Map {
	private static int MINROOMSIZE = 10;
	private static int MAXROOMSIZE = 15;
	private static int MAXROOMCOUNT = 40;

	private int width, height;
	public int[,] tiles { get; private set;}
	private Queue<Room> rooms = new Queue<Room> ();

	private int lastX, lastY;
	private System.Random pseudorandom = new System.Random (0);


	public Map(int width, int height){
		this.width = width;
		this.height = height;

		tiles = new int[width, height];
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				tiles [x, y] = 1;
			}
		}
		RandomFill();
		PathFind (5, 5, 6, 6);
	}
	private void CreateRoom(Room room) {
		for (int x = room.x1; x < room.x2 - 1; x++) {
			for (int y = room.y1; y < room.y2 - 1; y++) {
				tiles [x, y] = 0;
			}
		}
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
		if (rooms.Count > 0) {
			AddTunnel (newRoom);
		}
		lastX = newRoom.GetCenterX ();
		lastY = newRoom.GetCenterY ();
		rooms.Enqueue (newRoom);
	}

	private void AddTunnel(Room newRoom) {
		var newX = newRoom.GetCenterX ();
		var newY = newRoom.GetCenterY ();
		if (pseudorandom.Next(0, 1) == 1) {
			// horizontal, then vertical
			CreateHorizontalTunnel(lastX, newX, lastY);
			CreateVerticalTunnel (lastY, newY, newX);
		} else {
			CreateVerticalTunnel (lastY, newY, lastX);
			CreateHorizontalTunnel(lastX, newX, newY);
		}
	}

	private void CreateHorizontalTunnel(int x1, int x2, int y){
		for (int x = x1; x < x2; x++) {
			tiles [x, y] = 0;
		}
	}

	private void CreateVerticalTunnel(int y1, int y2, int x){
		for (int y = y1; y < y2; y++) {
			tiles [x, y] = 0;
		}
	}

	public void PathFind(int x1, int y1, int x2, int y2) {
		int[,] visited = (int[,]) tiles.Clone ();
		int curX, curY;
		int top;
		if (visited [x1, y1] != 0) {
//			return null;
		} else {
			top = 2;
			while (true) {
				break;
			}
		}
	}

	public int GetPlayerX(){
		return rooms.Peek ().GetCenterX ();
	}

	public int GetPlayerY(){
		return rooms.Peek ().GetCenterY ();
	}
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
