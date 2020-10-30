using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class UImanager : MonoBehaviour
{
    [SerializeField] RectTransform Phrase;

    // Start is called before the first frame update
    void Start()
    {
        Phrase.DOAnchorPos(Vector2.zero, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
