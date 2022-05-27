using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    List<EnemyMovement> enemies = new List<EnemyMovement>();
    public List<Transform> spawnPoints;
    GameObject player;
    int spawnPointIndex;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        spawnPointIndex = 0;
    }

    void Start() {
        player = FindObjectOfType<Player>().gameObject;
    }

    public void AddEnemy(EnemyMovement enemy) {
       enemies.Add(enemy); 
    }

    public void ChaneEnemyPattern(int index) {
        foreach(var enemy in enemies) {
            enemy.ChangePathSet(index);
        }
    }

    public void Respawn() {
        spawnPointIndex = spawnPointIndex < spawnPoints.Count - 1 ? spawnPointIndex + 1 : 0;
        player.transform.position = spawnPoints[spawnPointIndex].position;
    }


}
