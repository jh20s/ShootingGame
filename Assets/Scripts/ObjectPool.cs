using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TO-DO: generic으로 변경
public class ObjectPool 
{
    private List<GameObject> objectPool;
    private GameObject objectFactory;
    private int overAllocateCount; //해당 변수가 0이아니면, 풀이 부족하면 overAllocateCount만큼 objectPool증가

    public ObjectPool(GameObject objectFactory, int initCount, int overAllocateCount)
    {
        this.objectFactory = objectFactory;
        this.overAllocateCount = overAllocateCount;
        objectPool = new List<GameObject>();
        Allocate(initCount);
    }

    public void Allocate(int cnt)
    {
        for(int i=0;i< cnt; i++)
        {
            GameObject obj = GameObject.Instantiate(objectFactory, GameObject.Find("ObjectPoolSet").transform);
            obj.name = objectFactory.name;
            obj.gameObject.SetActive(false);
            objectPool.Add(obj);
        }
        
    }

    public GameObject EnalbeObject()
    {
        
        if (objectPool.Count <= 0 && overAllocateCount <= 0)
        {
            return null;
        }
        else if(objectPool.Count <= 0 && overAllocateCount > 0)
        {
            Debug.Log("오브젝트 전부 사용 " + overAllocateCount + "개를 추가합니다");
            Allocate(overAllocateCount);
        }

        GameObject retObj = objectPool[0];
        objectPool.Remove(retObj);

        return retObj;
    }
    public void DisableObject(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        objectPool.Add(obj);
    }
}
