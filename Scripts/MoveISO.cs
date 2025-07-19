using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveISO : MonoBehaviour
{

    public UnityEvent Dead;
    private Rigidbody2D rb;
    public float speed = 5f;
    private float horizontalInput;
    private float verticalInput;
    private bool right = true;
    private float moveInput;
    public static bool facing; 


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);


        if (movementDirection.magnitude > 1)
        {
            movementDirection = movementDirection.normalized;
        }
        if (right == false && horizontalInput > 0)
        {
            facing = false;
            Flip();
        }
        else if (right == true && horizontalInput < 0)
        {
            facing = true;
            Flip();
        }


        rb.AddForce(movementDirection * speed, ForceMode2D.Force);
    }
    private void Flip()
    {

        right = !right;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}