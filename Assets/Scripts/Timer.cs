using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float levelTime = 25f;
    float currentTime;
    
    public TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
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
            GameManager.instance.Respawn();
            currentTime = levelTime;
        }
    }

    public void ResetTimer() {
        currentTime = levelTime;
    }
}
