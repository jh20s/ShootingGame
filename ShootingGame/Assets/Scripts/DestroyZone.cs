using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(BulletManager.BulletTag)) { 
            BulletManager.Instance.DisalbeBulletObject(other.gameObject);
        }
        else { 
            ObjectPoolManager.Instance.DisableGameObject(other.gameObject, other.gameObject.name);
        }
    }

}
