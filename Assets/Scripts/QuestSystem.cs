using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public Dialogue endDialogue;
    List<Quest> quests = new List<Quest>();

    public void AddQuest(Quest quest) {
        quests.Add(quest);
    }

    public void CompleteQuest(Quest quest) {
        quests.Remove(quest);
        if(quests.Count == 0) {
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel() {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.StartDialogue(endDialogue);
        while(dialogueManager.started) {
            yield return null;
        }
        SceneLoader.instance.LoadNextLevel();
    }
}
