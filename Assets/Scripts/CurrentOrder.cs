using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentOrder : MonoBehaviour
{
    public GameObject selectable;  //
    public bool ItemSelected = false;
    public List<string> order = new List<string>();
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
        bool dupe = false;
        foreach(string cur in order)
        {
            if(cur == addon)
            {
                dupe = true;
            }
        }
        if(!dupe)
            order.Add(addon);
        dupe = false;
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
                ItemSelected = false;
                foreach (Transform child in selectable.transform)
                {
                    child.gameObject.layer = 0;
                }
            }
            else if (selectable.tag == "drink")
            {
                selectable.GetComponent<DrinkMove>().enabled = false;
                selectable.transform.position = selectable.GetComponent<DrinkClick>().originalPosition;
                ItemSelected = false;
            }
            else if ((selectable.tag == "collins" || selectable.tag == "rocks") && selectable.GetInstanceID() == glassOrder.GetInstanceID())
            {
                Destroy(selectable);
                resetOrder();
                ItemSelected = false;
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
