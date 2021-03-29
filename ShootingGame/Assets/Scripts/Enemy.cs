using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;
    
    public GameObject explosionFactory;

    void OnEnable()
    {
        int randValue = UnityEngine.Random.Range(0, 10);

        if (randValue < 10)
        {
            GameObject target = GameObject.Find("Player");
            
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }


    private void OnCollisionEnter(Collision other)
    {
        ScoreManager.Instance.Score++;

        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        //부딪친 객체 삭제
        if (other.gameObject.tag.Equals(BulletManager.BulletTag))
        {
            BulletManager.Instance.DisalbeBulletObject(other.gameObject);
        }
        else if (other.gameObject.tag.Equals(BulletManager.BombTag)){

        }
        else
        {
            Debug.Log("other gameObject Destory name: " + other.gameObject);
            Destroy(other.gameObject);
        }

        //아이템 생성
        if (gameObject.name.Equals(EnemyManager.Instance.Enemy2))
        {
            ItemManager.Instance.EnableItemObject(ItemManager.ItemBomb, gameObject.transform.position);
        }

        ObjectPoolManager.Instance.DisableGameObject(gameObject, gameObject.name);
    }

}
