using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : SingleToneMaker<ObjectPoolManager>
{
    private Dictionary<string, ObjectPool> dictTable;
    void Awake()
    {
        if(dictTable == null)
        {
            dictTable = new Dictionary<string, ObjectPool>();
        }
        GameObject.Find("Player").GetComponent<PlayerState>().PlayerResetEventSet(PlayerReset);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateDictTable(GameObject objectPrfab)
    {
        CreateDictTable(objectPrfab, 5, 0);
    }
    public void CreateDictTable(GameObject objectPrfab,int initCount, int overAllocateCount)
    {
        if (dictTable.ContainsKey(objectPrfab.name).Equals(false)) { 
            dictTable.Add(objectPrfab.name, new ObjectPool(objectPrfab, initCount, overAllocateCount));
        }
    }

    public GameObject EnableGameObject(string name)
    {
        GameObject obj = null;
        if (dictTable.ContainsKey(name).Equals(false)) {
            Debug.Log("잘못된 name이 들어왔습니다");
            return obj;
        }
        obj = dictTable[name].EnalbeObject();
        return obj;
    }
    public void DisableGameObject(GameObject obj)
    {
        //print(obj.name+obj.transform.position);
        if (dictTable.ContainsKey(obj.name).Equals(true))
        {
            dictTable[obj.name].DisableObject(obj);
        }
        else
        {
            Debug.Log("잘못된 obj " + obj.name + "이 들어왔습니다");
            Destroy(obj);
        }
    }

    public void PlayerReset()
    {
        Transform t = GameObject.Find("ObjectPoolSet").transform;
        for(int i=0;i< t.GetChildCount(); i++)
        {
            DisableGameObject(t.GetChild(i).gameObject);
        }
    }

}
