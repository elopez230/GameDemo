using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{

    InventoryUI inventoryUI;


    public int equipSlot;

    public int armorModifier;
    public int damageModifier;

    void Start()
    {
        inventoryUI = InventoryUI.instance;
    }

    public override void Use()
    {
        Start();
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
        InventoryUI.instance.moveEquipment(this, 17); // Cant be this has to be item
        // Do not remove item from inventory, Send item to proper inventory slot
    }
}

public enum EquipmentSlot { Head, Chest, Legs, Boots, Weapon, Item}
