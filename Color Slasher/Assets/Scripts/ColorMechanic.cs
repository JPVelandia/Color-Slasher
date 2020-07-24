using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ColorMech { blue, red, yellow, green, white }

public class ColorMechanic : MonoBehaviour
{
    SpriteRenderer sr;
    ColorMech cm;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Blue Platform")
        {
            sr.color = Color.blue;
            cm = ColorMech.blue;
        }
        if (collision.gameObject.name == "Red Platform")
        {
            sr.color = Color.red;
            cm = ColorMech.red;
        }
        if (collision.gameObject.name == "Yellow Platform")
        {
            sr.color = Color.yellow;
            cm = ColorMech.yellow;
        }
        if (collision.gameObject.name == "Green Platform")
        {
            sr.color = Color.green;
            cm = ColorMech.green;
        }
        if (collision.gameObject.name == "Floor")
        {
            sr.color = Color.white;
            cm = ColorMech.white;
        }
    }
}
