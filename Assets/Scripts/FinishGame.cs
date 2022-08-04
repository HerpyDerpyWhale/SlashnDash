using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    public GameManager m_gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_gameManager.SaveTime();
        SceneManager.LoadScene("MainMenu");
    }
}
