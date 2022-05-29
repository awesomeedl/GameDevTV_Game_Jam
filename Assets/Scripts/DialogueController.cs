using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueManager.started && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))) {
            dialogueManager.DisplayNextSentence();
        }   
    }
}