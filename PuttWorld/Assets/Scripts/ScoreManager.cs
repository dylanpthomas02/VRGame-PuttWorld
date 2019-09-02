using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;

    public int[] holeParScore;
    public int currentHole = 0;
    public Text[] playerParScoreText;
    public Text[] playerHoleScoreText;

    int previousHoleParScore = 0;

    int strokes = 0;
    int previousHole = 0;
    bool holeComplete = false;

    public void GameStart()
    {
        previousHoleParScore = 0;
        holeComplete = false;
        strokes = 0;
        currentHole = 0;
        UpdateScore();
    }

    public void IncrementStrokes()
    {
        strokes++;
        UpdateScore();
    }

    public void HoleComplete()
    {
        holeComplete = true;
        UpdateScore();
    }

    public void UpdateScore()
    {
        playerHoleScoreText[currentHole].text = strokes.ToString();

        if(holeComplete)
        {
            HoleCompleteUIUpdate();
        }
    }

    public void HoleCompleteUIUpdate()
    {
        // get the current hole par score
        int thisHoleParScore = strokes - holeParScore[currentHole];
        // add it to the previous hole's par score
        int cumulativeParScore = thisHoleParScore + previousHoleParScore;
        // add the appropriate prefix to the score
        if (cumulativeParScore > 0) // over par
        {
            playerParScoreText[currentHole].text = "+" + cumulativeParScore.ToString();
            playerParScoreText[currentHole].GetComponent<Text>().color = Color.red;
        }
        else if (cumulativeParScore < 0) // under par
        {
            playerParScoreText[currentHole].text = "-" + cumulativeParScore.ToString();
            playerParScoreText[currentHole].GetComponent<Text>().color = Color.green;
        }
        else // even par
        {
            playerParScoreText[currentHole].text = "-";
        }

        previousHoleParScore = cumulativeParScore;

        NextHole();
    }

    private void NextHole()
    {
        previousHole = currentHole;
        currentHole++;
        Debug.Log(previousHole);
        Debug.Log(currentHole);
        strokes = 0;
        holeComplete = false;
        UpdateScore();
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }
}
