using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCooldown : MonoBehaviour
{
    [SerializeField]
    private Image cooldownImage;

    private bool isCooldown = false;
    private float cooldownTimer;
    private float cooldownTime = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        cooldownImage.fillAmount = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseDash();
        }
        if (isCooldown)
        {
            ApplyCooldown();
        }
    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0)
        {
            isCooldown = false;
            cooldownImage.fillAmount = 1f;
        }
        else
        {
            cooldownImage.fillAmount = 1 - cooldownTimer / cooldownTime;
        }
    }

    public void UseDash()
    {
        if (isCooldown)
        {
            //Dash cooldown is still active
        }
        else
        {
            isCooldown = true;
            cooldownTimer = cooldownTime;
        }
    }
}
