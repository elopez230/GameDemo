using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    // Singleton to call an instance of EquipmentManager
    #region Singleton

    public static EquipmentManager instance;

    void Awake ()
    {
        instance = this;
    }

    #endregion

    Equipment[] currentEquipment;

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    // This will equip items into the corresponding slots
    // The slots the equipment will be moved into is in the equipment manager / currentEquipment array
    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
    

        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        currentEquipment[slotIndex] = newItem;
    }

}
