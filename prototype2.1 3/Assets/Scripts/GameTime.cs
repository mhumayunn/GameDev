using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTime : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay; 
    public GameObject curfewPanel; 

    //declaring all variables neceassary
    private float elapsedTime = 0f;
    private int gameHour = 8; 
    private int gameMinute = 0;
    private int gameSecond = 0; 
    public Button okButton;
    private bool isCurfewActive = false;

    // Start is called before the first frame update
    void Start()
    {
        //will initially hide curfew panel
        curfewPanel.SetActive(false); 
        UpdateTimeDisplay();
        if (okButton != null)
        {
            okButton.onClick.AddListener(CloseCurfewPanel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update time and convert to in-game time
        //120 in-game seconds = 1 real second
        
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 1f / 120f)
        {
            gameSecond++;
            elapsedTime = 0f;

            if (gameSecond >= 60) 
            {
                gameSecond = 0;
                gameMinute++;
            }

            if (gameMinute >= 60) 
            {
                gameMinute = 0;
                gameHour++;
            }
            UpdateTimeDisplay();
        }

        // curfew at 9:00 PM (testing)
        if (gameHour >= 21 && !isCurfewActive)
        {
            TriggerCurfew();
            isCurfewActive = true;
        }
    }
    void TriggerCurfew()
    {
        curfewPanel.SetActive(true);
        Time.timeScale = 0; 
    }
    public void CloseCurfewPanel()
    {
        Debug.Log("CloseCurfewPanel called");
        curfewPanel.SetActive(false);
        Time.timeScale = 1; 
    }

     void UpdateTimeDisplay()
    {
        string period = "AM";
        int displayHour = gameHour;
        
        //formatting the time to pm
      
        if (gameHour >= 12) 
        {
            period = "PM";
            if (gameHour > 12) displayHour -= 12; 
            
        }
        if (displayHour == 0) displayHour = 12;

        string formattedTime = $"{displayHour:00}:{gameMinute:00}:{gameSecond:00} {period}";

        //updating
        timeDisplay.text = formattedTime; 
    }

    //resetting the timer:
    public void ResetTimer()
    {
        elapsedTime = 0f;
        gameHour = 8; 
        gameMinute = 0; 
        gameSecond = 0; 
        UpdateTimeDisplay(); 
        isCurfewActive = false; 
    }
}
