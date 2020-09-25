using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Platform : MonoBehaviour
{
    protected SpriteRenderer sr;
    protected abstract void AssignName();
    protected abstract void AssignColor();

    public static Action<int> OnSwitchTouch;

    void Awake()
    {
        //sr = GetComponent<SpriteRenderer>();

        AssignName();
        //AssignColor();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player")) 
        {
            PowerUpCharacter();
        }
    }

    protected virtual void PowerUpCharacter()
    {
        ColorMechanic.Instance.PowerUp(name);
    }
}
