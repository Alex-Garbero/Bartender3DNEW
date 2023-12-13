using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//this script controls how the soda gun acts when clicked
public class SodaGunMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private CurrentOrder order;     //script that handles orders
    private MoveObject move;        //script that handles object movement
    public Vector3 originalPosition;    //original transform.position
    public Vector3 originalRotation;    //original transform.rotation

    private void Awake()
    {
        //get orginal transformation
        originalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        originalRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        //gets movement script
        move = GetComponent<MoveObject>();
        //gets order script
        GameObject OrderController = GameObject.Find("OrderController");
        order = OrderController.GetComponent<CurrentOrder>();
    }

    void FixedUpdate()
    {
        
    }

    
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //order.ItemSelected is true when an item is being moved, PointerEventData.InputButton.Left tracks if a left click was pressed, PointerEventData.InputButton.Right checks for rightclick
        if (!order.ItemSelected && eventData.button == PointerEventData.InputButton.Left)
        {
            //gameObject.layer = 2 is the raycast ignore layer, this let you click on objects behind objects that are infront of the camera
            gameObject.layer = 2;
            //enables the movement script, move.enabled = false; stops item from following cursor
            move.enabled = true;
            order.ItemSelected = true;
            //order.selectable is the current object being selected/moved
            order.selectable = gameObject;
            //arbitrary rotation for sodagun: needs tweaking once we finalize everything
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
