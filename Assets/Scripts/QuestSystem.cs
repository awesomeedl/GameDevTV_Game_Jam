using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public static QuestSystem reference;
    public Dialogue beginDialogue;
    public Dialogue endDialogue;
    List<Quest> quests = new List<Quest>();

    

    void Awake() {
        reference = this;
    }

    void Start() {
        if(beginDialogue != null)
        {
            DialogueManager.reference.StartDialogue(beginDialogue);
        }
    }
    
    public void AddQuest(Quest quest) {
        quests.Add(quest);
    }

    public void CompleteQuest(Quest quest) {
        SoundManager.PlaySound("jingle");
        quest.GetComponent<SpriteRenderer>().color = Color.clear;
        foreach(var q in quests) {
            if(q.preRequisite == quest) {
                q.GetComponent<SpriteRenderer>().sprite = q.activatedSprite;
            }
        }
        if(quest.triggerDialogue != null) {
            DialogueManager.reference.StartDialogue(quest.triggerDialogue);
        }
        if(quest.door != null) {
            Destroy(quest.door);
        }
        if(quest.changeEnemyPath) {
            GameManager.reference.ChangeEnemyPattern(quest.enemyPathIndex);
        }
        quests.Remove(quest);
        if(quests.Count == 0) {
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel() {
        DialogueManager.reference.StartDialogue(endDialogue);
        while(DialogueManager.reference.started) {
            yield return null;
        }
        SceneLoader.LoadNextLevel();
    }
}
