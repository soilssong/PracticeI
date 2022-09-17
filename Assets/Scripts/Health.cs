using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;

      public Animator animator;

    

    void Awake()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

        
    }

    public void Update()
    {

    }

   

    public void TakeDamage( int amount)
    {
        currentHealth -= amount;

        if(currentHealth == 0)
        {
            
           
            animator.SetBool("isDead",true);
           
        }
    }
   
}
