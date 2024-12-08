using UnityEngine;

public class OrderPanelController : MonoBehaviour
{
    public RectTransform orderPanel; // Drag your order panel UI element here in the Inspector
    private Vector2 originalPosition; // To store the initial position of the panel
    private Vector2 minimizedPosition = new Vector2(100, -100); // Top-right corner position
    private Vector2 originalSize; // To store the original size of the panel
    private Vector2 minimizedSize = new Vector2(200, 100); // Size when minimized
    private bool isMinimized = false; // Track the state of the panel

    void Start()
    {
        // Save the original position and size of the panel
        originalPosition = orderPanel.anchoredPosition;
        originalSize = orderPanel.sizeDelta;
    }

    public void TogglePanel()
    {
        if (isMinimized)
        {
            // Restore the panel to its original state
            orderPanel.anchoredPosition = originalPosition;
            orderPanel.sizeDelta = originalSize;
            isMinimized = false;
        }
        else
        {
            // Minimize the panel to the top-right corner
            orderPanel.anchoredPosition = minimizedPosition;
            orderPanel.sizeDelta = minimizedSize;
            isMinimized = true;
        }
    }
}