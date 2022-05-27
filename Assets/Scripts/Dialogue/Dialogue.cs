using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue {

	public Sprite[] icons;

	[TextArea(3, 10)]
	public string[] sentences;

}