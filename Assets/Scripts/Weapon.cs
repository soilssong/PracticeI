using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public static bool isHoldgun = false;
    Health health;
    Animator animator;
    Rigidbody2D myRigidbody;
    CapsuleCollider2D capsuleCollider;

    public static bool isCloseToGun = false;

    void Start()
    {

        health = GetComponent<Health>();
        myRigidbody = GetComponent<Rigidbody2D>();
  
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
      
    }
    public bool returnHoldingGunStatus()
    {
        return isHoldgun;
    }

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gun")) 
        {
            isCloseToGun = !isCloseToGun;
            //Debug.Log(isCloseToGun);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Gun"))
        {
            isCloseToGun = !isCloseToGun;
            //Debug.Log(isCloseToGun);
        }
    }


    private void Update()
    {
       
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    void OnHoldGun(InputValue value)
    {
       

        if (value.isPressed && isCloseToGun)
        {

            isHoldgun = !isHoldgun;
            animator.SetBool("isSitting", isHoldgun);
          
           
        }


    }
}
