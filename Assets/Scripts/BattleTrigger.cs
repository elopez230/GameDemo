using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    
    public void TriggerBattle()
    {
        FindObjectOfType<battleSystem>().setupBattle();
    }

}
