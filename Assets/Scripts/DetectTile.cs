using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DetectTiles : MonoBehaviour
{
	PlayerController playerScript;
	public float minDistance;
	public float scanFrequency;
	
	GameObject[] allTiles;
	
	void Start()
	{
		playerScript = GetComponent<PlayerController>();
		InvokeRepeating("ScanSurround", 0, scanFrequency);
		allTiles = GameObject.FindGameObjectsWithTag("Tile");
	}       
	
	void ScanSurround()
	{

		switch (playerScript.CurrentMode)
		{
		case PlayerController.GameMode.CONSTRUCT:
			
			foreach (GameObject tileInstance in allTiles)
			{
				Vector3 difference = (tileInstance.transform.position - transform.position);
				float distance = difference.sqrMagnitude;
				
				if (distance <= minDistance)
				{
					tileInstance.GetComponent<SpriteRenderer>().color = Color.gray;
				}
				else
				{
					tileInstance.GetComponent<SpriteRenderer>().color = Color.white;
				}
			}
			break;
		case PlayerController.GameMode.COMBAT:
			
			foreach (GameObject tileInstance in allTiles)
			{
				tileInstance.GetComponent<SpriteRenderer>().color = Color.white;
			}
			break;
			
		default: break;
		}
	}
}