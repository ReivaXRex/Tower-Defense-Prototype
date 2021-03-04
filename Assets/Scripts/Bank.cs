using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldText;

    [SerializeField] int startingBalance = 150;
    
    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    private void Awake()
    {
       
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    /// <summary>
    /// Add Gold to the Player's current balance and update the UI.
    /// </summary>
    /// <param name="amount"></param>
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount); // Mathf.Abs to correct for negative inputs. -10 becomes +10.
        UpdateDisplay();
    }

    /// <summary>
    /// Subtract from the Player's Gold Balance.
    /// </summary>
    /// <param name="amount">
    /// Amount to substract.
    /// </param>
    public void Withdraw(int amount)
    {   
        // Subtract a specified amount from the current balance (no negatives). 
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if (currentBalance < 0) // When the Player has no more Gold.
        {
            // Lose the game & reload the level.
            ReloadScene();
           
        }
    }

    /// <summary>
    /// Update the Gold Text UI to the Player's current balance.
    /// </summary>
    void UpdateDisplay()
    {
        goldText.text = "Gold: " + currentBalance;
    }

    /// <summary>
    /// Reset the current level.
    /// </summary>
    void ReloadScene()
    {
        // Grab the current scene and store it within a variable.
        Scene currentScene = SceneManager.GetActiveScene();

        // Load the next scene using the current scene variable (which will reload the current level).
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
