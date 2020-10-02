using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlatform : Platform
{
    protected override void AssignName()
    {
        gameObject.name = "Green Platform";
    }
    protected override void AssignColor()
    {
        sr.color = Color.green;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.name = "Floor";
            gameObject.SetActive(false);    
        }
    }
}
