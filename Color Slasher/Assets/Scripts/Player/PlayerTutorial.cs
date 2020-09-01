using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorial : MonoBehaviour, IObserverColor
{
    [SerializeField] GameObject[] platformExplanations;
    [SerializeField] GameObject skipButton;
    [SerializeField] float timeToActiveSkip = 0.5f;
    static GameObject[] _platformExplanations;

    bool[] touchedColor;

    private void Awake()
    {
        _platformExplanations = platformExplanations;

        touchedColor = new bool[6];

        for(int i = 0; i < touchedColor.Length; i++)
        {
            touchedColor[i] = false;
        }

        TurnOffExplanations();
    }

    public void ColorMechUpdate(ColorMech color)
    {
        if(touchedColor[(int)color] == false)
        { 
            _platformExplanations[(int)color].SetActive(true);
            touchedColor[(int)color] = true;

            Invoke("ActiveSkipButton", timeToActiveSkip);
            Time.timeScale = 0;
        }
    }

    private void ActiveSkipButton()
    {
        skipButton.SetActive(true);
    }

    public void TurnOffExplanations()
    {
        Time.timeScale = 1;

        skipButton.SetActive(false);

        foreach(GameObject gO in platformExplanations)
        {
            gO.SetActive(false);
        }
    }
}
