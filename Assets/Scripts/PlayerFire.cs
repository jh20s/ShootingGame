using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{


    public GameObject firePosition;

    
    //private ObjectPoolManager;
    void Start()
    {
#if UNITY_ANDROID
        GameObject.Find("Joystick canvas XYBZ").SetActive(true);
#elif UNITY_EDITOR || UNITY_STANDALONE
        GameObject.Find("Joystick canvas XYBZ").SetActive(false);
#endif  
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetButtonDown("Fire1"))
        {
            fireBullet();
        }
         else if (Input.GetButtonDown("Fire2"))
        {
            fireBomb();
        }
#endif
    }

    public void fireBullet()
    {
        BulletManager.Instance.EnableBulletObject(BulletManager.Instance.bullet1.name, firePosition.transform.position);
    }
    public void fireBomb()
    {
        BulletManager.Instance.EnableBombObject(BulletManager.Instance.bomb1.name, firePosition.transform.position);
    }
}
