using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimer : MonoBehaviour
{
    Transform player, myTransform;
    [SerializeField] GameObject bullet;
    [SerializeField] float time = 0.5f;
    bool k = true;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject.transform;
        myTransform = GetComponent<Transform>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(player != null)
            {
                myTransform.LookAt(player, Vector3.forward);
                if(k == true)
                {
                    Shoot();
                    k = false;
                    Invoke("KTrue", time);
                }
            }
            else
            {
                player = FindObjectOfType<PlayerMovement>().gameObject.transform;
            }
        }
    }

    public void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, -myTransform.eulerAngles.z));
    }

    public void KTrue()
    {
        k = true;
    }
}
