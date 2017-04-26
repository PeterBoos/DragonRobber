using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardController : MonoBehaviour {

	public GameObject roomTile;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadTiles(int width, int height){
		var y = 0;		
		for (var x = 0; x < width; x++){
			for (var z = 0; z < height; z++){
				GameObject tile = Instantiate(roomTile, new Vector3(x, y, z), Quaternion.Euler(0, 180, 0)) as GameObject;
				tile.transform.parent = transform;
				tile.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
			}
		}
	}
}
