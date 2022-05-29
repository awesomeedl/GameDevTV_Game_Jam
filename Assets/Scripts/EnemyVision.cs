using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider2D) {
        GameManager.instance.Respawn();
    }
}
