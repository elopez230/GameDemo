using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlots : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Item item;

    // Add item to the item class
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    // Makes the inventory slot empty
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    // Removes Item from inventory
    public void OnRemoveButton ()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

}
