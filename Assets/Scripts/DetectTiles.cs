using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DetectTiles : MonoBehaviour
{
    PlayerController playerController;
    public float minDistance;
    public float scanFrequency;

    GameObject[] allTiles;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        InvokeRepeating("ScanSurround", 0, scanFrequency);
        allTiles = GameObject.FindGameObjectsWithTag("Tile");
    }

    void ScanSurround()
    {

        switch (playerController.CurrentMode)
        {
            case PlayerController.GameMode.CONSTRUCT:

                foreach (GameObject tileInstance in allTiles)
                {
                    var tilePos = tileInstance.transform.position;
                    var playerPos = new Vector3((int)(transform.position.x),
                                                 (int)(transform.position.y),
                                                 transform.position.z);


                    Vector3 difference = (tilePos - playerPos);
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