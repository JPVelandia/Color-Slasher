using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimer : MonoBehaviour
{
    Transform player, myTransform;
    [SerializeField] GameObject bullet;
    [SerializeField] float time = 0.5f;
    [SerializeField] bool k = true;
    private bool ShootPermit { get; set; }

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject.transform;
        myTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if(ShootPermit == true)
        {
            myTransform.LookAt(player, Vector3.forward);
            if (k == true)
            {
                Shoot();
                k = false;
                Invoke("KTrue", time);
            }
        }
    }

    private void LateUpdate()
    {
        myTransform.rotation *= Quaternion.Euler(0, 0, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                ShootPermit = true;
            }
            else
            {
                player = FindObjectOfType<PlayerMovement>().gameObject.transform;
                ShootPermit = true;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShootPermit = false;
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
