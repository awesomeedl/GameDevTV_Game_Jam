using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public Quest preRequisite;
    public Dialogue triggerDialogue;
    public bool openDoor = false;
    public GameObject door;
    public bool changeEnemyPath = false;
    public int enemyPathIndex = 0;
    bool completed = false;

    void Start() {
        QuestSystem.reference.AddQuest(this);
    }

    public void Complete() {
        if((preRequisite == null || (preRequisite != null && preRequisite.completed)) && !completed)
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
            QuestSystem.reference.CompleteQuest(this);
            completed = true;
        }
    }

    void OnTriggerEnter2D() {        
        GetComponent<Quest>().Complete();
    }
}
