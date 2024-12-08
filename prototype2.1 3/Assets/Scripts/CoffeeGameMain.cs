using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class CoffeeGameManager : MonoBehaviour
{
    // Change the Text type to TMP_Text
    public TMP_Text milkText;
    public TMP_Text coffeeText;
    public TMP_Text syrupText;
    public GameObject cup;
    public Button milkButton, coffeeButton, syrupButton, greenButton;
    public Button greenButton1, greenButton2, greenButton3;
    public Button PlayAgain;

    // Timer and Game Over Panel
    public TMP_Text timerText; // Update timer text to TMP_Text
    public GameObject gameOverPanel;
    public TMP_Text gameOverText; // Update game over text to TMP_Text
    public TMP_Text correctOrderText; // Text to display correct orders
    public TMP_Text correctOrderTextFinal;
    public TMP_Text wrongOrderText; // Text to display wrong orders
    public TMP_Text wrongOrderTextFinal;

    // Order variables
    private int orderNumber = 0;
    private int currentOrderMilk;
    private int currentOrderCoffee;
    private int currentOrderSyrup;

    // Count variables
    private int milkPressedCount = 0;
    private int coffeePressedCount = 0;
    private int syrupPressedCount = 0;
    private int correctOrders = 0;
    private int wrongOrders = 0;

    private float timer = 30f;
    private bool isGameActive = false;
    private Vector3 cupStartPosition;
    private float cupMoveSpeed = 120f;

    void Start()
    {
        cupStartPosition = cup.transform.position;

        // Green buttons listeners
        greenButton1.onClick.AddListener(() => MoveCup());
        greenButton2.onClick.AddListener(() => MoveCup());
        greenButton3.onClick.AddListener(() => ChangeOrderAndCompare());

        // Ingredient buttons listeners
        milkButton.onClick.AddListener(() => ButtonPressed("milk"));
        coffeeButton.onClick.AddListener(() => ButtonPressed("coffee"));
        syrupButton.onClick.AddListener(() => ButtonPressed("syrup"));

        PlayAgain.onClick.AddListener(() => RestartGameCoffee());

        // Game Over panel initially hidden
        gameOverPanel.SetActive(false);

        // Start the game
        StartCoroutine(StartGame());
    }

    void Update()
    {
        if (isGameActive)
        {
            // Update Timer
            timer -= Time.deltaTime;
            timerText.text = "Time Left: " + Mathf.Ceil(timer) + " seconds";

            // Continuously update correct and wrong order texts
            correctOrderText.text = "Correct Orders: " + correctOrders;
            wrongOrderText.text = "Wrong Orders: " + wrongOrders;

            if (timer <= 0)
            {
                EndGameCoffee();
            }
        }
    }

    IEnumerator StartGame()
    {
        // Wait a moment before starting the game
        yield return new WaitForSeconds(1f);
        GenerateOrder();
        isGameActive = true;
    }

    void GenerateOrder()
    {
        orderNumber = Random.Range(1, 6); // 5 orders
        currentOrderMilk = 1; // Example: 1 shot of milk
        currentOrderCoffee = Random.Range(1, 5); // 1 to 4 coffee shots
        currentOrderSyrup = Random.Range(1, 3); // 1 or 2 syrups

        // Set text for each ingredient
        milkText.text = currentOrderMilk.ToString();
        coffeeText.text = currentOrderCoffee.ToString();
        syrupText.text = currentOrderSyrup.ToString();

        // Reset counts for the new order
        milkPressedCount = 0;
        coffeePressedCount = 0;
        syrupPressedCount = 0;
    }

    void MoveCup()
    {
        // Move the cup to the right when G1 or G2 is pressed
        cup.transform.position = new Vector3(cup.transform.position.x + cupMoveSpeed, cup.transform.position.y, cup.transform.position.z);
    }

    void ChangeOrderAndCompare()
    {
        // Log comparisons and update the counts for correct and wrong orders
        Debug.Log("Comparing Milk Presses: " + milkPressedCount + " vs " + currentOrderMilk);
        Debug.Log("Comparing Coffee Presses: " + coffeePressedCount + " vs " + currentOrderCoffee);
        Debug.Log("Comparing Syrup Presses: " + syrupPressedCount + " vs " + currentOrderSyrup);

        bool isCorrectOrder = (milkPressedCount == currentOrderMilk) &&
                               (coffeePressedCount == currentOrderCoffee) &&
                               (syrupPressedCount == currentOrderSyrup);

        // Update correct or wrong order counts based on comparison
        if (isCorrectOrder)
        {
            correctOrders++;
            Debug.Log("Correct Order!");  // Log when the order is correct
        }
        else
        {
            wrongOrders++;
            Debug.Log("Wrong Order!");  // Log when the order is wrong
        }

        // Reset Cup Position and Generate New Order
        cup.transform.position = cupStartPosition;
        GenerateOrder();
    }

    void ButtonPressed(string ingredient)
    {
        // Increment counts based on button pressed
        if (ingredient == "milk")
        {
            milkPressedCount++;
            Debug.Log("Milk Button Pressed. Total Milk Pressed: " + milkPressedCount);
        }
        if (ingredient == "coffee")
        {
            coffeePressedCount++;
            Debug.Log("Coffee Button Pressed. Total Coffee Pressed: " + coffeePressedCount);
        }
        if (ingredient == "syrup")
        {
            syrupPressedCount++;
            Debug.Log("Syrup Button Pressed. Total Syrup Pressed: " + syrupPressedCount);
        }
    }

    void EndGameCoffee()
    {
        isGameActive = false;

        // Display results on the game over panel
        gameOverPanel.SetActive(true);
        //gameOverText.text = "Game Over! Time's up!";

        // Display correct and wrong orders in game over screen
        correctOrderTextFinal.text = " " + correctOrders;
        wrongOrderTextFinal.text = " " + wrongOrders;

        // Disable the green buttons after game over
        greenButton1.interactable = false;
        greenButton2.interactable = false;
        greenButton3.interactable = false;
    }

    public void RestartGameCoffee()
    {
        // Restart the game after Game Over
        isGameActive = false;
        timer = 30f;
        gameOverPanel.SetActive(false);

        // Enable the green buttons again
        greenButton1.interactable = true;
        greenButton2.interactable = true;
        greenButton3.interactable = true;

        // Start the game again
        StartCoroutine(StartGame());
    }
}
