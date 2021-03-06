﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ColorMech { black, blue, green, red, white, yellow }

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerLife))]

public class ColorMechanic : MonoBehaviour, ISubject
{
    #region Singleton

    //  With this it won't be necessary to give a GameObject to PowerUpCharacter from Platform.
    public static ColorMechanic instance;
    public static ColorMechanic Instance { get => instance; }

    void Awake()
    {
        //  Wheater there is already an instance...
        if (instance != null)
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
    LifeBar swordsHUD;
    PlayerTutorial playerTutorial;

    /*new*/
    [SerializeField] GameObject ParticlesGreen;
    [SerializeField] GameObject ParticlesYellow;
    [SerializeField] GameObject ParticlesRed;
    [SerializeField] GameObject ParticlesBlue;
    private bool IsActive = false;

    //  Get the references necessary to this code.
    void SetUp()
    {
        sr = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
        playerLife = GetComponent<PlayerLife>();
        

        try
        {
            playerTutorial = GetComponent<PlayerTutorial>();
        }
        catch { }

        heartsHUD = FindObjectOfType<Hearts>();
        swordsHUD = FindObjectOfType<LifeBar>();

        PlayerMovement.InDeactivatePower += PowerUp;
    }

    public void PowerUp(string platformName)
    {
        if (sr == null) sr = GetComponent<SpriteRenderer>();

        QuitPower();
        Notify();

        if (platformName == "Blue Platform")
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
        else if (platformName == "Black Platform")
        {
            BlackPower();
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

        /*new*/
        if (IsActive == false)
        {
            ParticlesBlue.SetActive(true);
            IsActive = true;
            StartCoroutine("TurnOff");            
        }
    }
    void GreenPower()
    {
        sr.color = Color.green;
        cm = ColorMech.green;

        /*new*/
        if (IsActive == false)
        {
            ParticlesGreen.SetActive(true);
            IsActive = true;
            StartCoroutine("TurnOff");
        }
    }
    void RedPower()
    {
        sr.color = Color.red;
        cm = ColorMech.red;

        /*new*/
        if (IsActive == false)
        {
            ParticlesRed.SetActive(true);
            IsActive = true;
            StartCoroutine("TurnOff");
        }
    }
    void YellowPower()
    {
        sr.color = Color.yellow;
        cm = ColorMech.yellow;

        /*new*/
        if (IsActive == false)
        {
            ParticlesYellow.SetActive(true);
            IsActive = true;
            StartCoroutine("TurnOff");
        }
    }
    void BlackPower()
    {
        sr.color = Color.white;
        cm = ColorMech.black;
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
        if (playerTutorial != null) playerTutorial.ColorMechUpdate(cm);

        heartsHUD.ColorMechUpdate(cm);
        swordsHUD.ColorMechUpdate(cm);
    }

    /*new*/
    IEnumerator TurnOff()
    {
        if (IsActive == true)
        {
            yield return new WaitForSeconds(1f);
            ParticlesGreen.SetActive(false);
            ParticlesBlue.SetActive(false);
            ParticlesRed.SetActive(false);
            ParticlesYellow.SetActive(false);
            IsActive = false;
        }
    }
}