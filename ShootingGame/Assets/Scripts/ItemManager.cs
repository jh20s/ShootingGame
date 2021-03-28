using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static string ItemTag = "ItemObject";
    public static string ItemBomb = "ItemBomb";

    public static ItemManager Instance = null;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ObjectPoolManager.Instance.CreateDictTable(Resources.Load(ItemBomb) as GameObject, ItemBomb, ItemTag, 5,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableItemObject(string ItemName, Vector3 Pos)
    {
        GameObject Item = null;
        if (ItemName.Equals(ItemBomb))
        {
            Item = ObjectPoolManager.Instance.EnableGameObject(ItemBomb);
        }
        
        if (Item != null)
        {
            Item.transform.position = Pos;
            Item.SetActive(true);
        }
    }
}
