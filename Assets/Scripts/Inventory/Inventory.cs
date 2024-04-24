using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public int space = 25;

    public static Inventory instance;

    void Awake ()
    {
        if (instance != null )
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;

    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>(); // Inventory

    public bool Add (Item item) // Add item to inventory
    {
        if (!item.isDefualtItem)
        {
            if ( items.Count >=  space )
            {
                Debug.Log("Not enough room");
                return false;
            }
            items.Add(item);

            if (onItemChangedCallback != null )
            {
                onItemChangedCallback.Invoke();
            }
        }

        return true;
    }

    public void Remove (Item item) // Remove Item from inventory
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void ScanInventory()
    {
        foreach (Item item in items)
        {
            Debug.Log("Item: " + item.name);
        }
    }

}
