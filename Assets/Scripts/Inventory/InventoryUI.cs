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

    public void moveItem(Item item, int slot)
    {
        slots[slot].AddItem(item);
    }


    public void DialogueActive()
    {
        if (InventoryActive == true)
        {
            inventoryUI.SetActive(false);
        }
    }

}
