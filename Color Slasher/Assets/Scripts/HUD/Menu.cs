using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] Slider music, soundFX;
    [SerializeField] Button mainMenu, restart;
    [SerializeField] Button pause, resume;
    [SerializeField] TextMeshProUGUI winNloseTxt;

    static Slider[] sliders = new Slider[2];
    static Button[] buttons = new Button[2];
    static Button[] pauses = new Button[2];

    static TextMeshProUGUI winNloseTxtS;

    MyCommand deployMenu;

void Awake()
    {
        sliders[0] = music;
        sliders[1] = soundFX;

        buttons[0] = mainMenu;
        buttons[1] = restart;

        pauses[0] = pause;
        pauses[1] = resume;

        winNloseTxtS = winNloseTxt;

        deployMenu = new CommDeployMenu(QueueMenuAssets());

        PlayerLife.InCharacterDied += Lose;
        Finish.InWin += Win;

        winNloseTxt.gameObject.SetActive(false);
        Resume();
    }

    static List<GameObject> QueueMenuAssets()
    {
        List<GameObject> menuAssets = new List<GameObject>();

        foreach(Slider obj in sliders) menuAssets.Add(obj.gameObject);
        foreach(Button obj in buttons) menuAssets.Add(obj.gameObject);

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

    public void Lose()
    {
        winNloseTxt.gameObject.SetActive(true);
        winNloseTxt.text = "You Lose!";
        winNloseTxt.color = Color.red;
        pauses[0].gameObject.SetActive(false);
        deployMenu.Execute();
        Time.timeScale = 0;
    }

    public void Win()
    {
        winNloseTxt.gameObject.SetActive(true);
        winNloseTxt.text = "You Win!";
        winNloseTxt.color = Color.green;
        pauses[0].gameObject.SetActive(false);
        deployMenu.Execute();
    }
}
