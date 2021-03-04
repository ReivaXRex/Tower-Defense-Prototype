using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 20;

    Bank bank;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    /// <summary>
    /// Add Gold to the Player's bank by the specified amount.
    /// </summary>
    public void RewardGold()
    {
        if (bank == null) { return; }

        bank.Deposit(goldReward);
    }

    /// <summary>
    /// Remove Gold from the Player's bank by the specified amount.
    /// </summary>
    public void StealGold()
    {
        if (bank == null) { return; }

        bank.Withdraw(goldPenalty);
    }
}
