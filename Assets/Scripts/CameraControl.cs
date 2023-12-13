using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    Vector2 cameraBounds;

    public Camera main;
    public Camera secondary;
    public GameObject submit;


    void Start()
    {
        cameraBounds = new Vector2(Screen.width, Screen.height);
    }
    public void CustomerCam()
    {
        main.enabled = false;
        secondary.enabled = true;
        submit.SetActive(false);
    }

    public void DrinkCam()
    {
        secondary.enabled = false;
        main.enabled = true;
        submit.SetActive(true);
    }
    
    public void FixedUpdate()
    {
        //if mouse below threshhold camera turns down
        if (main.transform.rotation.x * Mathf.Rad2Deg < 17.5f && cameraBounds.y / 10f > Input.mousePosition.y)
        {
            main.transform.Rotate(Vector3.right, 30.0f * Time.deltaTime);
        }
        //if mouse above threshhold camera turns up
        else if (main.transform.rotation.x * Mathf.Rad2Deg > 0f && cameraBounds.y - (cameraBounds.y / 10f) < Input.mousePosition.y)
            main.transform.Rotate(Vector3.left, 30.0f * Time.deltaTime);
    }
}
