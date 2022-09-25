using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Popup : MonoBehaviour


{

    public GameObject PopUpBox;
    public TextMeshProUGUI PopUpText;
    public string text;
    public bool playerInrange;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInrange = true;
            Debug.Log("entered");
            if (PopUpBox.activeInHierarchy)
            {
                PopUpBox.SetActive(false);
            }
            else
            {
                PopUpBox.SetActive(true);
                PopUpText.text = text;
            }


        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInrange = false;
            Debug.Log("exited");
            PopUpBox.SetActive(false);

        }


    }
}
