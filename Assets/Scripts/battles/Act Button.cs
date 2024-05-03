using UnityEngine;
using UnityEngine.UI;

public class ActButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Debug.Log("Act button clicked!");
        // Add any other functionality you want to execute when the button is clicked
    }
}
