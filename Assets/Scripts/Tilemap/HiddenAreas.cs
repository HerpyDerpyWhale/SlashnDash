using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HiddenAreas : MonoBehaviour
{
    private Tilemap m_tilemap;
    
    // Start is called before the first frame update
    void Start()
    {
        m_tilemap = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            m_tilemap.color = new Color(1, 1, 1, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            m_tilemap.color = new Color(1, 1, 1, 1);

        }
    }

}
