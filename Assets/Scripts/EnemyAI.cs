using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public float m_minimumX;
    public float m_maximumX;
    public float m_enemyMovementSpeed;
    public float m_alertTime = 3;
    private float m_alertTimer;

    private bool m_playerNear;
    public bool m_playerSeen;

    public GameObject player;
    public GameObject m_alertIcons;
    public Image m_alertIcon;

    private Rigidbody2D m_rb;

    private Vector2 m_movingDirection = Vector2.left;
    private PlayerMovement m_pm;
    private CheckpointSystem m_checkpointSystem;
    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        m_pm = player.GetComponent<PlayerMovement>();
        m_checkpointSystem = player.GetComponent<CheckpointSystem>();
        m_rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if (m_alertTimer <= 0)
        {
            m_alertIcons.SetActive(false);
        }
        if (m_playerNear)
        {
            if (!Physics2D.Linecast(transform.position, player.transform.position, 0) && !m_pm.m_playerHidden)
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
            m_animator.SetBool("StandingStill", false);
            m_rb.velocity = m_enemyMovementSpeed * m_movingDirection;
            if (m_alertTimer > 0)
            {
                m_alertTimer -= Time.deltaTime;
                m_alertIcon.fillAmount = m_alertTimer / m_alertTime;
            }  
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
        else
        {
            m_animator.SetBool("StandingStill", true);
            m_alertIcons.SetActive(true);
            m_alertTimer += Time.deltaTime;
            m_alertIcon.fillAmount = m_alertTimer/m_alertTime;
            if (m_alertTimer >= m_alertTime)
            {
                m_animator.SetTrigger("Attack");
                m_alertTimer = 0;
                m_checkpointSystem.Death();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {   
            m_playerNear = true;
        }
        else
        {
            Physics2D.IgnoreCollision(collision.GetComponent<BoxCollider2D>(), GetComponent<PolygonCollider2D>());
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

    public void Death()
    {
        m_alertIcons.SetActive(false);
        m_animator.SetBool("Dead", true);
        Invoke("Disable", 0.35f);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.ChangeTime(2);
    }
}
