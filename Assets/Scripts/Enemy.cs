using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
            detected = false;
        }
        else {
            spriteRenderer.color = cachedColor;
        }
    }
}
