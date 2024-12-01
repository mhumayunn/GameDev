using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuisineLineManager : MonoBehaviour
{
    public Color lineColor; // Color of the line
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // Get reference to GameManager
    }

    bool ColorsAreSimilar(Color a, Color b, float tolerance = 0.1f)
    {
        return Mathf.Abs(a.r - b.r) < tolerance &&
               Mathf.Abs(a.g - b.g) < tolerance &&
               Mathf.Abs(a.b - b.b) < tolerance;
        // Ignore a.a - b.a comparison since alpha doesn’t matter
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameManager.IsGameActive) // Prevent processing if the game is over
        {
            return; // Exit if the game is not active
        }

        if (other.CompareTag("Student"))
        {
            DragAndDrop dragScript = other.GetComponent<DragAndDrop>();
            SpriteRenderer studentRenderer = other.GetComponent<SpriteRenderer>();
            Debug.Log("Student Color: " + studentRenderer.color);
            Debug.Log("Line Color: " + lineColor);

            if (ColorsAreSimilar(studentRenderer.color, lineColor)) // Correct line
            {
                dragScript.MarkAsPlaced();
                other.transform.position = this.transform.position;
                gameManager.IncreaseHappinessCoins();
                Debug.Log("Correct Match!");
            }
            else // Incorrect line
            {
                Debug.Log("Wrong Cuisine!");
                dragScript.CheckPlacement(); // This will reset position if wrong
            }
        }
    }
}
