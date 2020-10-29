using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageIndicators : MonoBehaviour
{
    static Image[] indicators;

    void Awake()
    {
        indicators = GetComponentsInChildren<Image>();

        FirstTime = true;

        EAttackDirect.InGetHurt += TriggerToEnemy;
        PlayerLife.InRefreshDamage += TriggerToCharacter;
    }

    static void TriggerToEnemy()
    {
        indicators[0].GetComponent<Animator>().SetTrigger("Play");
    }

    static void TriggerToCharacter(int i, int f)
    {
        Debug.Log("Awake " + FirstTime);
        if(!FirstTime) indicators[1].GetComponent<Animator>().SetTrigger("Play");
        FirstTime = false;
    }

    public static void UnsuscribeEvents()
    {
        EAttackDirect.InGetHurt -= TriggerToEnemy;
        PlayerLife.InRefreshDamage -= TriggerToCharacter;
    }

    static bool FirstTime{get; set;}
}
