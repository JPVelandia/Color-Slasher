using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hearts : MonoBehaviour, IObserverColor
{
    Image heart;

    static TextMeshProUGUI livesText;

    void Awake()
    {
        heart = GetComponentInChildren<Image>();
        livesText = GetComponentInChildren<TextMeshProUGUI>();


        PlayerLife.InCharacterDied -= RefreshHearts;

        PlayerLife.InCharacterDied += RefreshHearts;

        RefreshHearts(TotalLives.ActualLives);
    }
    void RefreshHearts(int lives)
    {   
        livesText.text = "X " + lives;
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

        heart.color = newColor;
        livesText.color = newColor;
    }
}
