using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] GameObject triggerWall;

    [SerializeField] GameObject room;
    [SerializeField] GameObject turnedOffButton;
    [SerializeField] GameObject collisionWall;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Room")
        {
            StartCoroutine("RoomCount");
            room.SetActive(false);
        }

        if (other.tag == "Button")
        {
            triggerWall.SetActive(false);
            StartCoroutine("TriggerCount");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Contact"))
        {
            collisionWall.SetActive(false);
            StartCoroutine("ContactCount");
        }
    }

    IEnumerator TriggerCount()
    {
        yield return new WaitForSeconds(2.5f);
        triggerWall.SetActive(true);
    }

    IEnumerator ContactCount()
    {
        yield return new WaitForSeconds(2.5f);
        collisionWall.SetActive(true);
    }

    IEnumerator RoomCount()
    {
        yield return new WaitForSeconds(2f);
        turnedOffButton.SetActive(true);
    }
}
