using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkMove : MonoBehaviour
{
    private Camera cam;
    public bool pour = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2))+new Vector3(0.01f,0,0);
    }

    void FixedUpdate()
    {
        if(pour&&transform.rotation.x < 0.6f)
            transform.Rotate(Vector3.right, 180.0f*Time.deltaTime);
        else if (!pour && transform.rotation.x > 0f)
        {
            transform.Rotate(Vector3.right, -130.0f * Time.deltaTime);
        }
    }
}
