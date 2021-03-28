using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance = null;

    public static string BulletTag = "BulletObject";
    public static string Bullet1 = "Bullet1";
    public static string Bullet2 = "Bullet2";

    public static string BombTag = "BombObject";
    public static string Bomb1 = "Bomb1";
    private int MaxBombCnt;
    private int NowBombCnt;
    public int BombCnt
    {
        get
        {
            return NowBombCnt;
        }
        set
        {
            NowBombCnt = MaxBombCnt < value? MaxBombCnt : value;
        }
    }

    /*
     총알의 종류
     현재 총알의 개수
     총알개수 증가
     총알속도 아이템
     총알 부피 아이템


     폭탄의 종류
     현재폭탄의 개수
     폭탄개수 증가

     */

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
        ObjectPoolManager.Instance.CreateDictTable(Resources.Load(Bullet1) as GameObject, Bullet1, BulletTag);
        ObjectPoolManager.Instance.CreateDictTable(Resources.Load(Bullet2) as GameObject, Bullet2, BulletTag);

        //폭탄생성
        NowBombCnt = 3;
        MaxBombCnt = 5;
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
        }
    }

    public void EnableBombObject(string BombName, Vector3 Pos)
    {
        if (NowBombCnt == 0)
        {
            return;
        }
        NowBombCnt--;
        GameObject bomb = null;
        if (BombName.Equals(Bomb1))
        {
            bomb = ObjectPoolManager.Instance.EnableGameObject(Bomb1);
        }
        if (bomb != null)
        {
            bomb.transform.position = Pos;
            bomb.SetActive(true);
        }
    }
}
