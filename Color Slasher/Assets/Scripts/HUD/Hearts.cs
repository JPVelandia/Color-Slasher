using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    Image[] hearts;

    void Awake()
    {
        hearts = GetComponentsInChildren<Image>();

        
    }

    void RefreshHearts(int hearts)
    {
        foreach(Image heart in this.hearts)
        {
            heart.gameObject.SetActive(false);
        }

        for(int i = 0; i < hearts; i++)
        {
            this.hearts[i].gameObject.SetActive(true);
        }
    }
}
