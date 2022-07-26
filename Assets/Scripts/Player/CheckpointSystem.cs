using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    private Vector3 latestCheckpoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        gameObject.transform.position = latestCheckpoint;
    }

    public void UpdateCheckpoint(GameObject Checkpoint)
    {
        latestCheckpoint = Checkpoint.transform.position;
    }
}
