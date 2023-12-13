using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//is a template for clicking on object, copy paste when creating a specialized version
public class SmallTinClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private CurrentOrder order;
    private MoveTin move;
    public Vector3 originalPosition;

    private void Awake()
    {
        originalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        move = GetComponent<MoveTin>();
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
            gameObject.layer = 2;
            foreach (Transform child in transform)
            {
                child.gameObject.layer = 2;
                foreach (Transform grandchild in child)
                {
                    grandchild.gameObject.layer = 2;
                }
            }
            move.enabled = true;
            order.ItemSelected = true;
            order.selectable = gameObject;
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

