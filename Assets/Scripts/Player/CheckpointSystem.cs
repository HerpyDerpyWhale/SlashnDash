using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointSystem : MonoBehaviour
{
    private Vector3 latestCheckpoint;
    private Animator animator;
    public bool hasDied = false;
    public bool hasKatana = false;
    public Rigidbody2D katanaRigidbody2D;
    public GameObject katana;
    public SpriteRenderer slashSprite;

    private void Start()
    {
        animator = GetComponent<Animator>();
        slashSprite = katana.transform.Find("slash").GetComponent<SpriteRenderer>();
        Scene currentscene = SceneManager.GetActiveScene();
        if (currentscene.name != "Tutorial")
        {
            hasKatana = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            Death();
        }
    }

    public void Death()
    {
        animator.SetTrigger("Death");
        if (hasKatana)
        {
            Rigidbody2D katanaInstance = Instantiate(katanaRigidbody2D, gameObject.transform.position, Quaternion.Euler(0, 0, Random.Range(10f, 170f))) as Rigidbody2D;
            katanaInstance.velocity = new Vector2(0, 10);
        }
        katana.SetActive(false);
        Invoke("Respawn", 0.5f);
    }

    public void Respawn()
    {
        animator.ResetTrigger("Death");
        gameObject.transform.position = latestCheckpoint;
        slashSprite.sprite = null;
        if (hasKatana)
        {
            katana.SetActive(true);
        }
    }

    public void UpdateCheckpoint(GameObject Checkpoint)
    {
        latestCheckpoint = Checkpoint.transform.position;
    }

    public void ObtainedKatana()
    {
        hasKatana = true;
    }


}
