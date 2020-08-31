using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Collider[] colliders;

    static Collider[] _colliders;

    GameObject player;

    void Awake()
    {
        _colliders = colliders;
        player = FindObjectOfType<PlayerLife>().gameObject;
    }


    
}
