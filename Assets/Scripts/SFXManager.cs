using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{    
    public AudioClip playerShoot;
    public AudioClip asteroidExplosion;
    public AudioClip playerExplosion;
    public AudioClip BgMusic;

    private AudioSource audioSource;
    


    public void Start()
    {
        audioSource = GetComponent<AudioSource>();

        GameObject BgMusicAudioSource = this.transform.Find("BgMusic").gameObject;
        BgMusicAudioSource.GetComponent<AudioSource>().clip = BgMusic;
        BgMusicAudioSource.GetComponent<AudioSource>().Play();



       
    }

    //called in the PlayerController Script
    public void PlayerShoot() 
    {
        audioSource.PlayOneShot(playerShoot);        
    }

    //called in the AsteroidDestroy script
    public void AsteroidExplosion() 
    {
        audioSource.PlayOneShot(asteroidExplosion);        
    }

    //called in the AsteroidDestroy script
    public void PlayerExplosion() 
    {
        audioSource.PlayOneShot(playerExplosion);
    }



}
