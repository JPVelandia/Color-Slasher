﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCam : MonoBehaviour
{
    [SerializeField] GameObject cam1, cam2;


    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("oe");
        /*if (collision.gameObject.CompareTag("Player"))
        {
            cam2.SetActive(true);
            cam1.SetActive(false);
        }*/
    }
}
