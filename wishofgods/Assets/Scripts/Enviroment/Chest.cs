using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

 

    private bool isOpen = false;

    //testing if player is in range of Chest
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Chest active");
            isOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
          
            Debug.Log("Chest inactive");
            isOpen = false;
        }
    }

    //opening Chest if Player is in Range
    void Update()
    {

       /* if (Input.GetKey(KeyCode.E) && isOpen)
        {
           
            Debug.Log("Chest open");
        }
        if (Input.GetKey(KeyCode.E) && isOpen || Input.GetKey(KeyCode.Escape) && isOpen)
        {

            Debug.Log("Chest closed");
        }*/

    }

}
