using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : EAttackDirect
{
    [Header("Slow motion when kills this enemy")]
    public bool killCam = true;

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
        if(killCam) Time.timeScale = 0.5f;
        deathParticle.Play();
        Invoke("TotalDeath", deathParticle.main.duration);
        //por alguna razón, count se resetea a 0 cada frame, hasta un máximo de 6 veces, tras eso, por fin suma 1
        //count = count + 1;
        //Debug.Log(" " + count);
    }

    void TotalDeath()
    {
        base.TriggerIsDead();
        Time.timeScale = 1f;
    }

    protected override void Attack()
    {
        player.TakeDamage(health);
    }
}
