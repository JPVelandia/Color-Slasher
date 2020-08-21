using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Finish : MonoBehaviour
{
    public static Action InWin;

    /*
    [SerializeField]
    GameObject winText;
    // Start is called before the first frame update
    void Start()
    {
//        winText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InWin();
        }
    }
}
