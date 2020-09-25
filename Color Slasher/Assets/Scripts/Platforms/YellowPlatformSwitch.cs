using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlatformSwitch : YellowPlatform
{
    public int wallIndex;

    protected override void PowerUpCharacter()
    {
        base.PowerUpCharacter();
        OnSwitchTouch(wallIndex);
    }
}
