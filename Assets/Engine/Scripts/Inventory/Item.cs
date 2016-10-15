using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    public Texture2D inventoryIcon;
    public bool DestoryOnUse = false;
    public int maxStack = 9;
    public string myName = "";
    public int value;
    public ItemConf.ItemType type;
    public ItemConf.ItemConsumable useType;
    public bool isClickable;
    public int Stack;
    public bool isStackable;
    public int ItemID;
    public int manaStack;

    public Item(ItemConf item, string name, Texture texture, int value, ItemConf.ItemType type, ItemConf.ItemConsumable useType, int itemID, bool clickable, bool stackable, int manaStack)
    {
        item.itemConfName = name;
        item.itemTexture = texture;
        item.Value = value;
        item.type = type;
        item.useType = useType;
        item.isClickable = clickable;
        item.isStackable = stackable;
        item.Stack = 0;
        item.ItemID = ItemID;
        item.manaStack = manaStack;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInChildren<Inventory>().AddItem(myName, inventoryIcon, value, type, useType, ItemID, isClickable, isStackable, manaStack);
            if (DestoryOnUse)
                Destroy(gameObject);
        }
    }
}
