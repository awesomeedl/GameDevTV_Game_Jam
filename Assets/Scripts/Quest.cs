using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    QuestSystem questSystem;

    void Start() {
        questSystem = FindObjectOfType<QuestSystem>();
        questSystem.AddQuest(this);
    }

    public void Complete() {
        questSystem.CompleteQuest(this);
    }
}
