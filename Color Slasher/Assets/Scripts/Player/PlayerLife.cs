using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerLife : MonoBehaviour, IObserver
{
    //  Jose was here
    public static Action<int> InRefreshLife;
    public static Action InCharacterDeath;

    [SerializeField] int startingHP = 3, currentHP;

    void Start()
    {
        currentHP = startingHP;
        InRefreshLife(currentHP);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            LoseLife();
        }
    }

    public void LoseLife()
    {
        currentHP -= 1;

        if(currentHP == 0)
        {
            Invoke("CharacterDeath", 3f);
            InCharacterDeath();
        }

        InRefreshLife(currentHP);
    }
    public void CharacterDeath()
    {
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
