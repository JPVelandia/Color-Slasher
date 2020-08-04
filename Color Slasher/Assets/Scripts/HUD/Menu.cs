using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Slider music, soundFX;
    [SerializeField] Button mainMenu, restart;
    [SerializeField] Button pause, resume;

    static Slider[] sliders = new Slider[2];
    static Button[] buttons = new Button[2];
    static Button[] pauses = new Button[2];

    Command deployMenu;

void Awake()
    {
        sliders[0] = music;
        sliders[1] = soundFX;

        buttons[0] = mainMenu;
        buttons[1] = restart;

        deployMenu = new CommDeployMenu(QueueMenuAssets());

        PlayerLife.InCharacterDied += Lose;

        pauses[0] = pause;
        pauses[1] = resume;

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
        pauses[0].gameObject.SetActive(false);
        deployMenu.Execute();
        Time.timeScale = 0;
    }

    public void Win()
    {
        pauses[0].gameObject.SetActive(false);
        deployMenu.Execute();
    }
}
