using UnityEngine;
using System.Collections;

[System.Serializable]
public class ItemConf {

    public int ItemID;
    public string itemConfName;
    public Texture itemTexture;
    public float Value;

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
