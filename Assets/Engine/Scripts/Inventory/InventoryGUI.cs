using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryGUI : MonoBehaviour
{
    public Texture2D backDrop;
    public Vector2 windowPosition = new Vector2(200, 200);
    public Vector2 windowSize = new Vector2(96.0f, 96.0f);
    public Vector2 itemIconSize = new Vector2(32.0f, 32.0f);
    private Inventory inventory;
    private bool showInventory;

    void Start()
    {
        if(inventory == null)
        {
            inventory = GetComponent<Inventory>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            showInventory = !showInventory;
        }
    }

    void OnGUI()
    {
        if (showInventory)
        {
            var currentX = windowPosition.x;
            var currentY = windowPosition.y;
            GUI.DrawTexture(new Rect(windowPosition.x, windowPosition.y, windowSize.x, windowSize.y), backDrop, ScaleMode.StretchToFill);

            for (int i = 0; i < inventory.InventoryItems.Count; i++)
            {
                var item = inventory.InventoryItems[i];
                if (GUI.Button(new Rect(currentX, currentY, itemIconSize.x, itemIconSize.y), inventory.InventoryItems[i].itemTexture))
                {
                    inventory.UseItem(inventory.InventoryItems[i].type, inventory.InventoryItems[i].useType, inventory.InventoryItems[i].Value, inventory.InventoryItems[i].ItemID);
                }
                currentX += itemIconSize.x;
                if (currentX + itemIconSize.x > windowPosition.x + windowSize.x)
                {
                    currentX = windowPosition.x;
                    currentY += itemIconSize.y;
                    if (currentY + itemIconSize.y > windowPosition.y + windowSize.y)
                    {
                        return;
                    }
                }
            }
        }
        
    }
}