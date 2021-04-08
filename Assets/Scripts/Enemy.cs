using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 5;
    private int hp = 1;
    private int moving =5; //0~20사이로 설정된 값만큼 per/20으로 Player방향으로 쏴짐

    Vector3 dir;
    
    public GameObject explosionFactory;

    void OnEnable()
    {
        int randValue = UnityEngine.Random.Range(0, 20);

        if (randValue < moving)
        {
            GameObject target = GameObject.Find("Player");
            if (target == null)
                return;
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

        if (other.gameObject.CompareTag(BulletManager.Instance.bullet1.tag))
        {
            BulletManager.Instance.DisalbeBulletObject(other.gameObject);
            hp--;
        }
        else if (other.gameObject.CompareTag(BulletManager.Instance.bomb1.tag))
        {
            hp -= 5; ;
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            hp--;
        }

        if (hp <= 0) {
            if (gameObject.name.Equals(EnemyManager.Instance.enemy2.name))
            {
                ItemManager.Instance.EnableItemObject(ItemManager.Instance.ItemBomb.name, gameObject.transform.position);
            }
            ObjectPoolManager.Instance.DisableGameObject(gameObject);
        }
    }


    public void enemyStateSet(int hp, float speed, int moving)
    {
        this.hp = hp;
        this.speed = speed;
        this.moving = moving;
    }
}
