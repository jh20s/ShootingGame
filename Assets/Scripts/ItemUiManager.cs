using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUiManager : MonoBehaviour
{
    public Text BulletCntUI;
    public Text BombCntUI;
    public string BulletString = "총알 장전 : ";
    public string BombString = "폭탄 개수 : ";

    void Awake()
    {
        BulletManager.Instance.BombCntObserver(BombCntObserver);
        BulletManager.Instance.BulletCntObserver(BulletCntObserver);
        BulletCntUI.text = BulletString;
        BombCntUI.text = BombString;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BulletCntObserver(int now, int max)
    {
        BulletCntUI.text = BulletString + now + '/' + max;
    }
    public void BombCntObserver(int cnt)
    {
        BombCntUI.text = BombString + cnt;
    }
    
}
