using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{


    public GameObject firePosition;

    //TO-DO bullet이름을 관리할수 있는 cs만들어놔야함 현재 있는 위치가 잘못되어있음

    //private ObjectPoolManager;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //
        if (Input.GetButtonDown("Fire1"))
        {
            BulletManager.Instance.EnableBulletObject(BulletManager.Bullet1, firePosition.transform.position);
        }
        //TO-DO 폭탄으로해서 범위가 큰 미사일로 바꾸고 개수가 적게 만들어놓자.
        //item 아이템 먹으면 폭탄개수 증가하게 만들자.
        else if (Input.GetButtonDown("Fire2"))
        {
            BulletManager.Instance.EnableBombObject(BulletManager.Bomb1, firePosition.transform.position);
        }
    }
}
