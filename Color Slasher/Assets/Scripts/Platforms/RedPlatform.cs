﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlatform : Platform
{
    protected override void AssignName()
    {
        gameObject.name = "Red Platform";
    }
    protected override void AssignColor()
    {
        sr.color = Color.red;
    }
}
