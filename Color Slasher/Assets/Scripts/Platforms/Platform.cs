using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platform : MonoBehaviour
{
    protected abstract void AssignName();

    void Awake()
    {
        AssignName();
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
