using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerLife : Character, IObserverColor
{
    //  Jose was here
    //public delegate void Life(int currentLife);
    //public static event Life InRefreshLife;
    public static Action<int> InRefreshLife;
    public static Action InCharacterDied;

    [SerializeField] int startingHP = 3;

    void Start()
    {
        life = startingHP;
        InRefreshLife(life);
    }

    public override void TakeDamage(int damaged)
    {
        base.TakeDamage(damaged);

        InRefreshLife(life);
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
