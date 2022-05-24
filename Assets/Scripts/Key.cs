using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    void OnTriggerEnter2D() {
        GetComponent<SpriteRenderer>().color = Color.gray;
        GetComponent<Quest>().Complete();
    }
}
