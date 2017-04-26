using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public int gameBoardWidth;
	public int gameBoardHeight;
	public GameBoardController gameBoard;
	public List<RoomTile> rooms;
	public RoomTile RoomTileAtPlayerPosition;
	public GameObject Player;

	// Use this for initialization
	void Start () {
		LoadGameBoard();
		foreach (var room in gameBoard.GetComponentsInChildren<RoomTile>()){
			rooms.Add(room);
		}
		Player = GameObject.FindGameObjectWithTag("Player");
		SetRoomTileAtPlayerPosition(Player.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		//CheckIfMouseOverRoomTile();
	}

	private void LoadGameBoard(){
		gameBoard.LoadTiles(gameBoardWidth, gameBoardHeight);
	}

	// private void CheckIfMouseOverRoomTile()
	// {
	// 	Ray ray;
	// 	RaycastHit hit;

	// 	ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	// 	if (Physics.Raycast(ray, out hit))
	// 	{
	// 		print (hit.collider.name);
	// 	}
	// }

	// Call this when ever the player moves to set the current
	// active room. (Also once at game start)
	public void SetRoomTileAtPlayerPosition(Vector3 playerPosition)
	{
		if (RoomTileAtPlayerPosition != null) RoomTileAtPlayerPosition.SetPlayerPresent(false);

		var x = (int)playerPosition.x;
		var y = (int)playerPosition.y;
		var z = (int)playerPosition.z;
		var playerPositionNormal = new Vector3(x, y, z);

		var roomTiles = gameBoard.GetComponentsInChildren<RoomTile>();
		RoomTileAtPlayerPosition = (RoomTile)roomTiles.SingleOrDefault(item => item.transform.position == playerPositionNormal);
		RoomTileAtPlayerPosition.SetPlayerPresent(true);

		print("Player at roomTile.position: " + roomTiles.SingleOrDefault(item => item.transform.position == playerPositionNormal).transform.position);
	}
}
