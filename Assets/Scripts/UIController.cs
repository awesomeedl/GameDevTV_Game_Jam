using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject DialogueUI;
    public GameObject GameUI;
    
    public void ToggleUI() {
        DialogueUI.SetActive(!DialogueUI.activeInHierarchy);
        GameUI.SetActive(!GameUI.activeInHierarchy);   
    }
}
