using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public HighScoreManager m_HighScores;

    public static float m_timer;
    public static bool m_finishedGame;

    public Text timerText;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        float minutes = Mathf.FloorToInt(m_timer / 60);
        float seconds = Mathf.FloorToInt(m_timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void ChangeTime(float change)
    {
        m_timer -= change;
    }

    public void SaveTime()
    {
        m_HighScores.AddScore(Mathf.RoundToInt(m_timer));
        m_HighScores.SaveScoresToFile();
        m_finishedGame = true;
    }

    public void ResetTime()
    {
        m_timer = 0;
    }
}
