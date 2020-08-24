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
}
