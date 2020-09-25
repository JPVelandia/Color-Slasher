using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] Button mainMenuBtn, restartBtn;
    [SerializeField] Button pauseBtn, resumeBtn;
    [SerializeField] Slider musicSld, soundFXSld;
    [SerializeField] TextMeshProUGUI winNloseTxt;

    static Button[] buttons = new Button[2];
    static Button[] pauses = new Button[2];
    static Slider[] sliders = new Slider[2];
    static TextMeshProUGUI winNloseTxtS;

    MyCommand deployMenu;

    void Awake()
    {
        sliders[0] = musicSld;
        sliders[1] = soundFXSld;

        buttons[0] = mainMenuBtn;
        buttons[1] = restartBtn;

        pauses[0] = pauseBtn;
        pauses[1] = resumeBtn;

        winNloseTxtS = winNloseTxt;

        deployMenu = new CommDeployMenu(QueueMenuAssets());

        PlayerLife.InCharacterDied -= Lose;
        Finish.InWin -= Win;

        PlayerLife.InCharacterDied += Lose;
        Finish.InWin += Win;

        winNloseTxt.gameObject.SetActive(false);
        Resume();
    }

    static List<GameObject> QueueMenuAssets()
    {
        List<GameObject> menuAssets = new List<GameObject>();

        foreach (Slider obj in sliders) menuAssets.Add(obj.gameObject);
        foreach (Button obj in buttons) menuAssets.Add(obj.gameObject);

        return menuAssets;
    }

    public void Pause()
    {
        pauses[0].gameObject.SetActive(false);
        pauses[1].gameObject.SetActive(true);
        deployMenu.Execute();
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauses[0].gameObject.SetActive(true);
        pauses[1].gameObject.SetActive(false);
        deployMenu.Unexecute();
    }

    public void Lose(int i)
    {
        if (winNloseTxtS != null)
        {
            winNloseTxtS.gameObject.SetActive(true);
            winNloseTxtS.text = "You Lose!";
            winNloseTxtS.color = Color.red;
        }
        pauses[0].gameObject.SetActive(false);
        deployMenu.Execute();
        Time.timeScale = 0;
    }

    public void Win()
    {
        if (winNloseTxtS != null)
        {
            winNloseTxtS.gameObject.SetActive(true);
            winNloseTxtS.text = "You Win!";
            winNloseTxtS.color = Color.green;
        }
        pauses[0].gameObject.SetActive(false);
        deployMenu.Execute();
    }
}