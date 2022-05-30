using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public Color visionColor;
    public Color aggroColor;
    float visionDistance = 2.9f;
    Transform vision;
    LayerMask mask;
    int playerLayer;

    // Start is called before the first frame update
    
    public void ResetVisionColor() {
        vision.GetComponent<SpriteRenderer>().color = visionColor;
    }

    void Awake()
    {
        mask = LayerMask.GetMask("Terrain", "Player");
        playerLayer = LayerMask.NameToLayer("Player");
        vision = transform.GetChild(0);
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, visionDistance, mask);
        if(hit)
        {
            if(hit.transform.gameObject.layer == playerLayer) // Hit Player
            {
                vision.GetComponent<SpriteRenderer>().color = aggroColor;
                GameManager.reference.Respawn();
            }
            else // Hit terrain
            {
                vision.localScale = new Vector3(1, hit.distance * 1.2f, 1);
                vision.localPosition = new Vector3(0, vision.localScale.y / 2f, 0);
            }
        }
        else // Hit nothing
        {
            vision.localScale = new Vector3(1, 3.5f, 1);
            vision.localPosition = new Vector3(0, 1.75f, 0);
        }
    }
}
