using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    float terrainDistance = 2.9f;
    float playerDistance = 2.6f;
    Transform vision;
    LayerMask terrainMask; 
    LayerMask playerMask;

    bool isPlayerHit;
    // Start is called before the first frame update
    
    void Awake()
    {
        terrainMask = LayerMask.GetMask("Terrain");
        playerMask = LayerMask.GetMask("Player");
        vision = transform.GetChild(0);
    }

    void Update()
    {
        if(isPlayerHit) {
            GameManager.reference.Respawn();
            isPlayerHit = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D terrainHit = Physics2D.Raycast(transform.position, transform.up, terrainDistance, terrainMask);
        if(terrainHit)
        {
            vision.localScale = new Vector3(1, terrainHit.distance * 1.2f, 1);
            vision.localPosition = new Vector3(0, vision.localScale.y / 2f, 0);
        }
        else
        {
            vision.localScale = new Vector3(1, 3.5f, 1);
            vision.localPosition = new Vector3(0, 1.75f, 0);
        }

        RaycastHit2D playerHit = Physics2D.Raycast(transform.position, transform.up, playerDistance, playerMask);
        if(playerHit) {
            isPlayerHit = true;
        }
        else
        {
            isPlayerHit = false;
        }
    }
}
