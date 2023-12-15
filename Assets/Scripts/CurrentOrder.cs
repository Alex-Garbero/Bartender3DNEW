using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentOrder : MonoBehaviour
{
    public GameObject selectable;  //
    public bool ItemSelected = false;
    private string order = "";
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
            //disables movement script, must be diabled before placing object back to its location
            selectable.GetComponent<MoveObject>().enabled = false;
            //if sodagun it rotates back into place
            if (selectable.tag == "sodagun")
            {
                selectable.transform.position = selectable.GetComponent<SodaGunMovement>().originalPosition;
                selectable.transform.rotation = Quaternion.Euler(90, 90, 0);
            }

            else
            {
                //selectable.transform.position = selectable.GetComponent<Clickable>().originalPosition;
            }

            //changes boolean and reset layer back to default
            ItemSelected = false;
            selectable.layer = 0;
        }
    }
}
