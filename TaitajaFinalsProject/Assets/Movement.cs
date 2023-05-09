using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontal;
    public float Speed = 5f;
    public float jumpForce = 10f;
    private bool isFacingRight = true;


    private Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;


    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        /*if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
             //rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
             rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
         }*/
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }


        //rb.velocity = new Vector2 (horizontal * Speed, rb.velocity.y);

        rb.MovePosition(rb.velocity + rb.velocity * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
        
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
    }

}
