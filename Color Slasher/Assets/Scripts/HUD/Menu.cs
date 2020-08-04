using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour, IObserverHUD
{
    [SerializeField] Slider music, soundFX;
    [SerializeField] Button mainMenu, restart;

    public void SubjectUpdate()
    {
        gameObject.SetActive(true);
    }
}
