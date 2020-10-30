using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPass : MonoBehaviour
{
    public void SecondScene()
    {
        SceneManager.LoadScene(2);
    }
}
