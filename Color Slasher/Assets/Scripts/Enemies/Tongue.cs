using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : EAttackDirect
{
    Character player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerMovement pM = other.gameObject.GetComponent<PlayerMovement>();
            if(!pM.IsGrounded) TakeDamage(pM.damage);
            else
            {
                player = (other.GetComponent<PlayerLife>() as Character);
                Attack();
            }
        }
    }

    protected override void Attack()
    {
        player.TakeDamage(damage);
    }
}
