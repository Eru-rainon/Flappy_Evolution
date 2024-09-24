using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
[CreateAssetMenu(menuName = "Powerups/ScoreMultiplier")]
public class ScoreMultiplier : PowerUps
{
    public logicscript logic;
    public GameObject particle;
    public audiomanager audiomanager;
    public override void Apply(GameObject target)
    {
        audiomanager = GameObject.FindGameObjectWithTag("audio").GetComponent<audiomanager>();
       logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicscript>();
       logic.scoretoadd = 2;
       logic.Scoremultiplied.text = "x2 SCORE!!!";
       logic.StartCoroutine(Expire());
       Instantiate(particle,target.transform.position,Quaternion.identity);
       audiomanager.playSFX(audiomanager.scoremultiplier);
       
        
    }

    private IEnumerator Expire()
    {
        yield return new WaitForSeconds(10);
        logic.scoretoadd = 1;
        logic.Scoremultiplied.text = "";

    }
   
}
