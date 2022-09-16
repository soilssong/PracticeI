using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBird : MonoBehaviour
{

    public List<Transform> waypoints;
    public float moveSpeed;
    public int target;
    public Animator animator;

    Animator myanimator;
    // Start is called before the first frame update
    private void Start()
    {
      animator = GetComponent<Animator>();
    }


    void Update()
    {
        StartCoroutine(wait());
       
    }

    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(10f);

        animator.SetBool("isFlying", true);
       

        transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[target].position)
        {
            transform.position = waypoints[target].position;
            animator.SetBool("isFlying", false);

        }
       
    }

   

    

    
}
