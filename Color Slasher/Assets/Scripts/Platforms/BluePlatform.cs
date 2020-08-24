using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlatform : Platform
{
    protected override void AssignName()
    {
        gameObject.name = "Blue Platform";
    }
    protected override void AssignColor()
    {
        sr.color = Color.blue;
    }
}
