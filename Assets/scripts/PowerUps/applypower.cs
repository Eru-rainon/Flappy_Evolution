using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applypower : MonoBehaviour
{
    public PowerUps effect;
    private void OnTriggerEnter2D(Collider2D collision){
        Destroy(gameObject);
        effect.Apply(collision.gameObject);
    }

}
