using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    UISoundSystem mySoundSystem;
    void Awake()
    {
        mySoundSystem = gameObject.GetComponent<UISoundSystem>();
        Play();
        DontDestroyOnLoad(this.gameObject);
        Debug.LogWarning("Se reproduce");
    }
    void Play()
    {
        mySoundSystem.Action5();
    }
}
