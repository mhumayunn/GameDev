using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 offset;
    private bool isDragging;
    private bool isPlacedCorrectly = false;
    private GameManager gameManager;

    void Start()
    {
        initialPosition = transform.position; // Store initial position for reset
        gameManager = FindObjectOfType<GameManager>(); // Get reference to GameManager
    }

    void OnMouseDown()
    {
        if (!isPlacedCorrectly && gameManager.IsGameActive) // Only allow dragging if not placed correctly and game is active
        {
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }
    }

    void OnMouseDrag()
    {
        if (isDragging && !isPlacedCorrectly && gameManager.IsGameActive)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            newPosition.z = 0; // Keep it in the 2D plane
            transform.position = newPosition;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        CheckPlacement(); // Check placement after dropping
    }

    public void CheckPlacement()
    {
        if (!isPlacedCorrectly) // If not correctly placed, reset position
        {
            transform.position = initialPosition;
        }
    }

    public void MarkAsPlaced()
    {
        isPlacedCorrectly = true; // Lock in position if correctly placed
    }
}
