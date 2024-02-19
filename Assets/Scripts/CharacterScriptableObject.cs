using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "Gain Ground/CharacterScriptableObject", order = 0)]
public class CharacterScriptableObject : ScriptableObject
{
    public string Name;
    public float MoveSpeed;
    //Projectiles A and B go here as does portrait
}
