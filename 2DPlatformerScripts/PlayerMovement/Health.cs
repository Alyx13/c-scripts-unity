using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100; // The maximum amount of health the player can have
    private int currentHealth; // The current amount of health the player has

    private void Start()
    {
        // Set the current health to the maximum health
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        // Reduce the player's health by the damage amount
        currentHealth -= damageAmount;

        // Check if the player has no more health
        if (currentHealth <= 0)
        {
            // Handle the player dying
            Debug.Log("Player died!");

            // Destroy the player GameObject
            Destroy(gameObject);
        }
    }
}

