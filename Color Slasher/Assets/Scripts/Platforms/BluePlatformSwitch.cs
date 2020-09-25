using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlatformSwitch : BluePlatform
{
    public int wallIndex;

    protected override void PowerUpCharacter()
    {
        base.PowerUpCharacter();
        OnSwitchTouch(wallIndex);
    }
}
