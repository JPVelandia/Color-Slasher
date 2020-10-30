using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialFunction : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TutText;
    [SerializeField] GameObject TutStuff, firstTitle;

    private void Awake()
    {
    }

    private void Start()
    {
        TutStuff.SetActive(false);
        firstTitle.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BlueTut"))
        {
            TutText.text = "The blue power up allows you to double jump!";
            TutStuff.SetActive(true);
            Time.timeScale = 0;
        }
        if (collision.gameObject.CompareTag("YellowTut"))
        {
            TutText.text = "The yellow power up makes you able to slash faster!";
            TutStuff.SetActive(true);
            Time.timeScale = 0;
        }
        if (collision.gameObject.CompareTag("GreenTut"))
        {
            TutText.text = "The green power up helps you to heal up a bit!";
            TutStuff.SetActive(true);
            Time.timeScale = 0;
        }
        if (collision.gameObject.CompareTag("RedTut"))
        {
            TutText.text = "The red power up creates an explosion around you!";
            TutStuff.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ClickOff()
    {
        TutStuff.SetActive(false);
        firstTitle.SetActive(false);
        Time.timeScale = 1;
    }
}
