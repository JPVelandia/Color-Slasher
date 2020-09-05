using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Character : MonoBehaviour
{
    public static Action InGetHurt;

    public int health;
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
        if (name != "Character")
        {
            InGetHurt();

            health -= damaged;
        }
        if(health <= 0)
        {
            TriggerIsDead();
        }
    }
}
