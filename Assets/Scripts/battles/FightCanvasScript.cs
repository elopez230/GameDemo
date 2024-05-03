using UnityEngine;

public class ToggleCanvasOnKeyPress : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public KeyCode keyToToggleCanvas = KeyCode.Space;

    // Flag to track the current state of the Canvas
    private bool canvasVisible = false;

    void Start()
    {
        // Ensure that the Canvas starts as invisible
        canvasGroup.alpha = 0f;
    }

    void Update()
    {
        // Check if the specified key is pressed
        if (Input.GetKeyDown(keyToToggleCanvas))
        {
            // Toggle the visibility of the Canvas
            canvasVisible = !canvasVisible;

            // Set the Canvas alpha based on the current state
            canvasGroup.alpha = canvasVisible ? 1f : 0f;
        }
    }

    public void ChangeVisiablity()
    {
        canvasVisible = !canvasVisible;


        canvasGroup.alpha = canvasVisible ? 1f : 0f;
    }

}
