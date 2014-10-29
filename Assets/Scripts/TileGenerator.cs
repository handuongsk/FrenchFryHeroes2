using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileGenerator : MonoBehaviour {

	static int gameWidth = 20;
	static int gameHeight = 15;
	public Object[] tileType;

	void Start()
	{
		GenerateMap ();
	}


	void GenerateMap()
	{
		for (int x = 0; x < gameWidth; x++)
		{
			for (int y = 0; y < gameHeight; y++)
			{
				int tileVal = Random.Range (0,tileType.Length); //random generate a tile from 0-Length-1 inclusive
				Instantiate(tileType[tileVal], new Vector3(x - gameWidth/2, y - gameHeight/2, 0), Quaternion.identity);
			}
		}
	}
}