using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public GameObject player;

	private GameObject[] walls;
	private Vector3 NORTH = new Vector3(0, 0, -0.5f);
	private Vector3 SOUTH = new Vector3(0, 0, 0.5f);
	private Vector3 EAST = new Vector3(-0.5f, 0, 0);
	private Vector3 WEST = new Vector3(0.5f, 0, 0);

	private enum DIR {NORTH, SOUTH, EAST, WEST};

	// Use this for initialization
	void Start () {
		walls = GameObject.FindGameObjectsWithTag("Wall");
		move(NORTH);
		move(NORTH);
		move(EAST);
		move(EAST);
		Debug.Log(isNearWall(DIR.NORTH));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	bool isNearWall(DIR dir) { 
		foreach(GameObject wall in walls) {
			float zDiff = player.transform.position.z - (wall.transform.position.z);
			float xDiff = player.transform.position.x - (wall.transform.position.x);
			switch(dir) {
				case DIR.NORTH:
				Debug.Log(zDiff);
				//TODO normalize distances somehow
				if (zDiff > 0 && zDiff <= 0.6) {
					return true;
				}
				break;
				case DIR.SOUTH:
				if(zDiff < 0 && zDiff <= -0.6) {
					return true;
				}
				break;
				case DIR.EAST:
				if(xDiff > 0 && xDiff <= 0.5) {
					return true;
				}
				break;
				case DIR.WEST:
				if(xDiff < 0 && xDiff <= -0.5) {
					return true;
				}
				break;
			}
		}
		return false;
	}

	bool isNearAnyWall(float range) {
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(player.transform.position, range);
		foreach(Collider2D collider in hitColliders) {
			if(collider.tag.Equals("Wall")) {
				return true;
			}
		}
		return false;
	}

	void move(Vector3 direction) {
		moveAny(direction.x, direction.y, direction.z);
	}

	void moveAny(float x, float y, float z) {
		player.transform.Translate(x, y, z);
	}
}
