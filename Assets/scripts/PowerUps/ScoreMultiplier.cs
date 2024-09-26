using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Powerups/ScoreMultiplier")]
public class ScoreMultiplier : PowerUps
{
    public logicscript logic;
    public GameObject particle;
    public audiomanager audiomanager;
    public Image timer;
    private Coroutine expireCoroutine;
    public GameObject birb;
    public override void Apply(GameObject target)
    {
        birb birbcomponent = target.GetComponent<birb>();
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicscript>();
        if(expireCoroutine != null){
            logic.StopCoroutine(expireCoroutine);
        }
        audiomanager = GameObject.FindGameObjectWithTag("audio").GetComponent<audiomanager>();
       
       timer = GameObject.FindGameObjectWithTag("multipliertimer").GetComponent<Image>();
       timer.gameObject.SetActive(true);
       timer.fillAmount = 1f;
       logic.scoretoadd = 2;
      
       
       expireCoroutine = logic.StartCoroutine(Expire(target));
       Instantiate(particle,target.transform.position,Quaternion.identity);
       audiomanager.playSFX(audiomanager.scoremultiplier);
       
        
    }

    private IEnumerator Expire(GameObject target)
    {
        
       float duration = 10f;
       float elapsed = 0f;
       while(elapsed <= duration){
            elapsed+=Time.deltaTime;
            timer.fillAmount = 1f - (elapsed/duration);
            yield return null;

       }
       logic.scoretoadd = 1;
       timer.fillAmount = 0f;
        

    }
   
}
