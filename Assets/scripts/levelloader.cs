using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelloader : MonoBehaviour
{
    public audiomanager audiomanager;
    public Animator transition;
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

   public void startLevel(int level ){
     audiomanager.playSFX(audiomanager.click);
     StartCoroutine(Waiting(audiomanager.click.length,level));
   }

     private IEnumerator Waiting(float timeToWait,int index){
    transition.SetTrigger("start");
    yield return new WaitForSeconds(1f);
    
    SceneManager.LoadScene(index);
   }
}
