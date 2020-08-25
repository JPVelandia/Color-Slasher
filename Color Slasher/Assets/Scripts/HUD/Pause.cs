using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    [SerializeField]
    GameObject[] assets;
    static GameObject[] assetS;
    // Start is called before the first frame update
    void Awake()
    {
        assetS = assets;
        TrunOffAssets();
    }
  
    public void GoMenu()
    {
        Debug.Log("Click");
        SceneManager.LoadScene("Home");
    }

    public void TrunOnAssets()
    {
        foreach (GameObject obj in assetS)
        {
            obj.SetActive(true);
        }

        assetS[2].SetActive(false);
    }

    public void TrunOffAssets()
    {
        foreach (GameObject obj in assetS)
        {
            obj.SetActive(false);
        }

        assetS[2].SetActive(true);
    }
}
