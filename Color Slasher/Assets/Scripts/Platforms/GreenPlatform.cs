using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlatform : Platform
{
    [SerializeField] GameObject whiteplat;
    protected override void AssignName()
    {
        gameObject.name = "Green Platform";
    }
    protected override void AssignColor()
    {
        sr.color = Color.green;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //gameObject.name = "Floor";
            gameObject.SetActive(false);
            whiteplat.SetActive(true);
        }
    }
}
