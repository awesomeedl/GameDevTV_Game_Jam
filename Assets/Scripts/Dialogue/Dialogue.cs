using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue {

	[System.Serializable]
	public class Sentence {
		public Sprite icon;
		public bool dim;
		[TextArea(3, 10)]
		public string sentence;
	}

	public List<Sentence> sentences;

}