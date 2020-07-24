using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorfulPlatform : MonoBehaviour
{
    SpriteRenderer sr;
    System.Random rnd = new System.Random();
    [SerializeField] int state;

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
        Invoke("RandomNumber", 3f);
    }
    public void RedState()
    {
        sr.color = Color.red;
        gameObject.name = "Red Platform";
        Invoke("RandomNumber", 3f);
    }
    public void YellowState()
    {
        sr.color = Color.yellow;
        gameObject.name = "Yellow Platform";
        Invoke("RandomNumber", 3f);
    }
    public void GreennState()
    {
        sr.color = Color.green;
        gameObject.name = "Green Platform";
        Invoke("RandomNumber", 3f);
    }
    public void RandomNumber()
    {
        state = rnd.Next(1, 5);
        ChangeState();
    }
    public void ChangeState()
    {
        if (state == 1)
        {
            BlueState();
        }
        if (state == 2)
        {
            RedState();
        }
        if (state == 3)
        {
            YellowState();
        }
        if (state == 4)
        {
            GreennState();
        }
    }
}
