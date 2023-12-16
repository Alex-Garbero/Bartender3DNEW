using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomerManagement : MonoBehaviour
{
    // Customer settings
    [Header("Customer Settings")]
    public GameObject customerPrefab;
    public Transform barDoorTransform;
    private GameObject newCustomer;
    public List<string> playerOrder = new List<string>();
    private bool isSpawning = false;
    private static TextMeshPro customerOrderText;
    
    
    // Bar Settings
    [Header("Bar Settings")]
    public Transform barStoolTransform;
    public float speed = 2.0f;
    public GameObject barStool;
    public GameObject barDoor;

    // Drink Class
    public class Drink
    {
        public string Name;
        public List<string> Ingredients;
    }

    // Drink List Class
    public static class DrinkList
    {
        public static List<string> GetDrinks()
        {
            return new List<string>
            {
                "Cape Cod, Rocks, Ice, Vodka, Cranberry, Lime",
                "Screwdriver, Rocks, Ice, Vodka, Orange, Lime"
            };
        }
        
    }

    // Gets the player drink for comparison
    private void Awake()
    {
        GameObject OrderController = GameObject.Find("OrderController");
        playerOrder = OrderController.GetComponent<CurrentOrder>().order;
    }

    // Sets the customer drink in DrinkComponent.cs
    private void SetCustomerDrink(GameObject customer, string drink)
    {
        DrinkComponent drinkComponent = customer.AddComponent<DrinkComponent>();
        drinkComponent.SetDrink(drink);
        
    }

    // Sets the customer ingredients in DrinkComponent.cs
    private void SetCustomerDrinkIngredients(GameObject customer, List<string> ingredients)
    {
        DrinkComponent drinkComponent = customer.AddComponent <DrinkComponent>();
        drinkComponent.SetIngredients(ingredients);
    }

    /*
     * These next few methods take care of customer spawning
     */

    // Start is called before the first frame update
    void Start()
    {
        //Starts spawning 
        StartCoroutine(SpawnCustomerPeriodically());
    }

    IEnumerator SpawnCustomerPeriodically()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);// Wait for 10 seconds
            SpawnNewCustomer();
        }
    }

    void SpawnNewCustomer()
    {
        if (!isSpawning && !IsCustomerCollidingWithBarStool())
        {
            StartCoroutine(SpawnCustomerRoutine());
        }
    }
    // Ends spawning
    
    //Checks if customer is at the bar and prevents spawning if so
    bool IsCustomerCollidingWithBarStool()
    {
        Collider barStoolCollider = barStool.GetComponent<Collider>();

        // Check if any customer is colliding with the bar stool
        GameObject[] customers = GameObject.FindGameObjectsWithTag("Customer");

        foreach (GameObject customer in customers)
        {
            if (barStoolCollider.bounds.Contains(customer.transform.position))
            {
                Debug.Log("HIT TRUE");
                
                return true; // A customer is colliding with the bar stool
                
            }
        }
        Debug.Log("Hit False");
        return false; // No customer is colliding with the bar stool
        
    }

    // Spawning routine to create customers that have a drink and their corresponding ingredient
    IEnumerator SpawnCustomerRoutine()
    {
        isSpawning = true;
        Debug.Log("Generating new customer");
        newCustomer = Instantiate(customerPrefab, barDoorTransform.position, Quaternion.identity);

        List<string> drinks = DrinkList.GetDrinks();
        int randomIndex = Random.Range(0, drinks.Count);
        string selectedDrink = drinks[randomIndex];
       string selectedDrinkName = selectedDrink.Substring(0, selectedDrink.IndexOf(','));
        Debug.Log("SpawnCustomerRoutine "+ selectedDrink);
        
        SetCustomerDrink(newCustomer, selectedDrink);
        List<string> ingredients = GetIngredientsForDrink(selectedDrinkName);

        if (selectedDrink.Contains(selectedDrinkName))
        {
            Debug.Log(selectedDrink + " if " + selectedDrinkName);
            selectedDrinkName = "Cape Cod";
            

        }
        else
        {
            Debug.Log(selectedDrink + " else " + selectedDrinkName);
            selectedDrinkName = "Screwdriver";
            

        }

        yield return StartCoroutine(MoveTowardsBar(newCustomer.transform));
        isSpawning = false;
    }

    // Takes the selected random drink and only extracts the ingredients
    List<string> GetIngredientsForDrink(string selectedDrinkName)
    {
       
        Debug.Log("Before if else " + selectedDrinkName);
        List<string> ingredients = new List<string>();
        List<string> drinks = DrinkList.GetDrinks();
        

       
     
        Debug.Log("in ingredients contains " + selectedDrinkName);

        foreach (string drink in drinks)
        {
            if (drink.StartsWith(selectedDrinkName))
            {
                // Find the index of the first comma
                int indexOfFirstComma = drink.IndexOf(',');

                // Check if a comma was found
                if (indexOfFirstComma != -1)
                {
                    // Extract the substring after the first comma and split by commas
                    string ingredientsString = drink.Substring(indexOfFirstComma + 1);
                    string[] drinkComponents = ingredientsString.Split(',');

                    // Trim each ingredient and add it to the list
                    foreach (string ingredient in drinkComponents)
                    {
                        ingredients.Add(ingredient.Trim());
                    }

                    // Print the ingredients using Debug.Log
                    Debug.Log($"Ingredients for {selectedDrinkName}: {string.Join(", ", ingredients)}");

                    // Set the ingredients for the customer
                    SetCustomerDrinkIngredients(newCustomer, ingredients);

                    return ingredients;
                }
            }
        }

        // If the selected drink is not found, return an empty list
        return ingredients;
    }
    
    //Moves the customer to the bar 
    IEnumerator MoveTowardsBar(Transform customerTransform)
    {
        Collider barStoolCollider = barStool.GetComponent<Collider>();

        while (Vector3.Distance(customerTransform.position, barStoolTransform.position) > 0.1f)
        {
            Vector3 direction = barStoolTransform.position - customerTransform.position;
            direction.Normalize();
            customerTransform.position += direction * speed * Time.deltaTime;

            if (barStoolCollider.bounds.Contains(customerTransform.position))
            {
                HandleCollisionWithBarStool(customerTransform.gameObject);
               
                yield break; // Exit the coroutine when a collision occurs
                
            }

            yield return null;
            
        }
    }
    // Generates a Drink Componenet once the customer has collided with the bar
    void HandleCollisionWithBarStool(GameObject customer)
    {
        DrinkComponent drinkComponent = customer.GetComponent<DrinkComponent>();

        if (drinkComponent != null)
        {
            
            string drink = drinkComponent.GetDrink();
            List<string> ingredients = drinkComponent.GetIngredients();
            ProvideIngredientsToCustomer(customer, DrinkList.GetDrinks());
        }

    }
    // This is where the player code can replace what I have here, which is an automatic check for ingredients
    void ProvideIngredientsToCustomer(GameObject customer, List<string> playerDrinkIngredients)
    {
        int points = 0;
        DrinkComponent drinkComponent = customer.GetComponent<DrinkComponent>();
        List<string> plist = new List<string>();
        List<string> clist = new List<string>();

        // Simulate the player providing the correct ingredients
        Debug.Log("Player provided matching ingredients. Drink served!");
        

        List<string> drinks = DrinkList.GetDrinks();
        int randomIndex = Random.Range(0, drinks.Count);
        string playerSelectedDrink = drinks[randomIndex];

        string selectedDrinkIngredientsString = playerSelectedDrink.Substring(playerSelectedDrink.IndexOf(',') + 1);
        

        // Split the ingredients string into a list
       playerDrinkIngredients = new List<string>(selectedDrinkIngredientsString.Split(','));
        // Get customer's drink ingredients
        List<string> customerDrinkIngredients = GetIngredientsForDrink(playerSelectedDrink);
        Debug.Log(playerDrinkIngredients);
        Debug.Log (customerDrinkIngredients);

        foreach (string ingredient in playerDrinkIngredients)
        {
            plist.Add(ingredient.Trim());
            Debug.Log("Ingredient: " + ingredient);
        }
        Debug.Log("Ingredients: " + string.Join(", ", playerDrinkIngredients));
        foreach (string ingredient in customerDrinkIngredients)
        {
            clist.Add(ingredient.Trim());
            Debug.Log("Ingredient: " + ingredient);
        }
        Debug.Log("Ingredients: " + string.Join(", ", customerDrinkIngredients));
        // Handle successful drink serving (e.g., destroy the customer, increase score, etc.)
        if (AreIngredientListsEqual(plist, clist))
        {

            StartCoroutine(DestroyCustomerAfterDelay(customer, 3f));
            points++;
        }
        else
        {
            points--;
        }
    }

    //Delay for deletion
    IEnumerator DestroyCustomerAfterDelay(GameObject customer, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Destroy the customer after the specified delay
        Destroy(customer);
    }
    // Checks if the player and customer have matching ingredients
    bool AreIngredientListsEqual(List<string> list1, List<string> list2)
    {
        // Compare two ingredient lists
        if (list1.Count != list2.Count)
            return false;

        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i])
                return false;
        }
        
        return true;
    }


    // Update is called once per frame
    void Update()
    {
        
        
       
    }
}
