using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance = null;

    public static string BulletTag = "BulletObject";
    public static string Bullet1 = "Bullet1";
    public static string Bullet2 = "Bullet2";
    private int MaxBulletCnt;
    private int NowBulletCnt;
    public delegate void BulletObserver(int now, int max);
    public event BulletObserver BulletObserverEvent;

    public void BulletCntObserver(BulletObserver observer)
    {
        BulletObserverEvent += observer;
    }
    public void notifyBulletCnt()
    {
        BulletObserverEvent.Invoke(NowBulletCnt,MaxBulletCnt);
    }

    public int NowBulletCntProp
    {
        get
        {
            return NowBulletCnt;
        }
        set
        {
            if (0 <= value && value <= MaxBulletCnt)
            {
                NowBulletCnt = value;
            }
            notifyBulletCnt();
        }
    }



    public static string BombTag = "BombObject";
    public static string Bomb1 = "Bomb1";
    private int MaxBombCnt;
    private int NowBombCnt;

    public delegate void BombObserver(int number);
    public event BombObserver BombObserverEvent;

    public void BombCntObserver(BombObserver observer)
    {
        BombObserverEvent += observer;
    }
    public void notifyBombCnt()
    {
        BombObserverEvent.Invoke(NowBombCnt);
    }

    public int BombCnt
    {
        get
        {
            return NowBombCnt;
        }
        set
        {
            if(0<= value && value <= MaxBombCnt)
            {
                NowBombCnt = value;
            }
            notifyBombCnt();
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        //미사일 생성
        NowBulletCnt = 5;
        MaxBulletCnt = 5;
        ObjectPoolManager.Instance.CreateDictTable(Resources.Load(Bullet1) as GameObject, Bullet1, BulletTag, MaxBulletCnt, 0);
        ObjectPoolManager.Instance.CreateDictTable(Resources.Load(Bullet2) as GameObject, Bullet2, BulletTag, MaxBulletCnt, 0);

        //폭탄생성
        NowBombCnt = 3;
        MaxBombCnt = 5;
        BombCnt = NowBombCnt;
        ObjectPoolManager.Instance.CreateDictTable(Resources.Load(Bomb1) as GameObject, Bomb1, BombTag, MaxBombCnt,0);
    }

    void Update()
    {
        
    }

    
    public void EnableBulletObject(string bulletName, Vector3 Pos)
    {
        GameObject bullet = null;
        if (bulletName.Equals(Bullet1))
        {
            bullet = ObjectPoolManager.Instance.EnableGameObject(Bullet1);
        }
        else if (bulletName.Equals(Bullet2))
        {
            bullet = ObjectPoolManager.Instance.EnableGameObject(Bullet2);
        }
        if (bullet != null)
        {
            bullet.transform.position = Pos;
            bullet.SetActive(true);
            NowBulletCntProp--;
        }
    }
    public void DisalbeBulletObject(GameObject obj)
    {
        if (obj.tag.Equals(BulletTag))
        {
            ObjectPoolManager.Instance.DisableGameObject(obj, obj.name);
            NowBulletCntProp++;
        }
        else
        {
            Debug.LogError("총알이 아닌 obj가 들어왔습니다");
            Destroy(obj);
        }
    }

    public void EnableBombObject(string BombName, Vector3 Pos)
    {
        
        if (NowBombCnt == 0)
        {
            return;
        }
        GameObject bomb = null;
        if (BombName.Equals(Bomb1))
        {
            bomb = ObjectPoolManager.Instance.EnableGameObject(Bomb1);
        }
        if (bomb != null)
        {
            bomb.transform.position = Pos;
            bomb.SetActive(true);
            BombCnt--;
        }
    }
}
