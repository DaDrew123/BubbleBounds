using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Sprite idleSprite;
    public Sprite jumpSprite;
    public Sprite anticSprite;

    private SpriteRenderer spriteRenderer;

    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float jumpCooldown = 0.5f;  // Cooldown time in seconds

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isFloating = false;  // Track if the player is floating

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float floatingForce = 2f;   // Force applied to make the player float

    AudioManager audioManager;

    private float nextJumpTime = 0f;  // Tracks when the player can jump next

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {     
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

        rb.freezeRotation = true;

        // If the player is floating, reduce gravity
        if (isFloating)
        {
            rb.gravityScale = 0.5f;  // Lower gravity to make the player float
        }
        else
        {
            rb.gravityScale = 1f;   // Reset gravity to normal
        }
    }

    void Move()
    {
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
        }

        // Move the player left or right
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Jump Anim
        if (!isGrounded){ 
            spriteRenderer.sprite = jumpSprite;
        }
        else if(isGrounded){
            spriteRenderer.sprite = idleSprite; 
        }
        else{
            spriteRenderer.sprite = anticSprite;
        }
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Jump only if grounded and the cooldown has passed
        if (isGrounded && Time.time >= nextJumpTime && Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            nextJumpTime = Time.time + jumpCooldown;  // Set the next available jump time
            audioManager.PlaySFX(audioManager.jumpSound);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FloatingBubble"))
        {
            isFloating = true;   // Start floating when the player enters the trigger zone
        }
    }

    // Trigger detection when exiting the floating area
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("FloatingBubble"))
        {
            isFloating = false;  // Stop floating when the player exits the trigger zone
        }
    }

    

}
