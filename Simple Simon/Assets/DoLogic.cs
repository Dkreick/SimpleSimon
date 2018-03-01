using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoLogic : MonoBehaviour 
{
	public GameObject[] buttons = new GameObject[4];
	public List<int> sequence = new List<int>();

	void Start()
	{
		int numberToAdd = Random.Range (1, 4);
		sequence.Add (numberToAdd);
	}

	public void HighlightButton(int index)
	{
		Debug.Log ("Hola");
		if (index < sequence.Count) {
			float alpha = buttons [sequence[index]].GetComponent<CanvasGroup> ().alpha;
			
			while (alpha < 1) 
			{
				alpha += 0.1f * Time.deltaTime;
			}
			alpha = 0.33f;
		}

		int numberToAdd = Random.Range (1, 4);
		sequence.Add (numberToAdd);

		HighlightButton(index++);
	}
}
