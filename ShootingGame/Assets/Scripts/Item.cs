using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float speed = 3;
    void Start()
    {

    }
    void Update()
    {
        Vector3 dir = Vector3.up;
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        //print("여긴   오니???");
        if (other.gameObject.name.Equals("Player"))
        {
            BulletManager.Instance.BombCnt++;
            ObjectPoolManager.Instance.DisableGameObject(gameObject, gameObject.name);
        }
    }
}
