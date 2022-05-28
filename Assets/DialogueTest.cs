using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}
