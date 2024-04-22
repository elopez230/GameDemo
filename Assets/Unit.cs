using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitHP;

    public int currentHP;
    public int maxAttack;

    public string name;

    public bool takeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
