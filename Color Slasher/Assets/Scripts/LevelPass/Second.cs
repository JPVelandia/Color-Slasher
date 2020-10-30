using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Second : MonoBehaviour
{
    public void ThirdScene()
    {
        SceneManager.LoadScene(3);
    }
}
