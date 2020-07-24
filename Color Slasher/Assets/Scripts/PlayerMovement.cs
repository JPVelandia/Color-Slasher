using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //  Force applied to the slash movement | 
    //  Friction applied to the slash (contrary to DirectionSwipe) | 
    //  Seconds the character remains without falling when touches a platform.
    [SerializeField] float forceSwipe = 10f, frictionSwipe = 1f, secondsGrab = 3f;

    //  Debug variables. Code works with Properties.
    public bool canSwipe, doubleSwipe, falling;

    Rigidbody2D rb;
    Vector3 startPos, finalPos;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        DirectionSlash = Vector2.zero;

        IsGrounded = false;
        IsFalling = true;

        DoubleSwipe = false;
    }

    void FixedUpdate()
    {
        //  Toggles the gravity depending on wheater the character is moving.
        rb.gravityScale = (IsFalling)? 1:ActivateFriction();

        //  Gets the position where the screen is first touched.
        if(Input.GetButtonDown("Fire1"))
        {
            startPos = Input.mousePosition;
        }

        //  Gets the position where the screen is last touched.
        //  ACTIVATES SLASH
        //  Let the character slash if isGrounded (or gets the DoubleSwipe bonus).
        if((Input.GetButtonUp("Fire1")) && (IsGrounded || DoubleSwipe))
        {
            //StopAllCoroutines();
            IsGrounded = false;
            IsFalling = false;
            finalPos = Input.mousePosition;

            //  Calculate the distance between x and y components, then traduces it to values from 0 to 1. 
            Vector3 v = Vector3.Normalize(finalPos - startPos);
            //  Crops the Vector3 to Vector2
            DirectionSlash = new Vector2(v.x, v.y);

            //  Impulses this object in slash's direction.
            rb.AddForce(DirectionSlash * forceSwipe, ForceMode2D.Impulse);
        }
    }

    int ActivateFriction()
    {
        //  Friction will be applied when character not IsGrounded.
        if(!IsGrounded) 
        {
            //  Applies a force contrary to DirectionSlash's direction.
            rb.AddForce(-DirectionSlash * (forceSwipe * frictionSwipe), ForceMode2D.Force);

            //  If the character loses all it's upping energy, start to fall.
            if(rb.velocity.y <= 0) IsFalling = true;
        }

        return 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //  Whenever touches a paltform can slash again.
        IsGrounded = true;

        StartCoroutine(Grab());
    }

    //  When touches a platform doesn't fall de inmediaty.
    IEnumerator Grab()
    {
        //  Stops whet get to a platform.
        rb.velocity = Vector2.zero;

        // Waits certain time to fall.
        yield return new WaitForSeconds(secondsGrab);

        IsFalling = true;
    }

    public bool IsGrounded {get => canSwipe; set => canSwipe = value;}
    public bool IsFalling {get => falling; set => falling = value;}
    public bool DoubleSwipe {get => doubleSwipe; set => doubleSwipe = value;}
    Vector2 DirectionSlash {get; set;}
}
