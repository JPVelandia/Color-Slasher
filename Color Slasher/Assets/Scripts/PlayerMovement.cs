using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //  Force applied to the slash movement.
    [SerializeField] float slashForce = 10f;

    Rigidbody2D rigidbody2D;

    Vector3 startPos, finalPos;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //  Gets the position where the screen is first touched.
        if(Input.GetButtonDown("Fire1"))
        {
            startPos = Input.mousePosition;
        }

        //  Gets the position where the screen is last touched.
        if(Input.GetButtonUp("Fire1"))
        {
            finalPos = Input.mousePosition;

            //  Calculate the distance between x and y components, and traduce it to values from 0 to 1. 
            Vector3 v = Vector3.Normalize(finalPos - startPos);
            //  Crops the Vector3 to Vector2
            Vector2 v2 = new Vector2(v.x, v.y);

            //  Impulses this object in slash's direction.
            rigidbody2D.AddForce(v2 * slashForce, ForceMode2D.Impulse);
        }
    }
}
