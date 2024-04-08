using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    // This is the blueprint for our scriptable object

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefualtItem = false;

    public virtual void Use ()
    {
        // Use the item

        Debug.Log("Using " + name);
    }
    
    public void MoveItem()
    {

    }


}
