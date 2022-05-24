using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public List<Quest> quests;

    void FixedUpdate()
    {
        bool allCompleted = true;
        foreach(var quest in quests) {
            if(!quest.completed) {
                allCompleted = false;
            }
        }
        if(allCompleted) {
            SceneLoader.instance.LoadNextLevel();
        }
    }
}
