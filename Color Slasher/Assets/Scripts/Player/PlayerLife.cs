using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerLife : Character, IObserverColor
{
    //  Jose was here
    //public delegate void Life(int currentLife);
    //public static event Life InRefreshLife;
    public static Action<int, int> InRefreshDamage;
    public static Action<int> InCharacterDied;
    Animator anim;

    [SerializeField] Score score;

    int maxHealth = 100;

    public int Health { get => health; }

    new void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        health = maxHealth;
        InRefreshDamage(health, maxHealth);
    }

    public override void TakeDamage(int damaged)
    {
        base.TakeDamage(damaged);
        InRefreshDamage(health, maxHealth);
        anim.SetTrigger("Damaged");

        if (score.points > 0)
        {
            score.points = score.points - 100;
        }
    }
    public void Heal(int healing)
    {
        health = Mathf.Clamp(health + healing, 0, maxHealth);
    }

    protected override void TriggerIsDead()
    {
        Invoke("CharacterDeath", 3f);
        TotalLives.ReduceLive();
        InCharacterDied(TotalLives.ActualLives);
    }
    public void CharacterDeath()
    {
        IsDead = true;
        gameObject.SetActive(false);
    }

    public void ColorMechUpdate(ColorMech colorMech)
    {
        switch (colorMech)
        {
            case ColorMech.green:
                ActivateGreenPower(30);
                break;

            case ColorMech.black:
                TakeDamage(20);
                break;

            case ColorMech.white:
                DeactivatePower();
                break;
        }
    }

    void ActivateGreenPower(int healing)
    {
        Heal(healing);
        InRefreshDamage(health, maxHealth);
    }
    void DeactivatePower()
    {

    }
}