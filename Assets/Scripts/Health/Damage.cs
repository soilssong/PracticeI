using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && collision.isTrigger == true)
        {
            var healthComponent = collision.GetComponent<Health>();
            if (healthComponent!= null)
            {
                healthComponent.TakeDamage(5);

                
            }
        }
    }

   
}
