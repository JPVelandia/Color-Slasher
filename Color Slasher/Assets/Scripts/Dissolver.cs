using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolver : MonoBehaviour
{
    private float DissolveAmount;
    [SerializeField] float DissolveSpeed = 1.3f;
    public bool IsDissolving;
    private Material mat;

    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }


    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.A))
        {
            IsDissolving = true;
        }*/
        /*if(Input.GetKeyDown(KeyCode.S))
        {
            IsDissolving = false;
        }*/
        if (IsDissolving ==  true)
        {
            if(DissolveAmount < 1)
            {
                DissolveAmount += Time.deltaTime * DissolveSpeed;
            }                      
        }
        if (!IsDissolving)
        {
            if (DissolveAmount > 0)
            {
                DissolveAmount -= Time.deltaTime * DissolveSpeed;
            }
        }

        mat.SetFloat("_Level", DissolveAmount);
    }
}
