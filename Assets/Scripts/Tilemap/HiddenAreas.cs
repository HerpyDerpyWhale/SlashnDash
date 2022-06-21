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
            StartCoroutine(FadeOut());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeOut()
    {
        Color c = m_tilemap.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            m_tilemap.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator FadeIn()
    {
        Color c = m_tilemap.color;

        while (c.a < 1)
        {
            c.a += 0.1f;
            m_tilemap.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
