using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{


    public GameObject firePosition;

    
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
         else if (Input.GetButtonDown("Fire2"))
        {
            BulletManager.Instance.EnableBombObject(BulletManager.Bomb1, firePosition.transform.position);
        }
    }
}
