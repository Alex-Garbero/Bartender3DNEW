using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimeMove : MonoBehaviour
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
        transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2))+new Vector3(0.15f,0.01f,0f);
    }
}
