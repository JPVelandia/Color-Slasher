using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RedCollider : MonoBehaviour
{
    private Rigidbody2D rb;

    public LayerMask groundLayer;
    public Transform playerCheckPos;
    public bool isInside;
    public float radius = 0.5f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Power()
    {
        isInside = Physics2D.OverlapCircle(playerCheckPos.position,radius,groundLayer);
        
        UnityEngine.Debug.Log("Enemigo!");
    }
}
