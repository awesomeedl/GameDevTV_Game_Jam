using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float levelTime = 5f;
    float currentTime;
    public Image img;
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
            img.fillAmount = currentTime/levelTime;
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
