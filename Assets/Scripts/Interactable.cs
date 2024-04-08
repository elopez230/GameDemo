using UnityEngine;

public class NewBehaviourScript : ColliderObject
{
    private bool z_Interacted = false;
    protected override void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            OnInteract();
        }
    }

    protected virtual void OnInteract()
    {
        if(!z_Interacted)
        {
            z_Interacted = true;
            Debug.Log("Interacted with " + name);
        }
    }
}
