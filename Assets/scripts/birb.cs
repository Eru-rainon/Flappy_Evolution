using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class birb : MonoBehaviour
{
    public float flapStrength = 15f;
    public Rigidbody2D bird;
    public logicscript logic;
    public Text shieldCount;
    
    public bool skill;
    public bool invincible;
    public Animator animator;
    public GameObject destruction;
    public audiomanager audiomanager;
    public GameObject spawner;
    bool clicked;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicscript>();
        skill = true;
        clicked = false;
        bird.gravityScale = 0f;
        spawner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(skill&& !logic.isPaused){
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
                if(!clicked){
                    bird.gravityScale = 3.33f;
                    spawner.SetActive(true);
                }
            bird.velocity =  Vector2.up*flapStrength;
            audiomanager.playSFX(audiomanager.flap);
        }
        }

        if(transform.position.y > 6.1 || transform.position.y < -6.5){
            if(skill){
            skill= false;
            if(!skill)
                logic.gameover();
        }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(invincible){
            Instantiate(destruction,collision.gameObject.transform.position,Quaternion.identity);
            Destroy(collision.gameObject);

            
        }
        if(skill  && !invincible){
            audiomanager.playSFX(audiomanager.pipehit);
            skill = false;
            if(!skill)
                logic.gameover();
        }
    }
}
