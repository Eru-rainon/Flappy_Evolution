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
        target.GetComponent<birb>().bomb = true;
        target.GetComponent<birb>().bombButton.SetActive(true);
    }
}

