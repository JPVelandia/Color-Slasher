using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Pause : MonoBehaviour
{

    [SerializeField]
    GameObject[] assets;
    static GameObject[] assetS;

    Restart restart;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerLife.InCharacterDied -= Lose;
        Finish.InWin -= Win;

        PlayerLife.InCharacterDied += Lose;
        Finish.InWin += Win;

        restart = new Restart();

        assetS = assets;
        TurnOffAssets();
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("Home");
    }

    public void TurnOnAssets()
    {
        foreach (GameObject obj in assetS)
        {
            obj.SetActive(true);
        }

        assetS[5].SetActive(false);
        assetS[6].SetActive(false);
        assetS[7].SetActive(false);
        assetS[8].SetActive(false);

        Time.timeScale = 0;
    }

    public void TurnOffAssets()
    {
        foreach (GameObject obj in assetS)
        {
            obj.SetActive(false);
        }

        assetS[5].SetActive(true);
        assetS[6].SetActive(false);
        assetS[8].SetActive(false);

        Time.timeScale = 1;
    }

    public void Win()
    {
        TurnOnAssets();

        assetS[1].SetActive(false);
        assetS[8].SetActive(true);
        assetS[6].SetActive(true);

        assetS[6].GetComponent<TextMeshProUGUI>().text = "You made them sashimi!";
        assetS[6].GetComponent<TextMeshProUGUI>().color = Color.green;
    }
    public void Lose(int lives)
    {
        TurnOnAssets();

        assetS[1].SetActive(false);
        assetS[3].SetActive(false);
        assetS[7].SetActive(true);
        assetS[6].SetActive(true);

        assetS[6].GetComponent<TextMeshProUGUI>().text = "Oh no!\nYou were slashed!";
        assetS[6].GetComponent<TextMeshProUGUI>().color = Color.red;

        if (lives <= 0)
        {
            assetS[2].SetActive(false);

        }
    }

    public void Restart()
    {
        restart.RestartActiveScene();
    }

    public void ToBegin()
    {
        SceneManager.LoadScene(0);
    }

    public void ToContinue()
    {
        TurnOffAssets();
    }
}