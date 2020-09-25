using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlatformSwitch : RedPlatform
{
    public int wallIndex;

    protected override void PowerUpCharacter()
    {
        base.PowerUpCharacter();
        OnSwitchTouch(wallIndex);
    }
}
