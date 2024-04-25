using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    // This is the blueprint for our scriptable object

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefualtItem = false;
    public int dropChance;

    public virtual void Use () // Can be called and overriden
    {
        // Use the item

        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
    

    public bool IsStackable()
    {
        return false;
    }

  

}
