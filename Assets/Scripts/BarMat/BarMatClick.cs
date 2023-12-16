using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//is a template for clicking on object, copy paste when creating a specialized version
public class BarMatClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private CurrentOrder order;
    private GameObject glassOrder;
    private bool curGlass= false;


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
        if (order.ItemSelected && (order.selectable.tag=="Tin"|| order.selectable.tag == "SmallTin") && eventData.button == PointerEventData.InputButton.Left)
        {
            order.selectable.GetComponent<MoveTin>().enabled = false;
            order.selectable.transform.position = new Vector3(order.selectable.transform.position.x, 3.9f, order.selectable.transform.position.z);
            order.selectable.layer = 0;
            foreach (Transform child in order.selectable.transform)
            {
                child.gameObject.layer = 0;
                foreach (Transform grandchild in child)
                {
                    grandchild.gameObject.layer = 0;
                }
            }
            order.ItemSelected = false;
        }
        else if(order.ItemSelected && order.selectable.tag == "glass" && eventData.button == PointerEventData.InputButton.Left)
        {
            //failure point potentially in the future
            if (curGlass&&order.selectable.GetInstanceID() != glassOrder.GetInstanceID())
            {
                Destroy(glassOrder);
                curGlass = false;
                order.resetOrder();
            }
            glassOrder = order.selectable;
            glassOrder.GetComponent<GlassMove>().enabled = false;
            glassOrder.transform.position = new Vector3(glassOrder.transform.position.x, 3.9f, -9.25f);
            glassOrder.layer = 0;
            foreach (Transform child in glassOrder.transform)
            {
                child.gameObject.layer = 0;
                foreach (Transform grandchild in child)
                {
                    grandchild.gameObject.layer = 0;
                }
            }
            glassOrder.GetComponent<GlassClick>().enabled = true;
            order.ItemSelected = false;
            glassOrder = order.selectable;
            curGlass = true;
            order.glassOrder = glassOrder;
            order.addIngredient("glass");
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
