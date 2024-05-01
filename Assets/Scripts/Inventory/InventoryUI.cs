using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;

    public Transform itemsParent;
    public GameObject inventoryUI;
    public bool InventoryActive;

    Inventory inventory;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {   
        InventoryActive = false;
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            if (InventoryActive == false)
            {
                InventoryActive = true;
            } else
            {
                InventoryActive = false;
            }
        }
    }

    // Adds items to inventory slots and clears inventory slots
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            } else
            {
                slots[i].ClearSlot();
            }
        }
        Debug.Log("UPDATING UI");
    }

    public void moveEquipment(Item item, int slotIndex) // Not being passed as an item
    {
        slots[slotIndex].AddItem(item); // This statement has problems
    }


    public void DialogueActive()
    {
        if (InventoryActive == true)
        {
            inventoryUI.SetActive(false);
        }
    }

}
