using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoLogic : MonoBehaviour 
{
	public GameObject[] buttons = new GameObject[4];
	public List<int> sequence = new List<int>();
	public int sequenceIndex;

	void Start()
	{
		sequence.Add ((int)Random.Range (0, 3));
		sequence.Add ((int)Random.Range (0, 3));
		sequence.Add ((int)Random.Range (0, 3));
		sequence.Add ((int)Random.Range (0, 3));
	}

	public void MakeSequence()
	{
		StartCoroutine("HighlightButton");
	}

	IEnumerator HighlightButton()
	{
		for (int i = 0; i < sequence.Count; i++) 
		{
			CanvasGroup canvasGroup = buttons[sequence [i]].GetComponent<CanvasGroup>();
			while (canvasGroup.alpha < 1)
			{
				canvasGroup.alpha += Time.deltaTime / 2f;
				yield return null;
			}
			canvasGroup.alpha = 0.3
		}
	}
}
