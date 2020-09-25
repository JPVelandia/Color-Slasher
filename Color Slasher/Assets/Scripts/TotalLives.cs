using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TotalLives
{
    const int MAX_LIVES = 3;
    static int actualLives;

    public static int ActualLives { get => actualLives; }

    public static void ReduceLive()
    {
        actualLives--;
    }
    public static void RestartLives()
    {
        actualLives = MAX_LIVES;
    }
}