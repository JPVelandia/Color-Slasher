﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D bullet;
    GameObject player;
    float deathTime = 6f;

    private void Awake()
    {
        bullet = GetComponent<Rigidbody2D>();
        DestroyThisObject(deathTime);
    }

    void FixedUpdate()
    {
        bullet.AddRelativeForce(Vector2.up, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {

        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            player.GetComponent<PlayerLife>().TakeDamage(1);
            DestroyThisObject(0f);
        }
        else
        {
            DestroyThisObject(0f);
        }
    }

    public void DestroyThisObject(float deathTime)
    {
        Destroy(this.gameObject, deathTime);
    }
}
