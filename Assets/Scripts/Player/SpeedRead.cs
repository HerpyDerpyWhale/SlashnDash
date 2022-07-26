using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRead : MonoBehaviour
{
    public float currentHorizontalMovement;
    public float currentVerticalMovement;

    private Vector2 lastPos;
    private Vector2 currentPos;

    Animator playerAnimator;
    SpriteRenderer sr;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerAnimator.SetTrigger(1);
        }
        else
        {
            playerAnimator.SetTrigger(0);
        }

        if (currentHorizontalMovement > 0)
        {
            sr.flipX = false;
        }
        else if (currentHorizontalMovement < 0)
        {
            sr.flipX = true;
        }


        currentPos = transform.position;

        currentHorizontalMovement = (currentPos.x - lastPos.x);
        currentVerticalMovement = (currentPos.y - lastPos.y);


        playerAnimator.SetFloat("Horizontal Movement", currentHorizontalMovement);
        playerAnimator.SetFloat("Vertical Movement", currentVerticalMovement);
        lastPos = currentPos;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
