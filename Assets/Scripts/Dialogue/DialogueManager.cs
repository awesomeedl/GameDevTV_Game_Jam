using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Image characterImage;
	public Text dialogueText;

	public Animator animator;

	private Queue<string> sentences;
	private Queue<Sprite> icons;

	public bool started = false;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
		icons = new Queue<Sprite>();
	}

	public void StartDialogue (Dialogue dialogue)
	{
		started = true;
		Time.timeScale = 0;
		animator.SetBool("IsOpen", true);

		
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
		animator.SetBool("IsOpen", false);
	}

}