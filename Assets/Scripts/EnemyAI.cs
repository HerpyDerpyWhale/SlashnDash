using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float m_minimumX;
    public float m_maximumX;

    private bool m_playerNear;
    public bool m_playerSeen;

    public GameObject player;

    private Rigidbody2D m_rb;

    private Vector2 m_movingDirection;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        m_rb = GetComponent<Rigidbody2D>();

        m_movingDirection = Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_playerNear)
        {
            if (!Physics2D.Linecast(transform.position, player.transform.position, 0))
            {
                m_playerSeen = true;
            }
            else
            {
                Debug.Log(Physics2D.Linecast(transform.position, player.transform.position));
                m_playerSeen = false;
            }
        }
        if (!m_playerSeen)
        {
            m_rb.velocity = m_movingDirection;
            if (transform.position.x < m_minimumX)
            {
                m_movingDirection = Vector2.right;
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (transform.position.x > m_maximumX)
            {
                m_movingDirection = Vector2.left;
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {   
            m_playerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_playerNear = false;
            m_playerSeen = false;
        }
    }
}
