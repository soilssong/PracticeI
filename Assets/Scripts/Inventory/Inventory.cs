using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{

    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
        Debug.Log("Inventory");

        addItem(new Item { itemType = Item.ItemType.Sword, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.Sword, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
        addItem(new Item { itemType = Item.ItemType.Coin, amount = 1 });
        foreach (Item Item in itemList)
        {
            Debug.Log(Item.itemType);
        }
    }


    public void addItem(Item item)
    {
        itemList.Add(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
