using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerLife : Character, IObserverColor
{
    //  Jose was here
    //public delegate void Life(int currentLife);
    //public static event Life InRefreshLife;
    public static Action<int, int> InRefreshDamage;
    public static Action InCharacterDied;

    int maxHealth = 100;

    void Start()
    {
        health = maxHealth;
        InRefreshDamage(health, maxHealth);
    }

    public override void TakeDamage(int damaged)
    {
        base.TakeDamage(damaged);
        InRefreshDamage(health, maxHealth);
    }

    protected override void TriggerIsDead()
    {
        Invoke("CharacterDeath", 3f);
        InCharacterDied();
    }
    public void CharacterDeath()
    {
        IsDead = true;
        gameObject.SetActive(false);
    }

    public void ColorMechUpdate(ColorMech colorMech)
    {
        switch(colorMech)
        {
            case ColorMech.green:
            ActivateGreenPower();
            break;

            case ColorMech.red:
            ActivateRedPower();
            break;

            case ColorMech.black:
            TakeDamage(20);
            break;

            case ColorMech.white:
            DeactivatePower();
            break;
        }
    }

    void ActivateGreenPower()
    {

    }
    void ActivateRedPower()
    {

    }
    void DeactivatePower()
    {

    }
}
