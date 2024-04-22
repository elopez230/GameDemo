using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightButton : MonoBehaviour
{
    public GameObject imagePrefab;          // Reference to the image prefab to instantiate
    public GameObject textPrefab;           // Reference to the text prefab to instantiate
    public int canvasSortingOrder = 1;      // Sorting order for the instantiated images
    public float distanceFromCamera = 5f;   // Distance from the camera to place the prefabs
    public float displayDuration = 3f;      // Duration to display the prefabs before hiding them
    
    private Button button;
    private Canvas activeCanvas;            // Reference to the active canvas

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        
        Debug.Log("Fight button clicked!");



        // Find the active canvas in the scene
        activeCanvas = FindObjectOfType<Canvas>();

        // Ensure there is an active canvas
        if (activeCanvas != null)
        {
            // Calculate the position in front of the camera
            Vector3 spawnPosition = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;

            // Instantiate the image prefab as a child of the active canvas
            GameObject imageInstance = Instantiate(imagePrefab, activeCanvas.transform);
            // Set the local position of the image prefab to match its intended position on the canvas
            RectTransform imageRectTransform = imageInstance.GetComponent<RectTransform>();
            // Set the local position based on your desired values
            imageRectTransform.localPosition = new Vector3(0.5f, 0.5f, 0f);
            // Set the rect transform settings
            imageRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            imageRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            imageRectTransform.offsetMin = new Vector2(-0.05f, -0.05f);
            imageRectTransform.offsetMax = new Vector2(0.05f, 0.05f);
            // Set the sizeDelta to adjust the scaling of the image
            imageRectTransform.sizeDelta = new Vector2(50f, 50f);

            // Instantiate the text prefab as a child of the active canvas
            GameObject textInstance = Instantiate(textPrefab, activeCanvas.transform);
            // Set the local position of the text prefab to match its intended position on the canvas
            RectTransform textRectTransform = textInstance.GetComponent<RectTransform>();
            // Set the local position based on your desired values
            textRectTransform.localPosition = new Vector3(0.5f, 0.5f, 0f);
            // Set the sizeDelta to adjust the size of the text rectangle
            textRectTransform.sizeDelta = new Vector2(50f, 10f); // Adjust width and height as desired for smaller size

            // Get the Text component of the text prefab
            Text textComponent = textInstance.GetComponent<Text>();

            if (textComponent != null)
            {
                textComponent.fontSize = 8;
            }// Adjust the font size as desired for smaller text
            
            // Set the canvas sorting order of both prefabs
            Canvas canvas = imageInstance.GetComponent<Canvas>();
            if (canvas != null)
            {
                canvas.sortingOrder = canvasSortingOrder;
            }

            canvas = textInstance.GetComponent<Canvas>();
            if (canvas != null)
            {
                canvas.sortingOrder = canvasSortingOrder;
            }

            // Start coroutine to hide prefabs after display duration
            StartCoroutine(HideAfterDuration(imageInstance, textInstance));
        }
        else
        {
            Debug.LogError("No active canvas found in the scene!");
        }

        
    }

    IEnumerator HideAfterDuration(GameObject imageInstance, GameObject textInstance)
    {
        yield return new WaitForSeconds(displayDuration);

        // Destroy the instantiated prefabs
        Destroy(imageInstance);
        Destroy(textInstance);
    }

    public static IEnumerator showDamage(int damage)
    {
        yield return new WaitForSeconds(getDisplayDuration());
    }

    public static int getDisplayDuration()
    {
        return getDisplayDuration();
    }

    public static void setTextPrefab(string message)
    {

    }
}
