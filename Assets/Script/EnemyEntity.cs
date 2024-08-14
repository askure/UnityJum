using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "EnemyEntity", menuName = "Create/Enemy")]
public class EnemyEntity : ScriptableObject
{
    public Sprite lookIcon, notlookedIcon, findIcon;
    public float changeTime;
}
