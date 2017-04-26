using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public enum Direction	{Up =0,	Right = 1, Down = 2, Left = 3}

	public GameObject player;

	// Use this for initialization
	void Start () {
		SetPlayerRoom();
	}
	
	// Update is called once per frame
	void Update () {
		

		// test/debug
		if (Input.GetKeyDown(KeyCode.W)) Move(Direction.Up);
		if (Input.GetKeyDown(KeyCode.D)) Move(Direction.Right);
		if (Input.GetKeyDown(KeyCode.S)) Move(Direction.Down);
		if (Input.GetKeyDown(KeyCode.A)) Move(Direction.Left);
	}

	public void Move(Direction direction)
	{
		switch (direction)
		{
			case Direction.Up:
				transform.position += new Vector3(0, 0, 1);
			break;
			case Direction.Right:
				transform.position += new Vector3(1, 0, 0);
			break;
			case Direction.Down:
				transform.position += new Vector3(0, 0, -1);
			break;
			case Direction.Left:
				transform.position += new Vector3(-1, 0, 0);
			break;
		}	

		SetPlayerRoom();	
	}

	// Updates the active room in GameManager
	void SetPlayerRoom()
	{
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().SetRoomTileAtPlayerPosition(transform.position);
	}
}
