using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    List<EnemyMovement> enemies = new List<EnemyMovement>();
    public List<Transform> spawnPoints;
    int spawnPointIndex = 0;
    GameObject player;
    Animator playerAnimator;
    public Timer timer;
    public Animator ScreenFadeAnimator;

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
    }

    void Start() {
        player = FindObjectOfType<Player>().gameObject;
        playerAnimator = player.GetComponent<Animator>();

        spawnPoints[spawnPointIndex].GetComponent<spawnPoint>().Activate();
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
        timer.ResetTimer();
        spawnPoints[spawnPointIndex].GetComponent<spawnPoint>().Deactivate();
        StartCoroutine(RespawnCoroutine());
    }

    IEnumerator RespawnCoroutine() {
        Time.timeScale = 0f;
        playerAnimator.SetTrigger("die");
        ScreenFadeAnimator.SetTrigger("play");
        yield return new WaitForSecondsRealtime(0.4f);
        player.transform.position = spawnPoints[spawnPointIndex].position + Vector3.back;
        foreach(var enemy in enemies) {
            enemy.InitPosition();
        }
        yield return new WaitForSecondsRealtime(0.4f);
        spawnPointIndex = spawnPointIndex < spawnPoints.Count - 1 ? spawnPointIndex + 1 : 0;
        spawnPoints[spawnPointIndex].GetComponent<spawnPoint>().Activate();
        Time.timeScale = 1f;
    }


}
