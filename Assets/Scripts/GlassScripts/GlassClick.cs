using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//is a template for clicking on object, copy paste when creating a specialized version
public class GlassClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private CurrentOrder order;

    public void Start()
    {

    }
    private void Awake()
    {
        GameObject OrderController = GameObject.Find("OrderController");
        order = OrderController.GetComponent<CurrentOrder>();
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
        if (!order.ItemSelected && eventData.button == PointerEventData.InputButton.Left)
        {
            //changes layer
            gameObject.layer = 2;
            foreach (Transform child in transform)
            {
                child.gameObject.layer = 2;
                foreach (Transform grandchild in child)
                {
                    grandchild.gameObject.layer = 2;
                }
            }

            GetComponent<GlassMove>().enabled = true;
            order.ItemSelected = true;
            order.selectable = gameObject;
        }
        else if (order.ItemSelected && order.selectable.tag == "drink" && eventData.button == PointerEventData.InputButton.Left)
        {
            {
                order.selectable.GetComponent<soda>().tiltSoda();
                order.ItemSelected = false;
            }
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
