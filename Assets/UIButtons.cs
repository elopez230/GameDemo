using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIButtons : MonoBehaviour
{

    public GameObject FightButton1;
    public GameObject ActButton1;
    public GameObject RallyButton1;
    public GameObject EscapeButton1;
    
    


    private bool isToggling = false;
    private int currentState = 0;
    public void ToggleVisibility()
    {
        GameObject combatCanvasObj = GameObject.Find("CombatCanvas");
        GameObject menuCanvasObj = GameObject.Find("MenuCanvas");

        if (combatCanvasObj == null)
        {
            Debug.LogError("CombatCanvas is not assigned!");
            return;
        }

        if (menuCanvasObj == null)
        {
            Debug.LogError("MenuCanvas is not assigned!");
            return;
        }

        Canvas combatCanvas = combatCanvasObj.GetComponent<Canvas>();
        Canvas menuCanvas = menuCanvasObj.GetComponent<Canvas>();

        if (combatCanvas == null)
        {
            Debug.LogError("CombatCanvas is missing Canvas component!");
            return;
        }

        if (menuCanvas == null)
        {
            Debug.LogError("MenuCanvas is missing Canvas component!");
            return;
        }

        // Ensure combat canvas is always active
        combatCanvas.enabled = true;

        // Toggle visibility based on the current state
        combatCanvas.enabled = currentState == 0;
        menuCanvas.enabled = currentState == 1;

        // Log the toggling action
        if (currentState == 0)
        {
            Debug.Log("Toggling visibility: Combat Canvas On, Menu Canvas Off");
        }
        else
        {
            Debug.Log("Toggling visibility: Combat Canvas Off, Menu Canvas On");
        }

        // Switch the state systematically
        currentState = 1 - currentState;
    }









    void FightButton()
    {

    }
    void ActButton()
    {

    }
    void RallyButton()
    {

    }
    void EscapeButton()
    {

    }
}

