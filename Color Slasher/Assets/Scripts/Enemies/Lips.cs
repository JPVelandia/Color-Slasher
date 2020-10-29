using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lips : EAttackDirect
{
    [SerializeField] GameObject parent;
    CircleCollider2D myCircleColl2D;
    BoxCollider2D myBoxColl2D;

    private void Awake()
    {
        myCircleColl2D = GetComponent<CircleCollider2D>();
        myBoxColl2D = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerMovement pM = other.gameObject.GetComponent<PlayerMovement>();
            TakeDamage(pM.damage);
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
