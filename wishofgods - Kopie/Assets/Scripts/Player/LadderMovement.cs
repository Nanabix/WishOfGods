using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        //get Player input on vertial axis (w and s)
        vertical = Input.GetAxisRaw("Vertical");

        //when player is on Latter and vertivcal float is greater than 0
        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            //set gravity for player 0
            rb.gravityScale = 0f;
            //new speed is x velocity and vertical movement 
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            // set gravity back to normla
            rb.gravityScale = 4f;
        }
    }


    // check if Player is in Range of Ladder
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
