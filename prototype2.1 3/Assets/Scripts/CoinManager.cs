using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    private int coinCount;

    // Start is called before the first frame update
    void Start()
    {
        coinCount = PlayerPrefs.GetInt("Coins", 0);
        UpdateCoinUI();
    }

    public void AddCoins(int amount)
    {
        // Debug.Log("adding them here");
        // Increase coin count and update PlayerPrefs
        coinCount += amount;
        PlayerPrefs.SetInt("Coins", coinCount);
        PlayerPrefs.Save();
        Debug.Log("Coins updated: " + coinCount);
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        // Update the coin count text
        coinText.text = "x " + coinCount.ToString();
    }
    
    public void ResetCoins()
    {
        // Reset coin count to 0 (if you need a reset function)
        coinCount = 0;
        PlayerPrefs.SetInt("Coins", coinCount);
        PlayerPrefs.Save();
        UpdateCoinUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
