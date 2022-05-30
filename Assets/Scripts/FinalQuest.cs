using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalQuest : MonoBehaviour
{
    public Dialogue triggerDialogue;
    // Start is called before the first frame update
    public void Complete() {
        GetComponent<SpriteRenderer>().color = Color.gray;
        DialogueManager.reference.StartDialogue(triggerDialogue);
        StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel() {
        DialogueManager.reference.StartDialogue(triggerDialogue);
        while(DialogueManager.reference.started) {
            yield return null;
        }
        SceneLoader.LoadMenu();
    }

    void OnTriggerEnter2D() {        
        Complete();
    }
}
