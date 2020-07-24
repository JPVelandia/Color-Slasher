using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //  Force applied to the slash movement.
    [SerializeField] float forceSwipe = 10f, frictionSwipe = 0.1f;

    Rigidbody2D rb;
    Vector3 startPos, finalPos;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        DirectionSwipe = Vector2.zero;

        IsGrounded = true;
        DoubleSwipe = false;
    }

    void FixedUpdate()
    {
        //  Gets the position where the screen is first touched.
        if(Input.GetButtonDown("Fire1"))
        {
            startPos = Input.mousePosition;
        }

        //  Gets the position where the screen is last touched.
        //  Let the player swipe if the character isGrounded (or gets the DoubleSwipe bonus).
        if((Input.GetButtonUp("Fire1")) && (IsGrounded || DoubleSwipe))
        {
            finalPos = Input.mousePosition;

            //  Calculate the distance between x and y components, and traduce it to values from 0 to 1. 
            Vector3 v = Vector3.Normalize(finalPos - startPos);
            //  Crops the Vector3 to Vector2
            DirectionSwipe = new Vector2(v.x, v.y);

            IsGrounded = false;

            //  Impulses this object in slash's direction.
            rb.AddForce(DirectionSwipe * forceSwipe, ForceMode2D.Impulse);
        }
        
        //  Toggles the gravity depending on wheater the character is moving and collides against a wall.
        rb.gravityScale = (IsGrounded)? 1:ActivateFriction();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        IsGrounded = true;
    }

    int ActivateFriction()
    {
        //  Aplies a force in the contrary direction of the swipe.
        rb.AddForce(-DirectionSwipe * (forceSwipe * frictionSwipe), ForceMode2D.Force);

        //  If the characters begins to fall, activate the gravity.
        if(rb.velocity.y <= 0) IsGrounded = true;

        return 0;
    }

    public bool IsGrounded {get; set;}
    public bool DoubleSwipe {get; set;}
    Vector2 DirectionSwipe {get; set;}
}
