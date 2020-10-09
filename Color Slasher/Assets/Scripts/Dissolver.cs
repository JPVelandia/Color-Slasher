using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolver : MonoBehaviour
{
    [SerializeField] float DissolveAmount;
    [SerializeField] float DissolveSpeed;
    private bool IsDissolving;
    private Material mat;
    [SerializeField] Animator anim;

    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
        anim.SetBool("Test", false);
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            IsDissolving = true;
            anim.SetBool("Test", true);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            IsDissolving = false;
            anim.SetBool("Test", false);
        }
        if (IsDissolving ==  true)
        {
            if(DissolveAmount > -0.2)
            {
                DissolveAmount -= Time.deltaTime * DissolveSpeed;
            }                      
        }
        if (!IsDissolving)
        {
            if (DissolveAmount < 1)
            {
                DissolveAmount += Time.deltaTime * DissolveSpeed;
            }
        }

        mat.SetFloat("_DissolveAmount", DissolveAmount);
    }
}
