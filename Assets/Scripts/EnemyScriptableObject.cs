using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "Gain Ground/EnemyScriptableObject", order = 1)]
public class EnemyScriptableObject : ScriptableObject
{
    public float Health;
    public float FireRate;
    public float FireRange;
    public ProjectileScriptableObject ProjectileData;
}
