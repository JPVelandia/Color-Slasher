using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : Platform
{
    protected override void AssignName()
    {
        gameObject.name = "Floor";
    }
}
