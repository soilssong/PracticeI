using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void MakeExplode()
    {
        animator.SetBool("isExploded", true);
    }
   
}
