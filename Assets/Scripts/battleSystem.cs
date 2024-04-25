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
    static public int damageDone;
    bool attackBuff;

    NPCscript npcScript;
    

    void Start()
    {
        npcScript = GameObject.FindGameObjectWithTag("NPC").GetComponent<NPCscript>();
    }

    public void setupBattle()
    {
        state = battleState.START;
        attackBuff = false;

        damageDone = 0;
        GameObject playerGO = Instantiate(player, EnemySpawn);
        playerUnit = playerGO.GetComponent<Unit>();
        battleUpdate(("Your HP: " + playerUnit.currentHP), playerHP);

        GameObject enemyGO = Instantiate(enemy, EnemySpawn);
        enemyUnit = enemyGO.GetComponent<Unit>();
        battleUpdate((enemyUnit.name + " HP: " + enemyUnit.currentHP), enemyHP);

        state = battleState.PLAYERTURN;
        Debug.Log("Your Turn");
    }

    void battleUpdate(string updateMes, TMP_Text location) // Or other method
    {
        location.SetText(updateMes);
    }


    public void onAttackButton()
    {
        
        if (state != battleState.PLAYERTURN)
        {
            return;
        }
        
        StartCoroutine(playerAttack());
       
    }

    IEnumerator playerAttack()
    { 
        damageDone = Random.Range(1, playerUnit.maxAttack);
        bool dead = false;

        if (attackBuff)
        {
            damageDone = damageDone + 2;
        }
        dead = enemyUnit.takeDamage(damageDone);
        Debug.Log("You deal " + damageDone + " damage");

        battleUpdate(("Your HP: " + playerUnit.currentHP), playerHP);

        yield return new WaitForSeconds(2f);

        if (dead)
        {
            state = battleState.WON;
            endBattle();
            Debug.Log("You Win");
        }
        else
        {
            state = battleState.ENEMYTURN;
            enemyAttack();
        }

        

    }

    void endBattle()
    {
        npcScript.NpcDead();
        //Eli this is where we need to return back to open world
        if(state == battleState.WON)
        {

            Debug.Log("Thank you so much for participating in my playtest!");
        }
        else
        {
            Debug.Log("Thank you so much for participating in my playtest!");
        }
    }

    public static int getDamageDone()
    {
        return damageDone;
    }

    void enemyAttack()
    {

        Debug.Log("Enemy Turn");
        damageDone = Random.Range(1, enemyUnit.maxAttack);
        bool dead = playerUnit.takeDamage(damageDone);
        battleUpdate((enemyUnit.name + " HP: " + enemyUnit.currentHP), enemyHP);
        Debug.Log("You take " + damageDone + " damage");

        if (dead)
        {
            state = battleState.LOST;
            Debug.Log("You lose :(");
            endBattle();
        }
        else
        {
            state = battleState.PLAYERTURN;
            Debug.Log("Your Turn");
        }
    }

    public void playerRally()
    {
        int choice = Random.Range(1, 3);
        if (choice == 1)
        {
            int heal = Random.Range(1, 3);
            playerUnit.healDamage(heal);
            Debug.Log("You gain back " + heal + " health");
        }
        else if (choice == 2)
        {
            Debug.Log("You will deal 2 more damage next attack");
            attackBuff = true;
        }
        else
        {
            Debug.Log("Currently you gain nothing");
        }
        

        state = battleState.ENEMYTURN;
        enemyAttack();

    }


}
