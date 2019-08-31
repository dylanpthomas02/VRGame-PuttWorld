using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text[] scoreTextFields;

    void Start()
    {
        foreach (var textField in scoreTextFields)
        {
            textField.text = "-";
        }
    }

    public void UpdateScore(int holeNumber)
    {
        scoreTextFields[holeNumber - 1].text = ScoreManager.instance.playerHoleScore.ToString();
    }
}
