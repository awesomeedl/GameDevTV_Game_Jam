using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    GameObject player;
    public List<Transform> spawnPoints;
    public float levelTime = 25f;
    float currentTime;

    public TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        currentTime = levelTime;
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
    }

    void CountDown() {
        if(currentTime > 0) {
            currentTime -= Time.deltaTime;
            timerText.text = "Remaining Time: " + currentTime.ToString("N");
        }
        else
        {
            Respawn();
            currentTime = levelTime;
        }
    }

    void Respawn() {
        player.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
    }
}
