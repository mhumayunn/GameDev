using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] studentPrefabs;
    public Transform spawnPoint;
    public TMP_Text timerText;
    public TMP_Text scoreText;
    private float spawnInterval = 2f;
    private float timer = 0f;
    public float gameTime = 30f;
    private bool isGameActive = true;
    public int happinessCoins = 0; // Track happiness coins
    private List<GameObject> activeStudents = new List<GameObject>(); // Track active students

    public bool IsGameActive // Property to check if the game is active
    {
        get { return isGameActive; }
    }

    void Update()
    {
        if (isGameActive)
        {
            timer += Time.deltaTime;

            if (timer >= spawnInterval)
            {
                SpawnStudent();
                timer = 0f;
            }

            Debug.Log("You Win!");
            gameTime -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Floor(gameTime).ToString();

            if (gameTime <= 0)
            {
                EndGame();
            }
        }
    }

    void SpawnStudent()
    {
        int randomIndex = Random.Range(0, studentPrefabs.Length);
        GameObject student = Instantiate(studentPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
        activeStudents.Add(student); // Track the active student
    }

    void EndGame()
    {
        isGameActive = false;
        if (happinessCoins >= 12)
        {
            timerText.text = "You Win!";
            Debug.Log("You Win!");
        }
        else
        {
            timerText.text = "Game Over!";
            Debug.Log("Game Over");
        }

        // Destroy all remaining students
        foreach (GameObject student in activeStudents)
        {
            Destroy(student);
        }
        activeStudents.Clear(); // Clear the list
    }

    public void IncreaseHappinessCoins()
    {
        happinessCoins += 1;
        scoreText.text = "Score: " + happinessCoins.ToString();
        Debug.Log("Happiness Coins: " + happinessCoins);
    }
}
