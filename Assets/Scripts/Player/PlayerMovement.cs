using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_moveSpeed;
    public float m_jumpForce;
    public float m_dashForce;
    public float m_hinput;
    public float m_groundCheckHeight;
    public float m_dashCooldown;

    private Vector2 m_mousePosition;
    private Vector2 m_mouseDirection;
    private Vector2 m_dashSpeed;

    private bool m_jumpInput;
    public bool m_canDash = true;

    private Rigidbody2D m_rb;
    public ParticleSystem m_particleSystem;
    public TrailRenderer m_trailRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_dashCooldown = 1.5f;
    }

    // Update is called once per frame
    private void Update()
    {
        m_hinput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Fire1"))
        {
            if (m_canDash)
            {
                m_canDash = false;
                Dash();
            }
        }
        if (Input.GetButtonDown("Jump"))
        {
            m_jumpInput = true;
        }

    }

    private void FixedUpdate()
    {
        m_rb.AddForce(Vector2.right * m_moveSpeed * m_hinput, ForceMode2D.Force);
        RaycastHit2D ground = Physics2D.Raycast(transform.position, Vector2.down, m_groundCheckHeight);
        if (ground.collider != null)
        {
            if (m_jumpInput)
            {
                m_rb.AddForce(Vector2.up * m_jumpForce, ForceMode2D.Impulse);
            }
        }
        m_jumpInput = false;
    }

    private void Dash()
    {
        m_mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 pos = transform.position;
        m_mouseDirection = m_mousePosition - pos;
        float m_mouseX = Clamp(m_mouseDirection.x);
        float m_mouseY = Clamp(m_mouseDirection.y);
        m_trailRenderer.emitting = true;
        m_dashSpeed = new Vector2(m_mouseX * m_dashForce, m_mouseY * m_dashForce);
        m_rb.AddForce(m_dashSpeed, ForceMode2D.Impulse);
        float timer = 0;
        while (timer < 2)
        {
            timer += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.P))
            {   
                break;
            }
        }
        Invoke("Delay", m_dashCooldown);
    }
    
    public static float Clamp(float value)
    {
        return (value < -1.5f) ? -1.5f : (value > 1.5f) ? 1.5f : value;
    }

    private void Delay()
    {
        m_canDash = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_trailRenderer.emitting = false;
    }
}
