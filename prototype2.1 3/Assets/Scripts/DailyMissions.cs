using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class DailyMissions : MonoBehaviour
{
    public GameObject panel;
    public Image check1; 
    public Image check4; 

    public TextMeshProUGUI task1Text;
    public CoinManager coinManager;
    public int coinsToReward = 10;
    
    private const string TASK1_KEY = "Task1Completed";
    private const string REWARD_KEY = "Task1RewardGiven";

    void Start()
    {
        bool task1Completed = PlayerPrefs.GetInt(TASK1_KEY, 0) == 1;
        UpdateTaskUI(task1Completed);
    }

    public void OpenDailyMissions()
    {
        if(panel != null)
        {
            panel.SetActive(true);
        }
    }

    public void CloseDailyMissions() 
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    public void CompleteTask1()
    {
        PlayerPrefs.SetInt(TASK1_KEY, 1);
        PlayerPrefs.Save();
        UpdateTaskUI(true);
        CheckAllTasksCompleted();
    }

    private void CheckAllTasksCompleted()
    {
        if (PlayerPrefs.GetInt(TASK1_KEY, 0) == 1 && PlayerPrefs.GetInt(REWARD_KEY, 0) == 0)
        {
            //givingg coins
            Debug.Log("Adding coinsss!");
            coinManager.AddCoins(coinsToReward);
            PlayerPrefs.SetInt(REWARD_KEY, 1); // Mark reward as given
            PlayerPrefs.Save();
        }
    }

    private void UpdateTaskUI(bool task1Completed)
    {
        if (task1Completed)
        {
            task1Text.text = "Task 1: Completed!";
            Debug.Log("Task for day DONE!");
            check1.sprite = check4.sprite;
        }
        else
        {
            check1.sprite = null; 
            task1Text.text = "Task 1: Interact with NPC";
        }
    }
}
