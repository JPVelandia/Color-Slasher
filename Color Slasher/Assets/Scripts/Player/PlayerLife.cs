using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] int startingHP = 3, currentHP;

    void Start()
    {
        currentHP = startingHP;
    }
    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            LoseLife();
        }
    }

    public void LoseLife()
    {
        currentHP -= 1;

        if(currentHP == 0)
        {
            Invoke("CharacterDeath", 3f);
        }
    }
    public void CharacterDeath()
    {
        gameObject.SetActive(false);
    }
}
