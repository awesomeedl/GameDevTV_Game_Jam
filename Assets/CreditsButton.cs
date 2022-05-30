using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : MonoBehaviour
{
    public GameObject credits;
    public void ToggleCredits() {
        credits.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if(credits.activeInHierarchy && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))) {
            credits.SetActive(false);
        }
    }
}
