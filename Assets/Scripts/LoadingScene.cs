using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScene : MonoBehaviour
{

    [SerializeField] GameObject button;

    void Awake()
    {
     
        
        StartCoroutine(wait());
       
    }

    IEnumerator wait()
    {
        button.SetActive(false);
        yield return new WaitForSecondsRealtime(0.2f);
        button.SetActive(true);
    }
    
}
