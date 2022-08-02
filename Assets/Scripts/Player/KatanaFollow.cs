using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaFollow : MonoBehaviour
{
    public float offset;
    private float rotation_z;
    private SpriteRenderer m_sr;
    public SpriteRenderer m_slashsr;
    

    // Start is called before the first frame update
    void Start()
    {
        m_sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);
        if (rotation_z >= 90 || rotation_z <= -90)
        {
            m_sr.flipY = true;
            m_slashsr.flipY = true;
        }
        else
        {
            m_sr.flipY = false;
            m_slashsr.flipY = false;
        }
    }
}
