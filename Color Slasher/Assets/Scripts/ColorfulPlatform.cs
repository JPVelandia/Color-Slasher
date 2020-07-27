using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorfulPlatform : MonoBehaviour
{
    SpriteRenderer sr;
    System.Random rnd = new System.Random();
    [SerializeField] int state;
    bool blue = false, red = false, yellow = false, green = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        RandomNumber();
    }

    void Update()
    {

    }

    public void BlueState()
    {
        sr.color = Color.blue;
        gameObject.name = "Blue Platform";
        blue = true;
        red = false;
        yellow = false;
        green = false;
        Invoke("RandomNumber", 3f);
    }
    public void RedState()
    {
        sr.color = Color.red;
        gameObject.name = "Red Platform";
        blue = false;
        red = true;
        yellow = false;
        green = false;
        Invoke("RandomNumber", 3f);
    }
    public void YellowState()
    {
        sr.color = Color.yellow;
        gameObject.name = "Yellow Platform";
        blue = false;
        red = false;
        yellow = true;
        green = false;
        Invoke("RandomNumber", 3f);
    }
    public void GreenState()
    {
        sr.color = Color.green;
        gameObject.name = "Green Platform";
        blue = false;
        red = false;
        yellow = false;
        green = true;
        Invoke("RandomNumber", 3f);
    }
    public void RandomNumber()
    {
        state = rnd.Next(1, 5);
        Debug.Log(state);
        ChangeState();
    }
    public void ChangeState()
    {
        if(blue == false)
        {
            if (state == 1)
            {
                BlueState();
            }
        }
        else if(blue == true && state == 1)
        {
            RandomNumber();
        }

        if(red == false)
        {
            if (state == 2)
            {
                RedState();
            }
        }
        else if (red == true && state == 2)
        {
            RandomNumber();
        }

        if (yellow == false)
        {
            if (state == 3)
            {
                YellowState();
            }
        }
        else if (yellow == true && state == 3)
        {
            RandomNumber();
        }

        if (green == false)
        {
            if (state == 4)
            {
                GreenState();
            }
        }
        else if (green == true && state == 4)
        {
            RandomNumber();
        }
    }
}
