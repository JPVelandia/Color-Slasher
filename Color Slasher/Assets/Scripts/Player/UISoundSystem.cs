using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundSystem : MonoBehaviour
{
    AudioSource mySource;
    [SerializeField] AudioSource mainSource;
    [SerializeField] AudioClip myClip, myClip2,myClip3;
    AudioClip mainClip;
    void Awake()
    {
        mySource = gameObject.GetComponent<AudioSource>();
        mainSource = GameObject.FindGameObjectWithTag("Master").GetComponent<AudioSource>();
    }

    public void SoundSystem()
    {
        Debug.Log(mySource);
        mySource.Play();
    }
    public void Action()
    {
        mySource.PlayOneShot(myClip);
    }
    public void Action2()
    {
        mySource.PlayOneShot(myClip2);
    }
    public void Action3()
    {
        mySource.PlayOneShot(myClip3);
    }
    //public void Action4()
    //{
    //    mySource.PlayOneShot(myClip4);
    //}
    //public void Action5()
    //{
    //    mySource.PlayOneShot(myClip5);
    //}
    public void Bang()
    {
        if (!mySource.isPlaying)
        {
            mySource.Play();
        }
    }
    //public void Swap()
    //{
    //    mainClip = mainSource.clip;
    //    mainSource.clip = myClip3;
    //    myClip3 = mainClip;

    //    mainSource.Play();
    //}
    //public void Swap2()
    //{
    //    mainClip = mainSource.clip;
    //    mainSource.clip = myClip4;
    //    myClip4 = mainClip;

    //    mainSource.Play();
    //}
}