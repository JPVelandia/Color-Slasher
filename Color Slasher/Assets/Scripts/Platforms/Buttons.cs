using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    [SerializeField] GameObject TriggerWall;
    [SerializeField] GameObject Room;

    [SerializeField] GameObject contactPlatform;

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

    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Contact"))
    //    {
    //        ContactIndex = int.Parse(other.gameObject.name.ToString());
    //        contactWalls[ContactIndex].SetActive(false);
    //        StartCoroutine("ContactCount");
    //        Debug.Log(ContactIndex);
    //    }
    //}

    IEnumerator TriggerCount()
    {
        yield return new WaitForSeconds(2.5f);
        TriggerWall.SetActive(true);
    }

    //IEnumerator ContactCount()
    //{
    //    yield return new WaitForSeconds(2.5f);
    //    contactWalls[ContactIndex].SetActive(true);
    //    Debug.Log("holi" + ContactIndex);
    //}

    IEnumerator RoomCount()
    {
        yield return new WaitForSeconds(2f);
        contactPlatform.SetActive(true);
    }
}
