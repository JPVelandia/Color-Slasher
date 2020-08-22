using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject purpleWall;
    [SerializeField] GameObject Room;
    [SerializeField] GameObject GreenPlatform;
    [SerializeField] GameObject GreenWall;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Room")
        {
            StartCoroutine("RoomCount");
            Room.SetActive(false);
        }

        if (other.tag == "PurpleButtom")
        {
            purpleWall.SetActive(false);
            StartCoroutine("PurpleCount");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Green"))
        {
            GreenWall.SetActive(false);
            StartCoroutine("GreenCount");
        }
    }

    IEnumerator PurpleCount()
    {
        yield return new WaitForSeconds(1f);
        purpleWall.SetActive(true);        
    }

    IEnumerator GreenCount()
    {
        yield return new WaitForSeconds(2f);
        GreenWall.SetActive(true);
    }

    IEnumerator RoomCount()
    {
        yield return new WaitForSeconds(3f);
        GreenPlatform.SetActive(true);
    }
}
