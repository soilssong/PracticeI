using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    static bool isSitting = false;
    bool isFacingRight = true;

    [SerializeField] float runSpeed = 10f;
    Health health;
    Animator animator;
  

    Weapon weapon;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    CapsuleCollider2D capsuleCollider;

    void Start()
    {

        health = GetComponent<Health>();
        weapon = GetComponent<Weapon>();
       

        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();

    }

    void Update()
    {
        Run();
        FlipSprite();
        Debug.Log(weapon.returnHoldingGunStatus());
    }

    void OnJump(InputValue value)
    {

        if (health.returnAliveStatus() == false || isSitting == true) { return; }
        if (!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0f, 10f);
        }
    }
    void OnMove(InputValue value)
    {
        if (health.returnAliveStatus() == false || isSitting == true) { return; }



        moveInput = value.Get<Vector2>();

    }

    void OnSit(InputValue value)
    {

        if (health.returnAliveStatus() == false) { return; }

        if (value.isPressed)
        {

            isSitting = !isSitting;

            if (isSitting == true)
            {
                animator.SetBool("isSitting", true);
            }

            if (isSitting == false)
            {
                animator.SetBool("isSitting", false);
            }
        }



    }

    void Run()
    {
        if (health.returnAliveStatus() == false || isSitting == true || weapon.returnHoldingGunStatus()) { return; }
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);

        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontal = Mathf.Abs(playerVelocity.x) > Mathf.Epsilon;


        animator.SetBool("isRunning", playerHasHorizontal);


    }
    void FlipSprite()
    {
        if (health.returnAliveStatus() == false || isSitting == true) { return; }
        if (isFacingRight && myRigidbody.velocity.x < 0f || !isFacingRight && myRigidbody.velocity.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }











}
