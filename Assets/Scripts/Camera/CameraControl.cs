using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public float m_dampTime = 0.2f;

    public Transform m_target;

    private Vector2 m_moveVelocity;
    private Vector2 m_desiredPosition;

    private void Awake()
    {
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        m_desiredPosition = m_target.position;
        transform.position = Vector2.SmoothDamp(transform.position, m_desiredPosition, ref m_moveVelocity, m_dampTime);
    }
}
