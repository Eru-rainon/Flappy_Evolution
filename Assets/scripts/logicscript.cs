using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;

public class logicscript : MonoBehaviour
{
   public int score;
   public int scoretoadd;
   public Text scoreText;
   public Text highScore;
   public Text Scoremultiplied;
   public GameObject gameoverscreen;
   public GameObject pausemenu;

   public GameObject[] powerupSpawners;
   public bool isPaused;

   public GameObject pausebutton;
   public Sprite normalSprite;
   public Sprite clickedSprite;
   private Image buttonImage;
   string HighScoreID;
   public audiomanager audiomanager;
   private bool hashighScoreBeenBeaten;
   public Animator transition;


   void Start(){

     int difficulty = PlayerPrefs.GetInt("difficulty",2);
     switch(difficulty){
          case 1: HighScoreID = "easy";
          break;
          case 2 : HighScoreID = "medium";
          break;
          case 3: HighScoreID = "hard";
          break;
     }
     setHighscore(HighScoreID);
     hashighScoreBeenBeaten = false;
     isPaused = false;
     pausebutton.SetActive(true);
     buttonImage = pausebutton.GetComponent<Image>();
     buttonImage.sprite = normalSprite;
     scoretoadd = 1;
     if(PlayerPrefs.GetInt("evomode",0) == 1){
      foreach(GameObject powerupSpawer in powerupSpawners){
        powerupSpawer.SetActive(true);
      }
     }
   }



   public void addscore(){
        score += scoretoadd;
        scoreText.text = score.ToString();
        audiomanager.playSFX(audiomanager.scoreup);
        if(score > PlayerPrefs.GetInt(HighScoreID,0)){
          if(!hashighScoreBeenBeaten){
            audiomanager.playSFX(audiomanager.highscore);
            hashighScoreBeenBeaten = true;
          }
          PlayerPrefs.SetInt(HighScoreID,score);
          setHighscore(HighScoreID);
        }
   }

   public void restart(){
    Time.timeScale = 1f;
        audiomanager.playSFX(audiomanager.click);
        StartCoroutine(Waiting(audiomanager.click.length,SceneManager.GetActiveScene().buildIndex));
        
   }

   public void mainmenu(){
    Time.timeScale = 1f;
    audiomanager.playSFX(audiomanager.click);
        StartCoroutine(Waiting(audiomanager.click.length,0));
    
   }

   public void gameover(){
        gameoverscreen.SetActive(true);
        pausebutton.SetActive(false);
        audiomanager.playSFX(audiomanager.gameover);
   }



   void setHighscore(string HighScoreID){
     highScore.text = "BEST: "+PlayerPrefs.GetInt(HighScoreID,0).ToString();
   }

   public void pause(){
        if(!isPaused){
          pausemenu.SetActive(true);
          Time.timeScale = 0f;
          isPaused = true;
          buttonImage.sprite = clickedSprite;
        }
        else{
          pausemenu.SetActive(false);
          Time.timeScale = 1f;
          isPaused = false;
          buttonImage.sprite = normalSprite;
        }
   }

   public void resume(){
      pausemenu.SetActive(false);
          Time.timeScale = 1f;
          isPaused = false;
          buttonImage.sprite = normalSprite;
   }
   public void quit(){
    audiomanager.playSFX(audiomanager.click);
        
    Application.Quit();
   }

   private IEnumerator Waiting(float timeToWait,int index){
    transition.SetTrigger("start");
    yield return new WaitForSeconds(1f);
    
    SceneManager.LoadScene(index);
   }
}
