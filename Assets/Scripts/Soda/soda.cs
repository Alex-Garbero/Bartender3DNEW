using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soda : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tiltSoda()
    {
        transform.Rotate(Vector3.right, 130.0f);
    }
}
