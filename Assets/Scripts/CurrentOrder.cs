using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentOrder : MonoBehaviour
{
    public GameObject selectable;  //
    public bool ItemSelected = false;
    private List<string> order = new List<string>();
    public GameObject glassOrder;
    // Start is called before the first frame update
    public void printOrder()
    {
        foreach (var month in order)
        {
            print(month);
        }
        resetOrder();
    }
    public void addIngredient(string addon)
    {
        order.Add(addon);
    }
    public void resetOrder()
    {
        order = new List<string>();
    }
    void Update()
    {
        //right click anywhere to put down item
        
        if (Input.GetMouseButtonDown(1)&&ItemSelected)
        {
            //if sodagun it rotates back into place
            if (selectable.tag == "sodagun")
            {
                selectable.GetComponent<SodaGunMove>().enabled = false;
                selectable.transform.rotation = selectable.GetComponent<SodaGunClick>().originalRotation;
                selectable.transform.position = selectable.GetComponent<SodaGunClick>().originalPosition;
            }
            else if (selectable.tag == "drink")
            {
                selectable.GetComponent<DrinkMove>().enabled = false;
                selectable.transform.position = selectable.GetComponent<DrinkClick>().originalPosition;
            }
            else if (selectable.tag == "glass"&&selectable.GetInstanceID() == glassOrder.GetInstanceID())
            {
                Destroy(selectable);
                resetOrder();

            }

            else
            {
                Destroy(selectable);
            }

            ItemSelected = false;
            selectable.layer = 0;
        }
    }
}
