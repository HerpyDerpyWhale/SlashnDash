using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public HighScoreManager m_HighScores;

    public static float m_timer;
    public static bool m_finishedGame = false;
    public static float m_lastFinishedTime;

    public GameObject m_MainMenu;
    public GameObject m_HighScorePanel;
    public GameObject m_EndGamePanel;
    public Text m_HighScoresText;
    public Button m_HighScoreButton;
    public Text m_recentTimeText;

    public Text m_timerText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        m_HighScorePanel.SetActive(false);
        m_MainMenu.SetActive(!m_finishedGame);
        m_EndGamePanel.SetActive(m_finishedGame);
        float minutes = Mathf.FloorToInt(m_lastFinishedTime / 60);
        float seconds = Mathf.FloorToInt(m_lastFinishedTime% 60);
        m_recentTimeText.text = "You finished in " + string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    // Update is called once per frame
    void Update()
    {
        if (!m_finishedGame)
        {
            m_timer += Time.deltaTime;
            float minutes = Mathf.FloorToInt(m_timer / 60);
            float seconds = Mathf.FloorToInt(m_timer % 60);
            m_timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnHighScores()
    {
        m_MainMenu.SetActive(false);
        m_HighScorePanel.SetActive(true);

        string text = "";
        for (int i = 0; i < m_HighScores.scores.Length; i++)
        {
            int seconds = m_HighScores.scores[i];
            text += string.Format("{0:D2}:{1:D2}\n", (seconds / 60), (seconds % 60));
        }
        m_HighScoresText.text = text;
    }

    public void OnBack()
    {
        m_MainMenu.SetActive(true);
        m_HighScorePanel.SetActive(false);
        m_EndGamePanel.SetActive(false);
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeTime(float change)
    {
        m_timer -= change;
    }

    public void SaveTime()
    {
        m_lastFinishedTime = m_timer;
        m_HighScores.AddScore(Mathf.RoundToInt(m_timer));
        m_HighScores.SaveScoresToFile();
        m_finishedGame = true;
    }

    public void ResetTime()
    {
        m_timer = 0;
        m_finishedGame = false;
    }
}
