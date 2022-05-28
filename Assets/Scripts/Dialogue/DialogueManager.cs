using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {

	public Image characterImage;
	public TMP_Text dialogueText;


	public UIController uiController;

	private Queue<string> sentences = new Queue<string>();
	private Queue<Sprite> icons = new Queue<Sprite>();

	public bool started = false;

	public void StartDialogue (Dialogue dialogue)
	{
		started = true;
		Time.timeScale = 0;

		uiController.ToggleUI();
		
		icons.Clear();
		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		foreach (Sprite icon in dialogue.icons)
		{
			icons.Enqueue(icon);
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
		characterImage.sprite = icon;

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