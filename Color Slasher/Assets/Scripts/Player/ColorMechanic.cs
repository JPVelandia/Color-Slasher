using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ColorMech { blue, red, yellow, green, white }

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerLife))]
public class ColorMechanic : MonoBehaviour, ISubject
{
    #region Singleton

    //  With this it won't be necessary to give a GameObject to PowerUpCharacter from Platform.

    #endregion

    SpriteRenderer sr;
    ColorMech cm;
    PlayerMovement playerMovement;
    PlayerLife playerLife;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
        playerLife = GetComponent<PlayerLife>();

        PlayerMovement.InDeactivatePower += QuitPower;
    }

    public void PowerUp(string platformName)
    {
        QuitPower();

        if(platformName == "Blue Platform")
        {
            BluePower();
        }
        else if (platformName == "Red Platform")
        {
            RedPower();
        }
        else if (platformName == "Yellow Platform")
        {
            YellowPower();
        }
        else if (platformName == "Green Platform")
        {
            GreenPower();
        }
        else if (platformName == "Floor")
        {
            QuitPower();
        }

        Notify();
    }

    void BluePower()
    {
        sr.color = Color.blue;
        cm = ColorMech.blue;
    }
    void GreenPower()
    {
        sr.color = Color.green;
        cm = ColorMech.green;
    }
    void RedPower()
    {
        sr.color = Color.red;
        cm = ColorMech.red;
    }
    void YellowPower()
    {
        sr.color = Color.yellow;
        cm = ColorMech.yellow;
    }
    void QuitPower()
    {
        sr.color = Color.white;
        cm = ColorMech.white;
    }

    public void Notify()
    {
        playerMovement.ColorMechUpdate(cm);
        playerLife.ColorMechUpdate(cm);
    }
}
