using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static float m_timer;

    public Text timerText;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        float minutes = Mathf.FloorToInt(m_timer / 60);
        float seconds = Mathf.FloorToInt(m_timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
