using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;  // Import for List<>

public class TextBoxScript : MonoBehaviour
{
    // Reference to the TextBoxPrefab (the 3D object or main object)
    public GameObject textBoxPrefab;

    // Reference to the Canvas prefab (which includes TMP Input Field in World Space)
    public GameObject canvasPrefab;  // The Canvas prefab with TMP InputField as a child

    private string input;
    private bool isInputActive = false;  // Flag to check if user is typing into an InputField

    void Update()
    {
        // Check if there is a touch on the screen and input isn't active
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            Debug.Log("Screen touched!");  // Debug log for touch detection

            // Check if the touch is over a UI element (like the InputField)
            if (!isInputActive && !IsTouchOverUI())
            {
                Debug.Log("Creating TextBoxPrefab!");  // Debug log for spawning a new TextBoxPrefab
                // If the touch is not on a UI element, create a new TextBoxPrefab
                CreateTextBox();
            }
            else
            {
                Debug.Log("Touch was over a UI element. Not creating a new TextBoxPrefab.");
            }
        }
    }

    // Helper method to check if a touch is over a UI element
    bool IsTouchOverUI()
    {
        // Use raycast to detect if the touch is over a UI element (works with the new Input System)
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Touchscreen.current.primaryTouch.position.ReadValue();

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, raycastResults);
        return raycastResults.Count > 0;
    }

    void CreateTextBox()
    {
        if (textBoxPrefab == null)
        {
            Debug.LogError("TextBoxPrefab is not assigned!");
            return;
        }

        Debug.Log("Instantiating TextBoxPrefab...");

        GameObject newTextBoxPrefab = Instantiate(textBoxPrefab, Camera.main.transform.position + Camera.main.transform.forward * 1f, Quaternion.identity);
        Debug.Log("TextBoxPrefab instantiated at position: " + newTextBoxPrefab.transform.position);

        if (canvasPrefab == null)
        {
            Debug.LogError("CanvasPrefab is not assigned!");
            return;
        }

        Debug.Log("Instantiating CanvasPrefab...");

        GameObject newCanvas = Instantiate(canvasPrefab);
        newCanvas.transform.SetParent(newTextBoxPrefab.transform, false);

        newCanvas.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);  // Scale down the entire Canvas (adjust as needed)
        newCanvas.transform.localPosition = new Vector3(0, 1, 0);

        Debug.Log("CanvasPrefab instantiated with scale: " + newCanvas.transform.localScale);

        Canvas canvasComponent = newCanvas.GetComponent<Canvas>();
        if (canvasComponent != null)
        {
            canvasComponent.worldCamera = Camera.main;
            Debug.Log("Assigned Main Camera to Canvas.");
        }
        else
        {
            Debug.LogError("Canvas component is missing!");
        }

        TMP_InputField tmpInputFieldComponent = newCanvas.GetComponentInChildren<TMP_InputField>();
        if (tmpInputFieldComponent != null)
        {
            Debug.Log("TMP InputField found and setting up onEndEdit listener.");
            tmpInputFieldComponent.onEndEdit.AddListener(OnInputEnd);
        }
        else
        {
            Debug.LogError("TMP_InputField component is missing!");
        }

        isInputActive = true;  // Block new prefab spawning while input is active
    }

    // Callback when input in the TMP InputField is complete
    void OnInputEnd(string inputText)
    {
        input = inputText;
        Debug.Log("User input: " + input);
        isInputActive = false;  // Allow new prefabs to be spawned after input is done
    }
}