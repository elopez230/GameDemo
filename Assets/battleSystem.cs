using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum battleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }


public class battleSystem : MonoBehaviour
{
    public battleState state;
    public GameObject player;
    Unit playerUnit;
    public GameObject enemy;
    Unit enemyUnit;

    public Transform EnemySpawn;

    void Start()
    {
        state = battleState.START;
        setupBattle();
       
    }

    void setupBattle()
    {
        GameObject playerGO = Instantiate(player, EnemySpawn);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemy, EnemySpawn);
        enemyUnit = enemyGO.GetComponent<Unit>();
    }
}
