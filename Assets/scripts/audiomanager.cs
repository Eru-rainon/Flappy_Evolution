using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{

    [SerializeField] AudioSource musicsource;
     [SerializeField] AudioSource SFXsource;

    public AudioClip flap;
    public AudioClip[] levelmusic;
    public AudioClip scoreup;
    public AudioClip pipehit;
    public AudioClip scoremultiplier;
    public AudioClip armor;
    public AudioClip shockwave;
    public AudioClip gameover;
    public AudioClip highscore;
    public AudioClip click;

    private void Start(){
        int musicno = Random.Range(0,3);
        musicsource.clip = levelmusic[musicno];
        musicsource.loop = true;
        musicsource.Play();
    }
    public void playSFX(AudioClip clip){
        SFXsource.PlayOneShot(clip);
    }

    public void buttonclick(){
        StartCoroutine(playsound());
    }
    private IEnumerator playsound(){
        
        SFXsource.PlayOneShot(click);
        yield return new WaitForSeconds(click.length);
    }
}
