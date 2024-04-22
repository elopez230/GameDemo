using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TreeEditor;
using UnityEngine.InputSystem.Processors;


public enum battleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }


public class battleSystem : MonoBehaviour
{
    public battleState state;
    public GameObject player;
    Unit playerUnit;
    public GameObject enemy;
    Unit enemyUnit;

    public Transform EnemySpawn;
   
    public TMP_Text enemyHP;
    public TMP_Text playerHP;



    void Start()
    {
        state = battleState.START;
        setupBattle();

        playerTurn();
    }

    IEnumerator setupBattle()
    {
        GameObject playerGO = Instantiate(player, EnemySpawn);
        playerUnit = playerGO.GetComponent<Unit>();
        battleUpdate(("Your HP: " + playerUnit.currentHP), playerHP);

        GameObject enemyGO = Instantiate(enemy, EnemySpawn);
        enemyUnit = enemyGO.GetComponent<Unit>();
        battleUpdate((enemyUnit.name + " HP: " + enemyUnit.currentHP), enemyHP);

        yield return new WaitForSeconds(2f);

    }

    void battleUpdate(string updateMes, TMP_Text location) // Or other method
    {
        location.SetText(updateMes);
    }

    void playerTurn()
    {

    }

    void enemyTurn()
    {

    }

    public void onAttackButton()
    {
        if (state != battleState.PLAYERTURN)
        {
            return;
        }

    }

    IEnumerator playerAttack()
    {
        int damage = Random.Range(1, playerUnit.maxAttack);
        bool dead = enemyUnit.takeDamage(damage);
        battleUpdate((enemyUnit.name + " HP: " + enemyUnit.currentHP), enemyHP);

        yield return new WaitForSeconds(2f);

        if (dead)
        {
            state = battleState.WON;
        }
        else
        {
            state = battleState.ENEMYTURN;
        }

    }

    void endBattle()
    {
        //Eli this is where we need to return back to open world
        if(state == battleState.WON)
        {

        }
    }


}
