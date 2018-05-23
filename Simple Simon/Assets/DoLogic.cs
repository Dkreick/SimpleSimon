using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoLogic : MonoBehaviour
{
    public GameObject[] buttons = new GameObject[4];
    public List<int> sequence = new List<int>();
    public bool isPlayerTurn;
    public int sequenceStep;

    void Start()
    {
        sequenceStep = 0;
        isPlayerTurn = false;
        sequence.Add((int)Random.Range(0, 3));
        sequence.Add((int)Random.Range(0, 3));
        sequence.Add((int)Random.Range(0, 3));
        sequence.Add((int)Random.Range(0, 3));
    }

    public void PlaySequence()
    {
        StartCoroutine("HighlightButton");
    }

    public void CheckSequence(int indexButton)
    {
        if (isPlayerTurn == true)
        {
            if (sequence[sequenceStep] == indexButton)
            {
                Debug.Log("BIEN");
                sequenceStep++;
            }
            else
            {
                Debug.Log("MAL");
                //DisplayLoseMessage();
                sequenceStep = 0;
                sequence.Clear();
                return;
            }
        }
        if (sequenceStep == sequence.Count)
        {
            sequence.Add((int)Random.Range(0, 3));
            sequenceStep = 0;
        }
    }

    IEnumerator HighlightButton()
    {
        for (int i = 0; i < sequence.Count; i++)
        {
            CanvasGroup canvasGroup = buttons[sequence[i]].GetComponent<CanvasGroup>();
            while (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime / 2f;
                yield return null;
            }
            canvasGroup.alpha = 0.3f;
        }

        isPlayerTurn = true;
    }
}