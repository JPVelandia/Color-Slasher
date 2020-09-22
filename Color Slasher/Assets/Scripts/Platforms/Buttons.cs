using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    /*
    [SerializeField] GameObject TriggerWall;
    [SerializeField] GameObject Room;

    [SerializeField] GameObject[] contactPlatforms;
    [SerializeField] GameObject[] contactWalls;

    PlatfomIndex platfomIndex;
    
    void Awake()
    {
        contactPlatforms = GetComponents<GameObject>();
        contactWalls = GetComponents<GameObject>();
    }
        
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
        if (contactPlatforms[platfomIndex.index].CompareTag("Contact"))
        {
            contactWalls[platfomIndex.index].SetActive(false);                 
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
    } */
}
