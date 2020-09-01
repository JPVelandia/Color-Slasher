using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EAttackDirect : Character
{
    protected float timeBetweenAttacks;

    protected abstract void Attack();
}
