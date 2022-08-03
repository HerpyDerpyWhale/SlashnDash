using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public Sprite m_leverOff;
    public Sprite m_leverOn;

    public GameObject m_gate;
    private SpriteRenderer m_spriteRenderer;

    private void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_spriteRenderer.sprite = m_leverOff;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            m_gate.SetActive(false);
            m_spriteRenderer.sprite = m_leverOn;
        }
    }
}
