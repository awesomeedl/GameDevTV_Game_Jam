using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneButton : MonoBehaviour
{
    public void LoadNextLevel() {
        SceneLoader.instance.LoadNextLevel();
    }
}
