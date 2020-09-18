using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart
{
    public void RestartActiveScene()
    {
        DamageIndicators.UnsuscribeEvents();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
