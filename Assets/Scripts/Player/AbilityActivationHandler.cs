using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityActivationHandler : MonoBehaviour
{

    public GameObject katana;
    public GameObject cooldownIcon;
    public PlayerMovement playerMovement;
    public CheckpointSystem checkpointSystem;


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        katana.SetActive(false);
        cooldownIcon.SetActive(false);
        playerMovement.m_canDash = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "katana")
        {
            katana.SetActive(true);
            cooldownIcon.SetActive(true);
            playerMovement.m_canDash = true;
            collision.gameObject.SetActive(false);
            checkpointSystem.ObtainedKatana();
        }
    }
}
