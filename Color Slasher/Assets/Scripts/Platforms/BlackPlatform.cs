using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPlatform : Platform
{
    protected override void AssignName()
    {
        gameObject.name = "Black Platform";
    }
    protected override void AssignColor()
    {
        sr.color = Color.black;
    }
}
