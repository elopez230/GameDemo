using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{

    public int equipSlot;

    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        //InventoryUI.instance.moveItem(InventorySlot.slots, 17);
        // Do not remove item from inventory, Send item to proper inventory slot
    }
}

public enum EquipmentSlot { Head, Chest, Legs, Boots, Weapon, Item}
