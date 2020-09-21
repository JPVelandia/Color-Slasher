using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject TriggerWall;
    [SerializeField] GameObject Room;
    [SerializeField] GameObject ContactPlatform;
    [SerializeField] GameObject ContactPlatform2;
    [SerializeField] GameObject ContactWall;
    [SerializeField] GameObject ContactWall2;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Room")
        {
            StartCoroutine("RoomCount");
            Room.SetActive(false);
        }

        if (other.tag == "Button")
        {
            TriggerWall.SetActive(false);
            StartCoroutine("TriggerCount");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Contact"))
        {
            ContactWall.SetActive(false);
            ContactWall2.SetActive(false);            
            StartCoroutine("ContactCount");
        }
    }

    IEnumerator TriggerCount()
    {
        yield return new WaitForSeconds(2.5f);
        TriggerWall.SetActive(true);        
    }

    IEnumerator ContactCount()
    {
        yield return new WaitForSeconds(2.5f);
        ContactWall.SetActive(true);
        ContactWall2.SetActive(true);
    }

    IEnumerator RoomCount()
    {
        yield return new WaitForSeconds(2f);
        ContactPlatform.SetActive(true);
        ContactPlatform2.SetActive(true);
    }
}
