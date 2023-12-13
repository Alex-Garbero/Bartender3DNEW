using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTin : MonoBehaviour
{
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2.75f)).y - 0.35f <= 4f)
        {
            transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2.75f));
            transform.position = new Vector3(transform.position.x, 4f, -9.25f);
        }
        else if (cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2.75f)).y - 0.35f >= 5f)
        {
            transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2.75f));
            transform.position = new Vector3(transform.position.x, 5f, transform.position.z);
        }
        else
        {
            transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2.75f))+new Vector3(0,-0.35f,0);
        }


    }
            
}
