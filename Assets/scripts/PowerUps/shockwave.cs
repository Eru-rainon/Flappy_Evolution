using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
[CreateAssetMenu(menuName ="Powerups/Shockwave")]
public class shockwave : PowerUps
{
    public GameObject particle;
    public GameObject destruction;
    public audiomanager audiomanager;
    public override void Apply(GameObject target)
    {
        audiomanager = GameObject.FindGameObjectWithTag("audio").GetComponent<audiomanager>();
        Instantiate(particle,target.transform.position,Quaternion.identity);
        audiomanager.playSFX(audiomanager.shockwave);
        GameObject[] Obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        foreach(GameObject obstacle in Obstacles){
            
            Instantiate(destruction,obstacle.transform.position,Quaternion.identity);
            
            Destroy(obstacle);
        }
    }
}

