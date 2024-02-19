using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileScriptableObject", menuName = "Gain Ground/ProjectileScriptableObject", order = 1)]
public class ProjectileScriptableObject : ScriptableObject
{
    public float ForwardVelocity;
    public float VerticalVelocity;
    public float VerticalDrop;
    public float LifeSpan;
}
