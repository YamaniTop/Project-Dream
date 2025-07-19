using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class move : MonoBehaviour
{
    public UnityEvent Dead;
    private Rigidbody2D rb;
    public float speed = 1f;
    public float jump = 1f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;
    private bool isGrounded;
    private float horizontalInput; 

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        
        horizontalInput = Input.GetAxis("Horizontal");

        
        rb.AddForce(Vector2.right * horizontalInput * speed, ForceMode2D.Force);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionObject = collision.gameObject;

        if (collisionObject.CompareTag("death"))
        {

            Dead?.Invoke();
        }
    }
}
