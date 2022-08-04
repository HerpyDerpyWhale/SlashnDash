using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    public Animator m_slashAnimator;
    public PolygonCollider2D m_slashCollider;
    private bool m_enemyInfront = false;
    public PlayerMovement m_playerMovement;
    public Transform m_katana;
    public SpriteRenderer m_katanaSprite;

    private EnemyAI enemyAI;

    public bool m_attacking = false;


    // Start is called before the first frame update
    void Start()
    {
        m_slashAnimator = GetComponent<Animator>();
        m_slashCollider = GetComponent<PolygonCollider2D>();
        m_playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        m_katana = transform.parent;
        m_katanaSprite = m_katana.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !m_attacking)
        {
            m_slashAnimator.SetTrigger("Slash");
            m_katanaSprite.enabled = false;
            m_attacking = true;
            Invoke("EndAttack", 0.2f);
        }
        if (m_attacking && m_enemyInfront)
        {
            enemyAI.Death();
            m_playerMovement.Knockback(GameObject.FindGameObjectWithTag("Player").transform.position - transform.position);
            m_enemyInfront = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (Vector3.Distance(collision.transform.position, m_katana.position + m_katana.right) < 2f)
            {
                enemyAI = collision.gameObject.GetComponent<EnemyAI>();
                m_enemyInfront = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            m_enemyInfront = false;
        }
    }

    private void EndAttack()
    {
        m_attacking = false;
        m_katanaSprite.enabled = true;
    }
}
