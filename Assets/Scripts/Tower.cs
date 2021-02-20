using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null)
        {
            return false;
        }

        if (bank.CurrentBalance >= cost) // If the Player has enough Gold to create a Tower.
        {
            Instantiate(tower.gameObject, position, Quaternion.identity); // Spawn a Tower
            bank.Withdraw(cost); // Subtract the cost from the Player's bank.
            return true;
        }

        return false; // If all else fails, return false.
    }
}
