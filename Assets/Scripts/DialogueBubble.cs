using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBubble : MonoBehaviour
{
    public TextMeshProUGUI orderText; // Make sure this matches the text component you're using
    public DrinkOrderManager drinkOrderManager; // Reference to the DrinkOrderManager script
    CustomerManagement customer;
    private void Awake()
    {
        // Make sure the dialogue bubble is not active when the game starts
        gameObject.SetActive(true);
        GameObject customerOBJ = GameObject.Find("Customer");
        customer = customerOBJ.GetComponent<CustomerManagement>();
    }

    private void Update()
    {
        ShowOrder("I would like a "+customer.drinkToSpeech);
    }
    // This method is public so it can be called by the button's OnClick event
    public void ShowRandomOrder()
    {
        // If the DrinkOrderManager is not already set, try to find it
        if (drinkOrderManager == null)
        {
            drinkOrderManager = FindObjectOfType<DrinkOrderManager>();
        }

        string randomOrder = drinkOrderManager.GetRandomDrinkOrder(); // Get a random drink
        ShowOrder(randomOrder); // Show the order using the existing method
    }

    private void ShowOrder(string order)
    {
        orderText.text = order;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
