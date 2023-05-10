using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements.Experimental;

//Header
//Controls the player character (moving, jumping etc)
//Some of the script is from youtube video. Link here: https://www.youtube.com/watch?v=K1xZ-rycYY8 
//Header
public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true; //indicading is the player facing left or right
    public float puolittaja = 0.5f;
    public bool duobleJumpActive = GameManager.Instance.doubleJumpActive;

    //public GameManager gameManager;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Transform groundCheck; 
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {

        //duobleJumpActive = GameManager.Instance.doubleJumpActive;
        Debug.Log("Toimii");
 
    }
    void Update()
    {
        
        //Horizontal movement and jumping here 

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded() || Input.GetButtonDown("Jump") && duobleJumpActive) //When pressing jump-button player jumps
        {
            if (Input.GetButtonDown("Jump") && !IsGrounded())
            {
                duobleJumpActive = false;
            }

            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            AudioManager.instance.PlaySFX("Jump");

        }



        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) //This allows the player jump higher if jump button is pressed longer
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * puolittaja);

        }


        if(rb.velocity.y == 0f && GameManager.Instance.doubleJumpActive)
        {
            duobleJumpActive = true;
        }


        Flip();
        
    }

    private void FixedUpdate()  // the actual part that calculates the player movement
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded() //Check if player is grounded
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }

    private void Flip() //Flips the player so he is passing always moving direction
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}