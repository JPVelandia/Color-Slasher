using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour, IObserverColor
{
    [Header("Icons for each power (alphabetical order)")]
    [SerializeField] Sprite[] icons = new Sprite[5];
    static Image[] damageBar;

    void Awake()
    {
        damageBar = GetComponentsInChildren<Image>();

        PlayerLife.InRefreshDamage -= RefreshDamage;
        PlayerLife.InRefreshDamage += RefreshDamage;

        ColorMechUpdate(ColorMech.white);
        RefreshDamage(0, 100);
    }

    public void RefreshDamage(int health, int maxHealth)
    {

        damageBar[1].fillAmount = (float)health / (float)maxHealth;
    }

    public void ColorMechUpdate(ColorMech color)
    {
        Image currentIcon = damageBar[damageBar.Length - 2];
        Color frontColor = new Color();
        Color backColor = new Color();
        int iconIndex = 4;

        //if(currentIcon == null) currentIcon = GetComponent<Image>();

        switch (color)
        {
            case ColorMech.blue:
                frontColor = Color.blue;
                backColor = Color.yellow;
                iconIndex = 0;
                break;

            case ColorMech.green:
                frontColor = Color.green;
                backColor = Color.magenta;
                iconIndex = 1;
                break;

            case ColorMech.red:
                frontColor = Color.red;
                backColor = Color.cyan;
                iconIndex = 2;
                break;

            case ColorMech.yellow:
                frontColor = Color.yellow;
                backColor = Color.blue;
                iconIndex = 3;
                break;

            case ColorMech.white:
                frontColor = Color.white;
                backColor = Color.black;
                iconIndex = 4;
                break;

            case ColorMech.black:
                frontColor = Color.white;
                backColor = Color.black;
                iconIndex = 4;
                break;
        }

        foreach (Image img in damageBar)
        {
            img.color = frontColor;
        }

        currentIcon.sprite = icons[iconIndex];
    }
}