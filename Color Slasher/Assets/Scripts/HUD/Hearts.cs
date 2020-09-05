using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour, IObserverColor
{
    static Image[] hearts;

    void Awake()
    {
        hearts = GetComponentsInChildren<Image>();

        PlayerLife.InRefreshDamage -= RefreshHearts;

        PlayerLife.InRefreshDamage += RefreshHearts;

        TurnOffHearts();
    }

    void RefreshHearts(int hearts, int holi)
    {        
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

    public void ColorMechUpdate(ColorMech color)
    {
        Color newColor = new Color();

        switch(color)
        {
            case ColorMech.blue:
            newColor = Color.blue;
            break;

            case ColorMech.green:
            newColor = Color.green;
            break;

            case ColorMech.red:
            newColor = Color.red;
            break;

            case ColorMech.yellow:
            newColor = Color.yellow;
            break;

            case ColorMech.white:
            newColor = Color.white;
            break;

            case ColorMech.black:
            newColor = Color.white;
            break;
        }

        foreach(Image heart in Hearts.hearts)
        {
            heart.color = newColor;
        }
    }
}
