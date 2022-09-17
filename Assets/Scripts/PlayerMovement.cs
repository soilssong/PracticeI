using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  
    bool isFacingRight = true;
    [SerializeField] float runSpeed = 10f;

    Animator animator;
    bool Alive;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    CapsuleCollider2D capsuleCollider;

    void Start()
    {
        
        

        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
       
    }

    void Update()
    {

        Run();
        FlipSprite();

       
    }

    void OnJump(InputValue value)
    {

        //if(!Alive == false) { return; }
        if (!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if(value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0f, 10f);
        }
    }
    void OnMove(InputValue value)
    {
        //if (!Alive == false) { return; }
        moveInput = value.Get<Vector2>();
        
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
      
        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontal = Mathf.Abs(playerVelocity.x) > Mathf.Epsilon;


            animator.SetBool("isRunning", playerHasHorizontal);
      
      
    }
    void FlipSprite()
    {
        if (isFacingRight && myRigidbody.velocity.x < 0f || !isFacingRight && myRigidbody.velocity.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }











}
