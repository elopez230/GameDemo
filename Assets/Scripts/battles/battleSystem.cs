using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
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
    public TMP_Text popUp;
    public TMP_Text enemyHP;
    public TMP_Text playerHP;
    static public int damageDone;
    bool attackBuff;
    public FightButton popUpMethod;
    Inventory items = Inventory.instance;
    Item actItem;
    string reaction;
    string failed;


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
        actItem = enemyUnit.getItem();
        Debug.Log("Your Turn");
        items = Inventory.instance;
        reaction = enemyUnit.getReaction();
        failed = enemyUnit.getFailed();
    }
    void textUpdate(string updateMes, TMP_Text location) // Or other method
    {
        location.SetText(updateMes);
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

        int d20Roll = Random.Range(1, 20);

        if (d20Roll == 1)
        {
            dead = playerUnit.takeDamage(damageDone);
            textUpdate(("Critical Failure:\n You Take " + damageDone + " Damage"), popUp);
            textUpdate(("Your HP: " + playerUnit.currentHP), playerHP);
            if (dead)
            {
                state = battleState.LOST;
            }
            else
            {
                state = battleState.ENEMYTURN;
                enemyAttack();
            }

        }
        else if (d20Roll <= 3 && d20Roll != 1)
        {
            textUpdate(("You Miss"), popUp);
        }
        else
        {
            d20Roll = Random.Range(1, 20);

            if (d20Roll >= 19)
            {
                dead = enemyUnit.takeDamage(2 * damageDone);

                textUpdate((enemyUnit.name + " HP: " + enemyUnit.currentHP), enemyHP);
                textUpdate(("Critical Hit:\nYou Deal " + (2 * damageDone) + " Damage"), popUp);
                Debug.Log("Player CAtack");
            }
            else
            {
                dead = enemyUnit.takeDamage(damageDone);

                textUpdate((enemyUnit.name + " HP: " + enemyUnit.currentHP), enemyHP);
                textUpdate(("You Deal " + (damageDone) + " Damage"), popUp);
                Debug.Log("Player NAtack");
            }
        }


        yield return new WaitForSeconds(3f);


        if (dead && d20Roll != 1)
        {
            state = battleState.WON;
            endBattle();
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
        FindObjectOfType<ToggleCanvasOnKeyPress>().ChangeVisiablity();
        //Eli this is where we need to return back to open world
        if (state == battleState.WON)
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


        damageDone = Random.Range(1, enemyUnit.maxAttack);
        bool dead = false;

        if (attackBuff)
        {
            damageDone = damageDone + 2;
        }

        int d20Roll = Random.Range(1, 20);

        if (d20Roll == 1)
        {
            dead = enemyUnit.takeDamage(damageDone);
            textUpdate(("Critical Failure:\nEnemy Takes " + damageDone + " Damage"), popUp);
            textUpdate((enemyUnit.name + " HP: " + enemyUnit.currentHP), enemyHP);
            popUpMethod.OnClick();
            if (dead)
            {
                state = battleState.WON;
                endBattle();
            }
            else
            {
                state = battleState.PLAYERTURN;
            }

        }
        else if (d20Roll <= 3 && d20Roll != 1)
        {
            textUpdate(("Enemy Misses"), popUp);
            popUpMethod.OnClick();
        }
        else
        {
            d20Roll = Random.Range(1, 20);

            if (d20Roll >= 19)
            {
                dead = playerUnit.takeDamage(2 * damageDone);
                textUpdate(("Your HP: " + playerUnit.currentHP), playerHP);
                textUpdate(("Critical Hit: \n" + enemyUnit.name + " Deals " + (2 * damageDone) + " Damage"), popUp);
                popUpMethod.OnClick();
                Debug.Log("Enemy CAtack");
            }
            else
            {
                dead = playerUnit.takeDamage(damageDone);

                textUpdate(("Your HP: " + playerUnit.currentHP), playerHP);
                textUpdate((enemyUnit.name + " Deals " + (damageDone) + " Damage"), popUp);
                popUpMethod.OnClick();
                Debug.Log("Enemy CAtack");
            }
        }
        if (dead)
        {
            state = battleState.LOST;
            endBattle();
        }
        else
        {
            state = battleState.PLAYERTURN;
        }
    }

    public void onRallyButton()
    {

        if (state != battleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(playerRally());

    }

    public IEnumerator playerRally()
    {
        int choice = Random.Range(1, 3);
        if (choice == 1)
        {
            int heal = Random.Range(1, 3);
            playerUnit.healDamage(heal);
            textUpdate("You gain back " + heal + " health", popUp);
            textUpdate(("Your HP: " + playerUnit.currentHP), playerHP);
            popUpMethod.OnClick();
            
        }
        else if (choice == 2)
        {
            textUpdate("You will deal 2 more damage next attack", popUp);
            attackBuff = true;
            popUpMethod.OnClick();
        }
        else
        {
            textUpdate("You gain nothing", popUp);
            popUpMethod.OnClick();
        }

        yield return new WaitForSeconds(3f);

        state = battleState.ENEMYTURN;
        enemyAttack();

    }

    public void onActButton()
    {

        if (state != battleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(playerAct());

    }

    IEnumerator playerAct()
    {
        int amount = items.ScanSpecific(actItem);
        Debug.Log(amount);

        if (amount >= 1)
        {
            
            textUpdate(reaction, popUp);
            popUpMethod.OnClick();
            yield return new WaitForSeconds(3f);
            endBattle();
            items.Remove(actItem);
        }
        else
        {
            textUpdate(failed, popUp);
            popUpMethod.OnClick();
            yield return new WaitForSeconds(3f);
            enemyAttack();
        }
        
    }


}
