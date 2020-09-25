using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource mySource;
    [SerializeField] AudioClip myClip;
    AudioClip mainClip;
    public void SoundSystem()
    {

        if (!mySource.isPlaying)
        {
            mySource.Play();
        }

    }
    public void Acction()
    {
        mySource.PlayOneShot(myClip);
    }

    public void Stop()
    {
        mySource.Stop();
    }

    public void Swap()
    {
        mainClip = mySource.clip;
        mySource.clip = myClip;
        myClip = mainClip;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Orejas") && gameObject.tag == "Battle Area")
        {
            mainClip = mySource.clip;
            //mySource.clip = bossClip;
            //bossClip = mainClip;

            mySource.Play();
            mySource.volume = 0.2f;
        }

        if (other.gameObject.CompareTag("Orejas") && gameObject.tag == "Church")
        {
            mainClip = mySource.clip;
            mySource.clip = myClip;
            myClip = mainClip;

            mySource.Play();
            mySource.volume = 0.2f;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Orejas") && gameObject.tag == "Battle Area")
        {
            mainClip = mySource.clip;
            //mySource.clip = bossClip;
            //bossClip = mainClip;

            mySource.Play();
            mySource.volume = 0.2f;
        }

        if (other.gameObject.CompareTag("Orejas") && gameObject.tag == "Church")
        {
            mainClip = mySource.clip;
            mySource.clip = myClip;
            myClip = mainClip;

            mySource.Play();
            mySource.volume = 0.2f;
        }
    }
}