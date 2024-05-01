using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{

    public List<Item> lootList = new List<Item>();
    public string itemName;
 
    // Randomizes the dropped item from possible items
    Item GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<Item> possibleItems = new List<Item>();
        foreach (Item item in lootList)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if (possibleItems.Count > 0)
        {
            Item droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            itemName = droppedItem.name;
            return droppedItem;
        }
        Debug.Log("No loot dropped");
        return null;
    }

    // This will be called when a chest is opened
    public void InstantiateLoot()
    {
        Item droppedItem = GetDroppedItem();// Where Item gets passed
        Debug.Log("Dropped " + itemName);
        Inventory.instance.Add(droppedItem);// Adds item to inventory
    }
}
