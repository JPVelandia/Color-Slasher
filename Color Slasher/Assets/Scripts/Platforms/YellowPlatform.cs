﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlatform : Platform
{
    protected override void AssignName()
    {
        gameObject.name = "Yellow Platform";
    }
    protected override void AssignColor()
    {
        sr.color = Color.yellow;
    }
}
