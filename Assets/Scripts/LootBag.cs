using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{

    public List<Loot> lootList = new List<Loot>();
 
    Loot GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if (possibleItems.Count > 0)
        {
            Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        Debug.Log("No loot dropped");
        return null;
    }

    // This will be called when a chest is opened
    // Code spawning the item to inventory will still be needed
    public void InstantiateLoot()
    {
        Loot droppedItem = GetDroppedItem();
    }
}