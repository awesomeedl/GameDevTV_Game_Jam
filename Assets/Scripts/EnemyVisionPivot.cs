using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisionPivot : MonoBehaviour
{
    float distance = 2.9f;
    Transform vision;
    LayerMask layerMask; 
    // Start is called before the first frame update
    
    void Awake()
    {
        layerMask = LayerMask.GetMask("Terrain");
        vision = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distance, layerMask);
        if(hit)
        {
            vision.localScale = new Vector3(1, hit.distance * 1.2f, 1);
            vision.localPosition = new Vector3(0, vision.localScale.y / 2f, 0);
        }
        else
        {
            vision.localScale = new Vector3(1, 3.5f, 1);
            vision.localPosition = new Vector3(0, 1.75f, 0);
        }
    }

    void OnDrawGizmos() {
        Debug.DrawLine(transform.position, transform.position + transform.up * distance, Color.red);
    }
}
