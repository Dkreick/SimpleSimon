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
    public GameObject playButton;
    public GameObject gameOverText;
    public GameObject scoreText;

    void Start()
    {
        sequenceStep = 0;
        isPlayerTurn = false;
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
                buttons[sequence[sequenceStep]].GetComponent<AudioSource>().Play();
                StartCoroutine(OnClickButton(indexButton));
                sequenceStep++;
                scoreText.GetComponent<Text>().text = "SCORE: " + sequenceStep;
            }
            else
            {
                gameOverText.SetActive(true);
                sequenceStep = 0;
                sequence.Clear();
                playButton.GetComponent<Button>().interactable = true;
                return;
            }
        }
        if (sequenceStep == sequence.Count)
        {
            isPlayerTurn = false;       
            sequence.Add((int)Random.Range(0, 3));
            sequenceStep = 0;
            playButton.GetComponent<Button>().interactable = true;
        }
    }

    IEnumerator OnClickButton(int button)
    {
        CanvasGroup canvasGroup = buttons[button].GetComponent<CanvasGroup>();
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / 1 * 2;
            yield return null;
        }
        canvasGroup.alpha = 0.3f;
    }

    IEnumerator HighlightButton()
    {
        for (int i = 0; i < sequence.Count; i++)
        {
            buttons[sequence[i]].GetComponent<AudioSource>().Play();
            CanvasGroup canvasGroup = buttons[sequence[i]].GetComponent<CanvasGroup>();
            while (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime / 1 * (sequence.Count + 1);
                yield return null;
            }
            canvasGroup.alpha = 0.3f;
        }

        isPlayerTurn = true;
    }
}