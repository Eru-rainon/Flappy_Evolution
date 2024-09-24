
using UnityEngine;
using UnityEngine.Timeline;

public class pipemovescript : MonoBehaviour
{
    public float movespeed = 5f;
    public float deadzone = -18f;    
    void Start()
    {
        
        switch(PlayerPrefs.GetInt("difficulty",2)){
            case 1 : movespeed = 4f;
            break;
            case 2 : movespeed = 5f;
            break;
            case 3 : movespeed = 7f;
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left*movespeed) * Time.deltaTime;
        if(transform.position.x < deadzone){
            Destroy(gameObject);
        }
    }
}
