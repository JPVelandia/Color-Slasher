using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swords : MonoBehaviour, IObserverColor
{
    [Header("Transparency of swords in HUD")]
    [SerializeField] float transparency = 0.8f;

    [Header("Swords of each color (alphabetical order)")]
    [SerializeField] Sprite[] swords = new Sprite[5];

    static Image currentSword;
    static Image[] swordsImages;

    void Awake()
    {
        currentSword = GetComponent<Image>();
        swordsImages = GetComponentsInChildren<Image>();

        PlayerLife.InRefreshDamage -= RefreshDamage;
        PlayerLife.InRefreshDamage += RefreshDamage;

        ColorMechUpdate(ColorMech.white);
        RefreshDamage(0, 100);
    }

    public void RefreshDamage(int health, int maxHealth)
    {

        swordsImages[1].fillAmount = (float)health / (float)maxHealth;
    }

    public void ColorMechUpdate(ColorMech color)
    {
        if(currentSword == null) currentSword = GetComponent<Image>();

        Color frontColor = new Color();
        Color backColor = new Color();
        int swordIndex = 4;

        switch(color)
        {
            case ColorMech.blue:
            frontColor = Color.blue;
            backColor = Color.yellow;
            swordIndex = 0;
            break;

            case ColorMech.green:
            frontColor = Color.green;
            backColor = Color.magenta;
            swordIndex = 1;
            break;

            case ColorMech.red:
            frontColor = Color.red;
            backColor = Color.cyan;
            swordIndex = 2;
            break;

            case ColorMech.yellow:
            frontColor = Color.yellow;
                backColor = Color.blue;
            swordIndex = 3;
            break;

            case ColorMech.white:
            frontColor = Color.white;
            backColor = Color.black;
            swordIndex = 4;
            break;

            case ColorMech.black:
            frontColor = Color.white;
            backColor = Color.black;
            swordIndex = 4;
            break;
        }

        swordsImages[0].sprite = swords[swordIndex];
        swordsImages[1].sprite = swords[swordIndex];
        swordsImages[0].color = backColor;
        swordsImages[1].color = frontColor * new Vector4(1f,1f,1f,transparency);
    }
}
