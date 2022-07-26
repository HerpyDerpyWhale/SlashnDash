using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointUpdate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CheckpointSystem cs = collision.gameObject.GetComponent<CheckpointSystem>();
            cs.UpdateCheckpoint(gameObject);
        }
    }
}
