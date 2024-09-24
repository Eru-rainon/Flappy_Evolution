using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public abstract class PowerUps : ScriptableObject
{
    public abstract void Apply(GameObject target);
}
