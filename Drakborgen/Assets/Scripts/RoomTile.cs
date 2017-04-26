using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomTile : MonoBehaviour {

	public GameObject model;
	public bool hidden = true;
	public Shader shader_default;
	public Shader shader_outlined;
	public Renderer renderer;
	public Vector3 position;
	public bool playerPresent = false;

	// Path properties
	public int pathUp;
	public int pathRight;
	public int pathDown;
	public int pathLeft;

	// Use this for initialization
	void Start () {
		position = this.transform.position;

		renderer = this.GetComponent<Renderer>();		
		shader_default = Shader.Find("Diffuse");
        shader_outlined = Shader.Find("Outlined/Silhouetted Bumped Diffuse");

		LoadPaths();

		//CheckPathsToNeighbours();
	}
	
	// Update is called once per frame
	void Update () {
		// if (playerPresent)
		// {			
		// }
	}

	private void LoadPaths(){
		pathUp = 1;
		pathRight = 1;
		pathDown = 1;
		pathLeft = 0;
	}

	void OnMouseOver()
	{
		renderer.material.shader = shader_outlined;
	}

	void OnMouseExit()
	{
		renderer.material.shader = shader_default;
	}

	void OnMouseDown()
	{
		CheckPathsToNeighbours();
	}

	void CheckPathsToNeighbours()
	{
		var roomTiles = GameObject.FindGameObjectsWithTag("RoomTile");

		var up_position = new Vector3(position.x, position.y, position.z + 1);
		var right_position = new Vector3(position.x + 1, position.y, position.z);
		var down_position = new Vector3(position.x, position.y, position.z - 1);
		var left_position = new Vector3(position.x - 1, position.y, position.z);

		if (pathUp == 1)
		{
			var neighbour_up = roomTiles.SingleOrDefault(item => item.transform.position == up_position);
			var neighbour_upRenderer = neighbour_up.GetComponent<Renderer>();
			neighbour_upRenderer.material.shader = shader_outlined;
		}
		if (pathRight == 1)
		{
			var neighbour_right = roomTiles.SingleOrDefault(item => item.transform.position == right_position);
			var neighbour_rightRenderer = neighbour_right.GetComponent<Renderer>();
			neighbour_rightRenderer.material.shader = shader_outlined;
		}
		if (pathDown == 1)
		{
			var neighbour_down = roomTiles.SingleOrDefault(item => item.transform.position == down_position);
			var neighbour_downRenderer = neighbour_down.GetComponent<Renderer>();
			neighbour_downRenderer.material.shader = shader_outlined;
		}
		if (pathLeft == 1)
		{
			var neighbour_left = roomTiles.SingleOrDefault(item => item.transform.position == left_position);
			var neighbour_leftRenderer = neighbour_left.GetComponent<Renderer>();
			neighbour_leftRenderer.material.shader = shader_outlined;
		}
	}

	public void SetPlayerPresent(bool value)
	{
		if (value == true){
			playerPresent = true;
			renderer.material.shader = shader_outlined;
			renderer.material.SetColor("_OutlineColor", Color.yellow);
			CheckPathsToNeighbours();
		}
		if (value == false){
			playerPresent = false;
			renderer.material.shader = shader_default;
		}
	}
}
