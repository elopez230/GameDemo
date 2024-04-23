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
        if (currentHP < 0)
        {
            currentHP = 0;
            return true;
        } 
        else if (currentHP == 0) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void healDamage(int damage)
    {
        currentHP += damage;
        if (currentHP > unitHP) 
        {
            currentHP = unitHP;
        }
       
    }
}
