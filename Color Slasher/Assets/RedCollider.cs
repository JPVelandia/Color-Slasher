﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RedCollider : MonoBehaviour
{
    private Rigidbody2D rb;

    public LayerMask groundLayer;
    public Transform playerCheckPos;
    public bool isInside;
    public float radius = 0.5f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Power();
    }


    void Power()    
    {
        Collider2D redCollision = Physics2D.OverlapCircle(playerCheckPos.position, radius, groundLayer);
        isInside = redCollision != null;
        if (isInside == true)
        {
            Character elpepe = redCollision.gameObject.GetComponent<Character>();
            if (elpepe )
            {
                UnityEngine.Debug.LogWarning("Choca xd");
                elpepe.TakeDamage(10000);
            }
        }
    }
}
