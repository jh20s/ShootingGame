using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : SingleToneMaker<BulletManager>
{

    public enum BulletType
    {
        Bullet1,
        Bullet2
    }

    public GameObject bullet1;
    public GameObject bullet2;

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

    public enum BombType
    {
        Bomb1,
    }

    public GameObject bomb1;
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

    public void PlayerReset()
    {
        BombCnt = 3;
        NowBulletCntProp = 10;
    }




    void Awake()
    {
        GameObject.Find("Player").GetComponent<PlayerState>().PlayerResetEventSet(PlayerReset);
        bullet1 = Resources.Load(nameof(BulletType.Bullet1)) as GameObject;
        bullet2 = Resources.Load(nameof(BulletType.Bullet2)) as GameObject;
        bomb1 = Resources.Load(nameof(BombType.Bomb1)) as GameObject;
    }

    void Start()
    {
        //미사일 생성
        NowBulletCnt = 10;
        MaxBulletCnt = 10;
        ObjectPoolManager.Instance.CreateDictTable(bullet1, MaxBulletCnt, 0);
        ObjectPoolManager.Instance.CreateDictTable(bullet2, MaxBulletCnt, 0);

        //폭탄생성
        NowBombCnt = 3;
        MaxBombCnt = 5;
        ObjectPoolManager.Instance.CreateDictTable(bomb1, MaxBombCnt,0);

        PlayerReset();
    }

    void Update()
    {
        
    }

    
    public void EnableBulletObject(string bulletName, Vector3 Pos)
    {
        GameObject bullet = null;
        if (bulletName.Equals(bullet1.name))
        {
            bullet = ObjectPoolManager.Instance.EnableGameObject(bullet1.name);
        }
        else if (bulletName.Equals(bullet2.name))
        {
            bullet = ObjectPoolManager.Instance.EnableGameObject(bullet2.name);
        }

        if (bullet != null)
        {
            bullet.transform.position = Pos;
            bullet.SetActive(true);
            NowBulletCntProp--;
        }
    }

    public void EnableBombObject(string BombName, Vector3 Pos)
    {
        
        if (NowBombCnt == 0)
        {
            return;
        }
        GameObject bomb = null;
        if (BombName.Equals(bomb1.name))
        {
            bomb = ObjectPoolManager.Instance.EnableGameObject(bomb1.name);
        }
        if (bomb != null)
        {
            bomb.transform.position = Pos;
            bomb.SetActive(true);
            BombCnt--;
        }
    }

    public void DisalbeBulletObject(GameObject obj)
    {
        if (obj.CompareTag(bullet1.tag))
        {
            ObjectPoolManager.Instance.DisableGameObject(obj);
            NowBulletCntProp++;
        }
        else
        {
            Debug.LogError("총알이 아닌 obj가 들어왔습니다");
            Destroy(obj);
        }
    }
}
