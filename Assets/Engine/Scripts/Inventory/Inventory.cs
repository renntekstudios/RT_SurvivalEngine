using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public List<ItemConf> InventoryItems = new List<ItemConf>();
    public PlayerConfig config;

    public void AddItem(string name, Texture texture, int value, ItemConf.ItemType type, ItemConf.ItemConsumable useType, int itemID, bool clickable, bool stackable, int manaStack)
    {//Add an item to the inventory.
        ItemConf n = new ItemConf();
        n.itemConfName = name;
        n.itemTexture = texture;
        n.Value = value;
        n.type = type;
        n.useType = useType;
        n.isClickable = clickable;
        n.isStackable = stackable;
        n.ItemID = itemID;
        n.manaStack = manaStack;

        Debug.Log("New Item, Name=" + n.itemConfName + " Value=" + n.Value + " Type=" + n.type.ToString() + " useType=" + n.useType.ToString() + " isClickable=" + n.isClickable + " isStackable=" + n.isStackable + " ItemID=" + n.ItemID + " manaStack=" +n.manaStack);

        if (InventoryItems.Exists(x => x.ItemID == n.ItemID && n.isStackable))
        { 
            foreach(ItemConf i in InventoryItems)
            {
                if(i.ItemID == n.ItemID)
                { 
                    Debug.Log("SAME ITEM EXISTS");
                    i.Stack++;
                }
            }           
        }
        else
        {
            Debug.Log("ITEM ID DOESN'T EXIST, CREATE NEW ENTRY");
            InventoryItems.Add(n);
        }
        Debug.Log(n.itemConfName + " Has been added to inventroy");
    }

    public void RemoveItem(ItemConf item)
    {//Removed an item from the inventory.

        InventoryItems.Remove(item);
    }

    public void UseItem(ItemConf.ItemType type,  ItemConf.ItemConsumable useType, int value, ItemConf item)
    {
        //check the item id, get the item type. then use it.
        switch(type)
        {
            case ItemConf.ItemType.Consumable:

                switch (useType)
                {
                    case ItemConf.ItemConsumable.Health:
                        if(item.Stack > 0)
                        {
                            item.Stack--;
                            UseConsumable(0, value);
                            Debug.Log("I have more then 1 in my stack i currently have =" + item.Stack);
                        }
                        else
                        {
                            Debug.Log("I Only have 1 of my item, so i would like to use it Current Count=" + item.Stack);
                            RemoveItem(item);
                        }
                        break;
                    case ItemConf.ItemConsumable.Mana:
                        if(item.manaStack > 0)
                        {
                            item.manaStack--;
                            UseConsumable(1, value);
                            Debug.Log("I have more then 1 in my stack i currently have =" + item.manaStack);
                        }
                        else
                        {
                            Debug.Log("I Only have 1 of my item, so i would like to use it Current Count=" + item.manaStack);
                            RemoveItem(item);
                        }
                        break;
                }
                break;

            case ItemConf.ItemType.Equipment:
                RemoveItem(item);
                Debug.Log("Im Equipment");
                break;
            case ItemConf.ItemType.Quest:
             //   RemoveItem(item);
                Debug.Log("Im Quest");
                break;
        }
    }

    void UseConsumable(int type, int value)
    {
        switch (type)
        {
            case 0://Health
                config.playerHealth.curHealth += value;
                break;
            case 1://Mana
                break;

        }
    }
}