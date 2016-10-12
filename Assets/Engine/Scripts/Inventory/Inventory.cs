using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<ItemConf> InventoryItems = new List<ItemConf>();
    public PlayerConfig config;

    public void AddItem(string name, Texture texture, float value, ItemConf.ItemType type, ItemConf.ItemConsumable useType, int itemID)
    {//Add an item to the inventory.
        ItemConf n = new global::ItemConf();
        n.itemConfName = name;
        n.itemTexture = texture;
        n.Value = value;
        n.type = type;
        n.useType = useType;
        n.ItemID = itemID;
        InventoryItems.Add(n);

        Debug.Log(n.itemConfName + " Has been added to inventroy");
    }

    public void RemoveItem(int Item)
    {//Removed an item from the inventory.

        InventoryItems.Remove(InventoryItems[Item]);
    }

    public void UseItem(ItemConf.ItemType type,  ItemConf.ItemConsumable useType, float value, int Item)
    {
        //check the item id, get the item type. then use it.
        switch(type)
        {
            case ItemConf.ItemType.Consumable:

                switch (useType)
                {
                    case ItemConf.ItemConsumable.Health:
                        RemoveItem(InventoryItems[Item].ItemID);
                        UseConsumable(0, value);
                        break;
                    case ItemConf.ItemConsumable.Mana:
                        RemoveItem(InventoryItems[Item].ItemID);
                        UseConsumable(1, value);
                        break;
                }
                break;

            case ItemConf.ItemType.Equipment:
                RemoveItem(InventoryItems[Item].ItemID);
                Debug.Log("Im Equipment");
                break;
            case ItemConf.ItemType.Quest:
                RemoveItem(InventoryItems[Item].ItemID);
                Debug.Log("Im Quest");
                break;
        }
    }

    void UseConsumable(int type, float value)
    {
        switch (type)
        {
            case 0://Health
                config.guiManager.Health += value;
                break;
            case 1://Mana
                break;

        }
    }
}