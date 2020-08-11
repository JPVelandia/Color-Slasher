using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lips : EAttackDirect
{
    [SerializeField] GameObject parent;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerMovement pM = other.gameObject.GetComponent<PlayerMovement>();
            TakeDamage(0);
        }
    }

    protected override void TriggerIsDead() 
    {
        IsDead = true;
        parent.SetActive(false);
    } 

    protected override void Attack()
    {

    }
}
