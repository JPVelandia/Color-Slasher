using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int life;
    protected bool IsDead{get;set;}

    void Awake()
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
        life -= damaged;

        if(life <= 0)
        {
            TriggerIsDead();
        }
    }
}
