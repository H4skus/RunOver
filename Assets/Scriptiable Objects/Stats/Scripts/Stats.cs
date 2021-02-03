using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public enum EnemyType
{
    test
}
*/
public class Stats : ScriptableObject
{
    public GameObject prefab;
    //public EnemyType type;
    [TextArea(15, 20)]
    public string description;
}
