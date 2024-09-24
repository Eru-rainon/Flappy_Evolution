using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Powerups/armor")]
public class Armour : PowerUps
{
    public GameObject birb;
    public audiomanager audiomanager;
    
    
    public override void Apply(GameObject target)
    {
        audiomanager = GameObject.FindGameObjectWithTag("audio").GetComponent<audiomanager>();
        birb birbComponent = target.GetComponent<birb>();
        if (birbComponent != null)
        {
            birbComponent.invincible = true;
            birbComponent.shieldCount.text = "SHIELDED!!!";
            birbComponent.animator.SetBool("isArmored",true);
            birbComponent.StartCoroutine(Expire(target));
            audiomanager.playSFX(audiomanager.armor);
        }
        
    }
     
     private IEnumerator Expire(GameObject target){
        yield return new WaitForSeconds(5);
        target.GetComponent<birb>().invincible = false;
        target.GetComponent<birb>().shieldCount.text = "";
        target.GetComponent<birb>().animator.SetBool("isArmored",false);
     }
}
