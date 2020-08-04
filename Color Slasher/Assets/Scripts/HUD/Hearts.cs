﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour, ISubject
{
    static Image[] hearts;

    [SerializeField] GameObject restartBtn;
    static GameObject restartBtnSt;

    Menu menu;

    void Awake()
    {
        hearts = GetComponentsInChildren<Image>();

        PlayerLife.InRefreshLife += RefreshHearts;
        PlayerLife.InCharacterDeath += ToggleRestart;

        //Starts with HUD deactivated.
        restartBtnSt = restartBtn;
        ToggleRestart(false);
        TurnOffHearts();
    }

    void RefreshHearts(int hearts)
    {
        if(hearts <= 0) Notify();
        
        TurnOffHearts();

        //  Activate the number of hearts given.
        for(int i = 0; i < hearts; i++)
        {
            Hearts.hearts[i].gameObject.SetActive(true);
        }
    }

    void TurnOffHearts()
    {
        //  Deactivates al hearts.
        foreach(Image heart in Hearts.hearts)
        {
            heart.gameObject.SetActive(false);
        }
    }

    //  This function responses to PlayerLife's call, who is empty.
    void ToggleRestart()
    {
        ToggleRestart(true);
    }
    void ToggleRestart(bool state)
    {
        restartBtnSt.SetActive(state);
    }

    public void Notify()
    {
        menu.SubjectUpdate();
    }
}
