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
    static Slider damageBar;

    void Awake()
    {
        currentSword = GetComponent<Image>();
        damageBar = GetComponentInParent<Slider>();

        PlayerLife.InRefreshDamage -= RefreshDamage;
        PlayerLife.InRefreshDamage += RefreshDamage;

        ColorMechUpdate(ColorMech.white);
        RefreshDamage(0);
    }

    public void RefreshDamage(int damage)
    {
        damageBar.value = damage;
    }

    public void ColorMechUpdate(ColorMech color)
    {
        if(currentSword == null) currentSword = GetComponent<Image>();

        Color newColor = new Color();
        int swordIndex = 4;

        switch(color)
        {
            case ColorMech.blue:
            newColor = Color.blue;
            swordIndex = 0;
            break;

            case ColorMech.green:
            newColor = Color.green;
            swordIndex = 1;
            break;

            case ColorMech.red:
            newColor = Color.red;
            swordIndex = 2;
            break;

            case ColorMech.yellow:
            newColor = Color.yellow;
            swordIndex = 3;
            break;

            case ColorMech.white:
            newColor = Color.white;
            swordIndex = 4;
            break;

            case ColorMech.black:
            newColor = Color.white;
            swordIndex = 4;
            break;
        }

        currentSword.sprite = swords[swordIndex];
        currentSword.color = newColor * new Vector4(1f,1f,1f,transparency);
    }
}
