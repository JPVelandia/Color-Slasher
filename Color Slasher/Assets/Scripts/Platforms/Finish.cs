using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public static Action InWin;

    /*
    [SerializeField]
    GameObject winText;
    // Start is called before the first frame update
    void Start()
    {
//        winText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InWin();

            int caseSwitch = 1;

            switch (caseSwitch)
            {
                case 1:
                    SceneManager.LoadScene(2);
                    break;
                case 2:
                    SceneManager.LoadScene(3);
                    break;
                case 3:
                    SceneManager.LoadScene(4);
                    break;
                case 4:
                    SceneManager.LoadScene(5);
                    break;

            }
        }
    }
}
