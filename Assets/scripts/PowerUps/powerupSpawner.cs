using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupSpawner : MonoBehaviour
{
    public GameObject powerup;
    public float spawnradius = 5f;
    public int maxAttempts = 10;
    public LayerMask Obstacles;
    public float timer = 0f;
    public float spawninterval = 1f;
    public int maxrange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer >= spawninterval){
            timer = 0f;
            int randomnumber = Random.Range(1,maxrange);
            if(randomnumber == 5)
                Spawn();
        }
    }

    public void Spawn(){
        Vector2 spawnposition = Vector2.zero;
        bool foundposition = false;

        for(int i = 0;i<maxAttempts;i++){
            Vector2 randomposition = new Vector2(Random.Range(-spawnradius,spawnradius), Random.Range(-spawnradius,spawnradius));
            spawnposition = (Vector2)transform.position + randomposition;

            if(!Physics2D.OverlapCircle(randomposition,1f,Obstacles)){
                foundposition = true;
                break;
            }
        }
        if(foundposition){
            Instantiate(powerup,spawnposition,Quaternion.identity);
        }
    }
}
