using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public bool gameStarted = false;

    public void StartGame()
    {
        if (!gameStarted)
        {
            ScoreManager.instance.GameStart();
            gameStarted = true;
        }
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
