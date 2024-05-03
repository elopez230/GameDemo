using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    // Method for interacting and starting the battle
    public void TriggerBattle()
    {
        FindObjectOfType<battleSystem>().setupBattle();
    }

}
