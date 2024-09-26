using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoresmanager : MonoBehaviour
{
    public AudioSource musicsource;
    public AudioSource sfxsource;
    public AudioClip menumusic;
    public AudioClip fireworks;
    void Start()
    {
        musicsource.clip = menumusic;
        musicsource.loop = true;
        musicsource.Play();
    }

    public void playSFX(AudioClip clip){
        sfxsource.PlayOneShot(clip);
    }
}
