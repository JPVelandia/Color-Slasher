using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : EAttackDirect
{
    Character player;
    ParticleSystem deathParticle;

    protected override void Awake()
    {
        base.Awake();

        deathParticle = GetComponentInChildren<ParticleSystem>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerMovement pM = other.gameObject.GetComponent<PlayerMovement>();
            if(!pM.IsGrounded) 
            {
                TakeDamage(pM.damage);
            }
            else
            {
                player = (other.GetComponent<PlayerLife>() as Character);
                Attack();
            }
        }
    }

    protected override void TriggerIsDead()
    {
        Time.timeScale = 0.5f;
        deathParticle.Play();
        Invoke("TotalDeath", deathParticle.main.duration);
    }

    void TotalDeath()
    {
        base.TriggerIsDead();
        Time.timeScale = 1f;
    }

    protected override void Attack()
    {
        player.TakeDamage(damage);
    }
}
