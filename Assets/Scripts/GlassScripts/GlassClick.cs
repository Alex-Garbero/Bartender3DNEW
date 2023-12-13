using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//is a template for clicking on object, copy paste when creating a specialized version
public class TinClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject newTin;
    private CurrentOrder order;
    private MoveTin move;
    public Vector3 originalPosition;
    private Transform smalltin;
    public bool meshOff = true;

    private void Awake()
    {
        originalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        move = GetComponent<MoveTin>();
        GameObject OrderController = GameObject.Find("OrderController");
        order = OrderController.GetComponent<CurrentOrder>();
        smalltin = gameObject.transform.GetChild(0);
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
        if (!meshOff&& eventData.button == PointerEventData.InputButton.Right)
        {
            Instantiate(newTin);
            smalltin.GetComponent<MeshRenderer>().enabled = false;
            meshOff = true;
        }
        else if (meshOff&&order.ItemSelected && order.selectable.tag == "SmallTin" && eventData.button == PointerEventData.InputButton.Left)
        {
            Destroy(order.selectable);
            smalltin.GetComponent<MeshRenderer>().enabled = true;
            order.ItemSelected = false;
            meshOff = false;
        }
        else if (!order.ItemSelected && eventData.button == PointerEventData.InputButton.Left)
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

