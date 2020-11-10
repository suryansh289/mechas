
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="objectpool data")]
public class objectpooldata : ScriptableObject
{
    public List<pool> pools  = new List<pool>();
}
