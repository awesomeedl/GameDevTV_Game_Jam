using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject DialogueUI;
    public GameObject GameUI;
    public Button respawnButton;

    public void ToggleUI()
    {
        DialogueUI.SetActive(!DialogueUI.activeInHierarchy);
        GameUI.SetActive(!GameUI.activeInHierarchy);
    }

    void Update()
    {
        if (GameUI.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
        {
            respawnButton.onClick.Invoke();
        }
    }
}
