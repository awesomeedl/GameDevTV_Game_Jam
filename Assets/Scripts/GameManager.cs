using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager reference;
    List<Enemy> enemies = new List<Enemy>();
    public List<Transform> spawnPoints;
    int spawnPointIndex = 0;
    public GameObject player;
    Animator playerAnimator;
    public Timer timer;
    public Animator ScreenFadeAnimator;
    bool isRespawning = false;

    void Awake()
    {
        reference = this;
    }

    void Start() {
        playerAnimator = player.GetComponent<Animator>();
        spawnPoints[spawnPointIndex].GetComponent<spawnPoint>().Activate();
    }

    public void AddEnemy(Enemy enemy) {
       enemies.Add(enemy); 
    }

    public void ChangeEnemyPattern(int index) {
        foreach(var enemy in enemies) {
            enemy.ChangePathSet(index);
        }
    }

    public void Respawn() {
        if(!isRespawning) {
            StartCoroutine(RespawnCoroutine());
        }
    }

    IEnumerator RespawnCoroutine() {
        isRespawning = true;
        Time.timeScale = 0f;
        timer.ResetTimer();
        spawnPoints[spawnPointIndex].GetComponent<spawnPoint>().Deactivate();
        SoundManager.PlaySound("death");
        playerAnimator.SetTrigger("die");
        yield return new WaitForSecondsRealtime(0.4f);
        ScreenFadeAnimator.SetTrigger("play");
        yield return new WaitForSecondsRealtime(0.25f);
        player.transform.position = spawnPoints[spawnPointIndex].position + Vector3.back;
        foreach(var enemy in enemies) {
            enemy.InitPosition();
        }
        yield return new WaitForSecondsRealtime(0.25f);
        spawnPointIndex = spawnPointIndex < spawnPoints.Count - 1 ? spawnPointIndex + 1 : 0;
        spawnPoints[spawnPointIndex].GetComponent<spawnPoint>().Activate();
        Time.timeScale = 1f;
        isRespawning = false;
    }


}
