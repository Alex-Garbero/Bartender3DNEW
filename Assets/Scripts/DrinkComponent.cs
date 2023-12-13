using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Getters and setters
 */

public class DrinkComponent : MonoBehaviour
{
    private string drink;
    private List<string> ingredients;

    public void SetDrink(string newDrink)
    {
        drink = newDrink;
    }
    public void SetIngredients(List<string> newingredients)
    {
        ingredients = newingredients;
    }
    public string GetDrink()
    {
        return drink;
    }
    public List<string> GetIngredients()
    {
        return ingredients;
    }
    
}
/*public class Drink
{
    public string Name;
    public List<string> Ingredients;
}
*/
