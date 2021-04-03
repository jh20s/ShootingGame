using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance = null;

    private Dictionary<string, ObjectPool> dictTable;
    
    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
        }
        if(dictTable == null)
        {
            dictTable = new Dictionary<string, ObjectPool>();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateDictTable(GameObject objectPrfab, string name, string tag)
    {
        CreateDictTable(objectPrfab, name, tag, 5, 0);
    }
    public void CreateDictTable(GameObject objectPrfab, string name, string tag,int initCount, int overAllocateCount)
    {
        dictTable.Add(name, new ObjectPool(objectPrfab, name, tag, initCount, overAllocateCount));
    }

    public GameObject EnableGameObject(string name)
    {
        GameObject obj = null;

        if (dictTable.ContainsKey(name).Equals(false))
            return obj;
        
        obj = dictTable[name].EnalbeObject();
        return obj;
    }
    public void DisableGameObject(GameObject obj, string name)
    {
        if (dictTable.ContainsKey(name).Equals(true))
        {
            dictTable[name].DisableObject(obj);
        }
        else
        {
            Destroy(obj);
        }
    }

}
