using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIButtons : MonoBehaviour
{
    public GameObject combatCanvas;
    public GameObject menuCanvas;
    public Text combatText;
    public Button fightButton;
    public Button actButton;
    public Button rallyButton;
    public Button escapeButton;
    public float displayDuration = 10f;

    private int currentState = 0;

    public void ToggleVisibility()
    {
        combatCanvas.SetActive(currentState == 0);
        menuCanvas.SetActive(currentState == 1);

        if (currentState == 0)
        {
            Debug.Log("Toggling visibility: Combat Canvas On, Menu Canvas Off");
        }
        else
        {
            Debug.Log("Toggling visibility: Combat Canvas Off, Menu Canvas On");
        }

        currentState = 1 - currentState;
    }

    public void FightButton()
    {
        StartCoroutine(DisplayCombatText("Combat Started!"));
    }

    public void ActButton()
    {
        Debug.Log("Act button clicked!");

        fightButton.gameObject.SetActive(false);
        rallyButton.gameObject.SetActive(false);
        escapeButton.gameObject.SetActive(false);

        StartCoroutine(DisplayCombatText("Act button clicked!"));
    }

    public void RallyButton()
    {
        Debug.Log("Rally button clicked!");
    }

    public void EscapeButton()
    {
        Debug.Log("Escape button clicked!");
    }

    IEnumerator DisplayCombatText(string text)
    {
        combatText.gameObject.SetActive(true);
        combatText.text = text;
        yield return new WaitForSeconds(displayDuration);
        combatText.gameObject.SetActive(false);
    }
}
