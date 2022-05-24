using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public bool completed = false;

    public void Complete() {
        completed = true;
    }
}
