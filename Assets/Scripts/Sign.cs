using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public string dialog;
    public bool playerInrange;

    bool interaction;
  

  
    
    void Awake()
    {
   

      
       
    }

    void Update()
    {
      
     
    }
   void OnInteract(InputValue value)
    {
        if (value.isPressed && playerInrange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
     
        }
        
    
       
    }

      

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wolf"))
        {
           playerInrange = true;
           
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wolf"))
        {
            playerInrange=false;
            dialogBox.SetActive(false);
            

        }

        
    }

}
