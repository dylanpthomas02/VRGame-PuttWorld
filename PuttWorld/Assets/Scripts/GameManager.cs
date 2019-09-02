using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private ScoreManager m_scoreManager;
    private ScoreManager scoreManager
    {
        get
        {
            if (m_scoreManager == null)
            {
                m_scoreManager = ScoreManager.instance;
            }
            return m_scoreManager;
        }
    }

    public void StartGame()
    {
        scoreManager.GameStart();
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

    void Update()
    {
        if (scoreManager == null)
        {
            Debug.LogWarning("No score manager");
            return;
        }   
    }
}
