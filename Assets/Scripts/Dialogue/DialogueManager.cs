using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {

	public static DialogueManager reference;
	public Image characterImage;
	public TMP_Text dialogueText;
	public UIController uiController;

	private Queue<string> sentences = new Queue<string>();
	private Queue<Sprite> icons = new Queue<Sprite>();
	private Queue<bool> dimBools = new Queue<bool>();

	public bool started = false;

	void Awake() {
		reference = this;
	}

	public void StartDialogue (Dialogue dialogue)
	{
		started = true;
		Time.timeScale = 0;

		uiController.ToggleUI();
		
		icons.Clear();
		sentences.Clear();

		foreach (var sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence.sentence);
			icons.Enqueue(sentence.icon);
			dimBools.Enqueue(sentence.dim);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		Sprite icon = icons.Dequeue();
		bool dim = dimBools.Dequeue();
		if(icon == null)
		{
			characterImage.color = Color.clear;
		}
		else
		{
			characterImage.sprite = icon;
			characterImage.color = dim ? Color.gray : Color.white;
		}
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		started = false;
		Time.timeScale = 1;
		uiController.ToggleUI();
	}

}