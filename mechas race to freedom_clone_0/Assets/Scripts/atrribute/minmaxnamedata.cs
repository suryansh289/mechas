
using UnityEngine;
[CreateAssetMenu(fileName ="data 4",menuName ="min max data")]
public class minmaxnamedata : ScriptableObject
{
    public minmaxname[] mmn; 
    [System.Serializable]
    public struct minmaxname
    {
        public string name;
        public float min;
        public float max;
    }
}
