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
    public Text[] holeStrokesText;
    public Text[] courseParText;

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
        holeStrokesText[currentHole].text = strokes.ToString();

        if(holeComplete)
        {
            HoleCompleteUIUpdate();
        }
    }

    public void HoleCompleteUIUpdate()
    {
        // get the score for this hole...
        int thisHoleParScore = strokes - holeParScore[currentHole];
        // ...add it to the previous hole's score
        int cumulativeParScore = thisHoleParScore + previousHoleParScore;
        // ...then add the appropriate prefix and text colour to the current score
        if (cumulativeParScore > 0)
        {   
            // over par
            playerParScoreText[currentHole].text = "+" + cumulativeParScore.ToString();
            playerParScoreText[currentHole].GetComponent<Text>().color = Color.red;
        }
        else if (cumulativeParScore < 0)
        {   
            // under par
            playerParScoreText[currentHole].text = cumulativeParScore.ToString();
            playerParScoreText[currentHole].GetComponent<Text>().color = Color.green;
        }
        else
        {   
            // even par
            playerParScoreText[currentHole].text = "-";
        }

        previousHoleParScore = cumulativeParScore;

        NextHole();
    }

    private void NextHole()
    {
        previousHole = currentHole;
        currentHole++;
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

        // update text to display the par score for each hole on the course
        for (int i = 0; i < holeParScore.Length; i++)
        {
            courseParText[i].text = holeParScore[i].ToString();
        }
    }
}
