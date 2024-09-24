using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
  
    void Start(){
        DestroyPaerticle();
        Destroy(gameObject);
    }
    private IEnumerator DestroyPaerticle(){
        yield return new WaitForSeconds(2);
        
    }
}
