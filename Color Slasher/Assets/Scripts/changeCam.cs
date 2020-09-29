using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCam : MonoBehaviour
{
    [SerializeField] GameObject cam1, cam2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "ChangeBig")
        {
            cam2.SetActive(true);
            cam1.SetActive(false);
        }

        if (gameObject.tag == "ChangePersonal")
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }
    }
}
