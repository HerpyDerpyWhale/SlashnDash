using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    public Animator m_slashAnimator;
    public PolygonCollider2D m_slashCollider;
    private bool m_enemyInfront = false;
    public PlayerMovement m_playerMovement;

    private EnemyAI enemyAI;

    public bool m_attacking = false;


    // Start is called before the first frame update
    void Start()
    {
        m_slashAnimator = GetComponent<Animator>();
        m_slashCollider = GetComponent<PolygonCollider2D>();
        m_playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            m_slashAnimator.SetTrigger("Slash");
            m_attacking = true;
            Invoke("EndAttack", 0.14f);
        }
        if (m_attacking && m_enemyInfront)
        {
            enemyAI.Death();
            m_playerMovement.Knockback(GameObject.FindGameObjectWithTag("Player").transform.position - transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemyAI = collision.gameObject.GetComponent<EnemyAI>();
            m_enemyInfront = true;
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
    }
}
