using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupmove : MonoBehaviour
{
    public float movespeed = 8f;
    public float deadzone = -18f;    
    void Update()
    {
        transform.position = transform.position + (Vector3.left*movespeed) * Time.deltaTime;
        if(transform.position.x < deadzone){
            Destroy(gameObject);
        }
    }
}
