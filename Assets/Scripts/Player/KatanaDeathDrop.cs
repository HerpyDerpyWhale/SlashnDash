using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaDeathDrop : MonoBehaviour
{
    public float m_maxLifetime = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, m_maxLifetime);
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), collision.collider);
    }
}
