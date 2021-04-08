using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float speed = 2;
    void Start()
    {
        
    }
    void Update()
    {
        Vector3 dir = Vector3.down;
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            BulletManager.Instance.BombCnt++;
            ObjectPoolManager.Instance.DisableGameObject(gameObject);
        }
    }

    
}
