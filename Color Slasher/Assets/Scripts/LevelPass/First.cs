using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class First : MonoBehaviour
{
    public void SecondScene()
    {
        SceneManager.LoadScene(2);
    }
}
