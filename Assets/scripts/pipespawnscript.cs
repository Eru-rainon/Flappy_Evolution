using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipespawnscript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnrate;
    private float timer = 0f;
    public float heightOffset = 3.97f;
    
    void Start()
    {
        switch(PlayerPrefs.GetInt("difficulty",2)){
            case 1 : spawnrate = 1.4f;
            break;
            case 2 : spawnrate = 0.9f;
            break;
            case 3 : spawnrate = 0.66f;
            break;
        }
        
    }

    
    void Update()
    {
        if(timer<spawnrate){
            timer+=Time.deltaTime;
        }
        else{
            spawnpipe();
            timer = 0f;
        }
        
    }

    void spawnpipe(){
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
         Instantiate(pipe,new Vector3(transform.position.x, Random.Range(lowestPoint,highestPoint),0), transform.rotation);
    }
}
