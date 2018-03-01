using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoLogic : MonoBehaviour 
{
	public GameObject[] buttons = new GameObject[4];
	public List<int> sequence = new List<int>();
	public int index;

	void Start()
	{
		int numberToAdd = Random.Range (1, 4);
		sequence.Add (numberToAdd);
		Debug.Log ("Hola");
	}

	public void MakeSequence()
	{
		if (index < sequence.Count)
		{
			Debug.Log ("Hola2");
			StartCoroutine("HighlightButton");
//			int numberToAdd = Random.Range (1, 4);
//			sequence.Add (numberToAdd);
			index++;
			HighlightButton();
		}
	}

	IEnumerator HighlightButton()
	{
		CanvasGroup canvasGroup = buttons[sequence [index]].GetComponent<CanvasGroup>();
		while (canvasGroup.alpha < 1)
		{
			canvasGroup.alpha += Time.deltaTime / 1f;
			yield return null;
		}
		canvasGroup.alpha = 0.33f;
	}
}
