using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dominator : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {

        }
    }
}
