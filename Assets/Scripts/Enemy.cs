using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject vision;
    public float visionRadius = 2.5f;
    SpriteRenderer spriteRenderer;
    bool detected = false;
    Color cachedColor;
    
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cachedColor = spriteRenderer.color;
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(detected == true) {
            spriteRenderer.color = Color.red;
        }
        else {
            spriteRenderer.color = cachedColor;
        }
    }

    void FixedUpdate() {
        VisonCheck();
    }

    void VisonCheck() {
        vision.transform.localScale = new Vector2(visionRadius * 2, visionRadius * 2);
        Collider2D player = Physics2D.OverlapCircle(transform.position, visionRadius);
        if(player != null)
        {
            Vector2 v = player.transform.position - transform.position;
            if(Vector2.Angle(transform.up, v) < 60f) {
                detected = true;
            }
            else
            {
                detected = false;
            }
        }
        else
        {
            detected = false;
        }
    }

    
}
