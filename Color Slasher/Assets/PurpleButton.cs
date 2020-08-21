using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleButton : MonoBehaviour
{

    [SerializeField] GameObject purpleWall;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "PurpleButtom")
        {
            purpleWall.SetActive(false);
            StartCoroutine("PurpleCount"); 
        }
    }

    IEnumerator PurpleCount()
    {
        yield return new WaitForSeconds(1f);
        purpleWall.SetActive(true);
    }
}
