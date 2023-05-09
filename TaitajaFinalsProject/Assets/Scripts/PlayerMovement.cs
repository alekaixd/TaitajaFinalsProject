using UnityEngine;
using UnityEngine.UIElements.Experimental;

//Header
//Controls the player character (moving, jumping etc)
//Header
public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true; //indicading is the player facing left or right

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Transform groundCheck; 
    [SerializeField] private LayerMask groundLayer; 


    [SerializeField] private AudioSource JumpSoundEffect;

    void Update()
    {
        //Horizontal movement and jumping here 

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded()) //When pressing jump-button player jumps
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            AudioManager.instance.PlaySFX("Jump");

        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) //This allows the player jump higher if jump button is pressed longer
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            JumpSoundEffect.Play();
        }

        Flip();
    }

    private void FixedUpdate()  // the actual part that calculates the player movement
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded() //Check if player is grounded
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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