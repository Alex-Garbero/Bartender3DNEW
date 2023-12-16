using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//is a template for clicking on object, copy paste when creating a specialized version
public class SodaGunButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private CurrentOrder order;
    private GameObject parent;
    public string sodatype;
    public Material color;

    void Start()
    {

    }
    private void Awake()
    {

        GameObject OrderController = GameObject.Find("OrderController");
        order = OrderController.GetComponent<CurrentOrder>();
        parent = transform.parent.gameObject;



         
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //changer.confirm();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //changer.revert();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (order.selectable.tag == "sodagun" &&eventData.button == PointerEventData.InputButton.Left)
        {
            //changes layer
            parent.layer = 2;
            foreach (Transform child in parent.transform)
            {
                child.gameObject.layer = 2;
                child.gameObject.GetComponent<SodaGunButtons>().enabled = false;

            }

            parent.GetComponent<SodaGunMove>().enabled = true;
            parent.GetComponent<SodaGunClick>().type = sodatype;
            if (gameObject.tag == "Soda Water")
                order.water = true;
            else
                parent.GetComponent<SodaGunClick>().color = color;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //changer.change();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //changer.revert();
    }
}
