using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public static QuestSystem reference;
    public DialogueManager dialogueManager;
    public Dialogue beginDialogue;
    public Dialogue endDialogue;
    List<Quest> quests = new List<Quest>();

    void Awake() {
        reference = this;
    }

    void Start() {
        dialogueManager.StartDialogue(beginDialogue);
    }
    
    public void AddQuest(Quest quest) {
        quests.Add(quest);
    }

    public void CompleteQuest(Quest quest) {
        SoundManager.PlaySound("jingle");
        if(quest.triggerDialogue != null) {
            dialogueManager.StartDialogue(quest.triggerDialogue);
        }
        if(quest.openDoor) {
            Destroy(quest.door);
        }
        if(quest.changeEnemyPath) {
            GameManager.instance.ChangeEnemyPattern(quest.enemyPathIndex);
        }
        quests.Remove(quest);
        if(quests.Count == 0) {
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel() {
        dialogueManager.StartDialogue(endDialogue);
        while(dialogueManager.started) {
            yield return null;
        }
        SceneLoader.LoadNextLevel();
    }
}
