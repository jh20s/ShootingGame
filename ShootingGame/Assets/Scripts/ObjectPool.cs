using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TO-DO: generic으로 변경
public class ObjectPool : MonoBehaviour
{
    private List<GameObject> objectPool;
    private GameObject objectFactory;
    private string objectName;
    private string objectTag;
    private int overAllocateCount; //해당 변수가 0이아니면, 풀이 부족하면 overAllocateCount만큼 objectPool증가

    public ObjectPool(GameObject objectFactory,string objectName, string tag, int initCount, int overAllocateCount)
    {
        this.objectFactory = objectFactory;
        this.objectName = objectName;
        this.objectTag = tag;
        this.overAllocateCount = overAllocateCount;
        objectPool = new List<GameObject>();
        Allocate(initCount);
    }

    public void Allocate(int cnt)
    {
        for(int i=0;i< cnt; i++)
        {
            GameObject obj = Instantiate(objectFactory);
            //print(obj.tag+" "+ objectTag);
            obj.name = objectName;
            obj.tag = objectTag;
            //obj.name = objectName + i.ToString();
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

        //SetActive(true)를 하고 반환하면 죽어있던 오브젝트를 꺼내자마자 생성이되기때문에 문제소지있음
        //retObj.gameObject.SetActive(true);
        return retObj;
    }
    public void DisableObject(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        objectPool.Add(obj);
    }
}
