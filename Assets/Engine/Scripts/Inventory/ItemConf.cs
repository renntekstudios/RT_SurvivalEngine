using UnityEngine;
using System.Collections;

[System.Serializable]
public class ItemConf {

    public string itemConfName;
    public Texture itemTexture;
    public int Value;
    public bool isClickable;
    public int Stack;
    public int ItemID;
    public bool isStackable;
    public int manaStack;

    public enum ItemType
    {
        Consumable,
        Quest,
        Equipment
    }
    public ItemType type = ItemType.Quest;

    public enum ItemConsumable
    {
        None,
        Health,
        Mana
    }
    public ItemConsumable useType = ItemConsumable.None;
}
