using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : SingleToneMaker<ItemManager>
{
   
    public enum ItemType
    {
        ItemBomb
    }
    public GameObject ItemBomb;

    void Awake()
    {
        ItemBomb = Resources.Load(nameof(ItemType.ItemBomb)) as GameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        ObjectPoolManager.Instance.CreateDictTable(ItemBomb, 5,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableItemObject(string ItemName, Vector3 Pos)
    {
        GameObject Item = null;
        if (ItemName.Equals(ItemBomb.name))
        {
            Item = ObjectPoolManager.Instance.EnableGameObject(ItemBomb.name);
        }
        
        if (Item != null)
        {
            Item.transform.position = Pos;
            Item.SetActive(true);
        }
    }
}
