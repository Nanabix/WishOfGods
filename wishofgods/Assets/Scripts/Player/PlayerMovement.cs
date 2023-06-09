using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public SpriteRenderer spriteRenderer;
    public PlayerInput playerControls;
    [SerializeField] private CapsuleCollider2D playerCollider;

    [Header("Basic Moving ")]
    public float speed;
    public float input;

    [Header("Aniamtion")]
    public Animator animator;
    // more animations later: https://www.youtube.com/watch?v=hkaysu1Z-N8&t=663s
    Vector2 moveDirection = Vector2.zero;
    private InputAction move;
    private InputAction jump;
    private InputAction fire;
    

    [Header ("Jump System")]
    [SerializeField] float jumpForce;
    [SerializeField] float fallMultiplier;
    [SerializeField] float jumpTime;
    [SerializeField] float jumpMultiplier;

    [Header("Ground Check")]
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public Transform feetPosition;
    public float groundCheckCircle;
    Vector2 vecGravity;
    
    
    bool isJumping;
    float jumpCounter;

    [Header("Ladder System")]
    private float vertical;
    private bool isLadder;
    private bool isClimbing;
    [SerializeField] float climbForce;

    public VectorValue startingPosition;
    private GameObject currentOneWayPlatform;
    

    // once called with start
    private void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        // Find the SpawnPoint game object in the current scene
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("spawnpoint");
        //set position of player to starting position
        transform.position = spawnPoint.transform.position;
    }
    private void Awake()
    {
        playerControls = new PlayerInput();
    }
    // Update is called once per frame
    void Update()
    {
       
        
 
        //one way plattform
        if (moveDirection.y < 0)
        {
            if(currentOneWayPlatform != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
        
        if (isLadder && moveDirection.y > 0)
        {
            isClimbing = true;
            Debug.Log("Start Klettern");
        }

    }

    // runs constantly 50 times/ sec
    void FixedUpdate()
    {

        moveDirection = move.ReadValue<Vector2>();
        animator.SetFloat("speed", Mathf.Abs(moveDirection.x));
        //flip sprite when Player moves in different direction

        if (moveDirection.x < 0)
        {
            spriteRenderer.flipX = false;

        }
        else if (moveDirection.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        if (playerRb.velocity.y < 0)
        {
            playerRb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
        if(playerRb.velocity.y>0 && isJumping)
        {
            playerRb.velocity += vecGravity * jumpMultiplier * Time.deltaTime;
        }

        //freeze player when Dialogue is playing
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            playerRb.velocity = Vector2.zero;
            return;
        }

        if (isClimbing)
        {
            //set gravity for player 0
            playerRb.gravityScale = 0f;
            //new speed is x velocity and vertical movement 
            playerRb.velocity = new Vector2(playerRb.velocity.x, moveDirection.y * speed);
        }
        else
        {
            // set gravity back to normla
            playerRb.gravityScale = 4f;
        }

        //move player
        //transform.position += new Vector3(input, 0, 0) * Time.deltaTime * speed;
        playerRb.velocity = new Vector2(moveDirection.x* speed, playerRb.velocity.y);
    }

    //in so new input system works
    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
        move.performed += Move;
 

        jump = playerControls.Player.jump;
        jump.Enable();
        jump.performed += Jump;

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
        fire.Disable();
    }

    //ground check
    private bool isGrounded()
    {   // is Player on Ground?
        // Create circle -> place cirlce at players feet -> make circle equa� to groundCheckCircle var -> do they overlap?
        return Physics2D.OverlapCapsule(feetPosition.position, new Vector2(0.42f, 0.14f), CapsuleDirection2D.Horizontal, 0, groundLayer); 
    }


    //check one way plattform 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
            Debug.Log("Leiter erkant");
        }
    }
        
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            Debug.Log("Leiter verlassen");
        }
    }

    //no collision with one way plattforms
    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }
     private void Move(InputAction.CallbackContext context)
    {
        // player doesn't stop when move.canceled
        /*
        moveDirection = move.ReadValue<Vector2>();
        animator.SetFloat("speed", Mathf.Abs(moveDirection.x));
        //flip sprite when Player moves in different direction

        if (moveDirection.x < 0)
        {
            spriteRenderer.flipX = false;

        }
        else if (moveDirection.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        */
        
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("hit");

    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("jump");
        // https://www.youtube.com/watch?v=XhwRYNie-aI
        if (isGrounded())
        {
            //playerRb.velocity = new Vector2(moveDirection.x * speed, jumpForce);
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            isJumping = true;
            jumpCounter = 0;
        }
        
       
       
    }
}
