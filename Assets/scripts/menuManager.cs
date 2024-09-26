using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{



  public AudioSource musicsource;
  public AudioSource SFXsource;
  public AudioClip menumusic;
  public AudioClip click;
  public GameObject evoButtonON;
  public GameObject evoButtonOFF;

  public Sprite onstate;
  public Sprite offstate;
  public GameObject[] difficultybuttons;


  void Start(){
    musicsource.clip = menumusic;
    musicsource.loop = true;
    musicsource.Play();
    if(PlayerPrefs.GetInt("evomode",0) == 0){
      evoButtonOFF.SetActive(true);
      evoButtonON.SetActive(false);
    }
    else{
      evoButtonOFF.SetActive(false);
      evoButtonON.SetActive(true);
    }

     for (int i = 0; i < difficultybuttons.Length; i++)
    {
        // Get the Image component of the difficulty button
       Image buttonImage = difficultybuttons[i].GetComponent<Image>();

        // Set the image to 'onstate' for the selected difficulty, 'offstate' for others
        if (i == PlayerPrefs.GetInt("difficulty",2)-1)
        {
            buttonImage.sprite = onstate;
        }
        else
        {
            buttonImage.sprite = offstate;
        }
    }
     

  }
   public void startLevel(int level ){
     SFXsource.PlayOneShot(click);
     StartCoroutine(loadlevel(level));
   }

    public void setDIfficulty(int diff)
{
    PlayerPrefs.SetInt("difficulty", diff);

    // Iterate through all difficulty buttons
    for (int i = 0; i < difficultybuttons.Length; i++)
    {
        // Get the Image component of the difficulty button
        UnityEngine.UI.Image buttonImage = difficultybuttons[i].GetComponent<UnityEngine.UI.Image>();

        // Set the image to 'onstate' for the selected difficulty, 'offstate' for others
        if (i == diff-1)
        {
            buttonImage.sprite = onstate;
        }
        else
        {
            buttonImage.sprite = offstate;
        }
    }
}
   public void resetProgress(){
    PlayerPrefs.SetInt("easy",0);
    PlayerPrefs.SetInt("medium",0);
    PlayerPrefs.SetInt("hard",0);
   }

   public void playSFX(){
      SFXsource.PlayOneShot(click);
   }
    public void quit(){
      Application.Quit();
    }

    public void activateEvo(){
      if(PlayerPrefs.GetInt("evomode",0)==0){
        PlayerPrefs.SetInt("evomode",1);
        evoButtonOFF.SetActive(false);
        evoButtonON.SetActive(true);
      }
      else{
        PlayerPrefs.SetInt("evomode",0);
        evoButtonOFF.SetActive(true);
        evoButtonON.SetActive(false);
      }

    }

    private IEnumerator loadlevel(int index){
      yield return new WaitForSeconds(0.3f);
      SceneManager.LoadScene(index);
    }
}
