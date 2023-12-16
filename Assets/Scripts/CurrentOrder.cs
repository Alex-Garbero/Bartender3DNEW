using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentOrder : MonoBehaviour
{
    public GameObject selectable;  //
    public bool ItemSelected = false;
    private string order = "";
    public GameObject glassOrder;
    // Start is called before the first frame update
    public void printOrder()
    {
        print(order);
        order = "";
    }
    public void addIngredient(string addon)
    {
        order = order +" "+ addon;
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
                //selectable.transform.position = selectable.GetComponent<SodaGunMove>().enabled =;
                selectable.transform.rotation = Quaternion.Euler(90, 90, 0);
            }
            else if (selectable.tag == "drink")
            {
                selectable.GetComponent<DrinkMove>().enabled = false;
                //selectable.transform.position = selectable.GetComponent<SodaGunMovement>().originalPosition;
            }
            else if (selectable.tag == "glass"&&selectable.GetInstanceID() == glassOrder.GetInstanceID())
            {
                Destroy(selectable);
                //delete order

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
