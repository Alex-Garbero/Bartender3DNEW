using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkOrderManager : MonoBehaviour
{
    // Array to store the names of the drinks
    private string[] drinks = new string[] { "Cape Cod", "Screwdriver" };

    // Function to get a random drink order
    public string GetRandomDrinkOrder()
    {
        int randomIndex = Random.Range(0, drinks.Length); // Get a random index
        return drinks[randomIndex]; // Return the drink at the random index
    }
}
