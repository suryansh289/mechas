
using System.Collections.Generic;
using UnityEngine;

public class objectpoolingoffline : MonoBehaviour
{
    public objectpooldata data;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(this);
        }
    }
    public Dictionary<string, Queue<GameObject>> pooldictionary;
    
    public static objectpoolingoffline instance;
    private void Start()
    {
        pooldictionary = new Dictionary<string, Queue<GameObject>>();
        foreach(pool pool in data.pools)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject oabject = Instantiate(pool.prefab);

                oabject.SetActive(false);
                objectpool.Enqueue(oabject);
            }
            pooldictionary.Add(pool.tag, objectpool);
        }
    }
    public GameObject spawnfromqueue(string tag,Vector3 position,Quaternion rotation)
    {
        //if (pooldictionary.ContainsKey(tag))
        //{
        //    Debug.LogWarning("thepooltag is not valid");
        //    foreach (pool pool in pools)
        //    {
        //        Debug.Log(pool.tag+ "="+tag);
        //    }
        //    return null;
        //}
        GameObject go= pooldictionary[tag].Dequeue();
        go.SetActive(true);
        go.transform.position = position;
        go.transform.rotation = rotation;

        pooldictionary[tag].Enqueue(go);
        return go;
    }
}
