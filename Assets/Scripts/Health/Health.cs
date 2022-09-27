using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;
 
      public Animator animator;

     public static bool isAlive = true;

    public bool returnAliveStatus()
    {
        return isAlive;
    }

    void Awake()
    {

        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

        
    }

    public void TakeDamage( int amount)
    {
        currentHealth -= amount;

        if(currentHealth == 0)
        {
            isAlive = false;  
            animator.SetBool("isDead",true);
          
        }
    }
    
}
