using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Character : MonoBehaviour
{
    public static Action InGetHurt;

    public int life;
    protected bool IsDead{get;set;}

    protected virtual void Awake()
    {
        IsDead = false;
    }

    protected virtual void TriggerIsDead()
    {
        IsDead = true;
        gameObject.SetActive(false);
    }

    public virtual void TakeDamage(int damaged)
    {
        if(name != "Character") InGetHurt();

        life -= damaged;

        if(life <= 0)
        {
            TriggerIsDead();
        }
    }
}
