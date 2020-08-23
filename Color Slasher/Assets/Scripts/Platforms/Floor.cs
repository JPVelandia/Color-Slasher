using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : Platform
{
    protected override void AssignName()
    {
        gameObject.name = "Floor";
    }
    protected override void AssignColor()
    {
        sr.color = Color.white;
    }
}
