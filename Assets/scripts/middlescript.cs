
using System;
using UnityEngine;

public class middlescript : MonoBehaviour
{

    bool triggered = true;
    
    public logicscript logic;
    void Start(){
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicscript>();
       
    }
   private void OnTriggerEnter2D(Collider2D collision){
       if(collision.gameObject.layer == 3){
         if(triggered){
            logic.addscore();
            triggered = false;
        }
       }
   
   }
}
