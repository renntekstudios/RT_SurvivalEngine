using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    public Texture2D inventoryIcon;
    public bool isStackable = false;
    public bool DestoryOnUse = false;
    public int maxStack = 9;
    public string myName = "";
    public float value;
    public ItemConf.ItemType type;
    public ItemConf.ItemConsumable useType;
    public int itemID;

    public Item(ItemConf item, string name, Texture texture, float value, ItemConf.ItemType type, ItemConf.ItemConsumable useType, int itemID)
    {
        item.itemConfName = name;
        item.itemTexture = texture;
        item.Value = value;
        item.type = type;
        item.useType = useType;
        item.ItemID = itemID;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInChildren<Inventory>().AddItem(myName, inventoryIcon, value, type, useType, itemID);
            if (DestoryOnUse)
                Destroy(gameObject);
        }
    }
}
