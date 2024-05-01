using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public int equipSlot;

    public int armorModifier;
    public int damageModifier;

    void Start()
    {

    }

    public override void Use()
    {
        Start();
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
        // Do not remove item from inventory, Send item to proper inventory slot
    }
}

public enum EquipmentSlot { Head, Chest, Legs, Boots, Weapon, Item}
