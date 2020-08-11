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
    public static ColorMechanic instance;
    public static ColorMechanic Instance {get => instance;}

    void Awake()
    {
        //  Wheater there is already an instance...
        if(instance != null) 
        {
            //  delete it and create a new one.
            Destroy(instance);
            instance = new ColorMechanic();
        }
        instance = this;

        SetUp();
    }
    #endregion

    static SpriteRenderer sr;
    ColorMech cm;
    PlayerMovement playerMovement;
    PlayerLife playerLife;
    Hearts heartsHUD;
    Swords swordsHUD;

    //  Get the references necessary to this code.
    void SetUp()
    {
        sr = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
        playerLife = GetComponent<PlayerLife>();

        heartsHUD = FindObjectOfType<Hearts>();
        swordsHUD = FindObjectOfType<Swords>();

        PlayerMovement.InDeactivatePower += PowerUp;
    }

    public void PowerUp(string platformName)
    {
        if(sr == null) sr = GetComponent<SpriteRenderer>();

        QuitPower();
        Notify();

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

        heartsHUD.ColorMechUpdate(cm);
        swordsHUD.ColorMechUpdate(cm);
    }
}
